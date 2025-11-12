using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace Code_NT106.Q14._2_Lab03_Group3_24521557_24520331_24521560_24521538_24521213
{
    public partial class Bai06TCPServer : Form
    {
        private TcpListener tcpListener;
        private ConcurrentDictionary<string, TcpClient> connectedClients = new ConcurrentDictionary<string, TcpClient>();
        private bool isRunning = false;

        public Bai06TCPServer()
        {
            InitializeComponent();
        }

        private async void btnListen_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                btnListen.Enabled = false;
                txtServerLog.Clear();
                isRunning = true;
                int port = 6000;
                string localIP = GetLocalIPAddress();
                tcpListener = new TcpListener(IPAddress.Any, port);
                tcpListener.Start();
                Log($"Server started at {localIP}:{port}");
                await AcceptClientsAsync();
            }
        }

        private async Task AcceptClientsAsync()
        {
            while (isRunning)
            {
                
                TcpClient client = await tcpListener.AcceptTcpClientAsync();
                _ = HandleClientAsync(client);
            }
        }

        private async Task HandleClientAsync(TcpClient tcpClient)
        {
            string clientName = "";
            NetworkStream stream = tcpClient.GetStream();
            byte[] buffer = new byte[4096];
            try
            {
                int byteCount = await stream.ReadAsync(buffer, 0, buffer.Length);
                string introMsg = Encoding.UTF8.GetString(buffer, 0, byteCount);
                clientName = GetUniqueClientName(introMsg.Trim());
                connectedClients[clientName] = tcpClient;
                UpdateClientListUI();
                Log($"New client connected: {clientName}");
                Broadcast($"{clientName} joined the chat!", "SERVER");
                BroadcastParticipants();

                while (isRunning && tcpClient.Connected)
                {
                    int cnt = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (cnt == 0) break;
                    string message = Encoding.UTF8.GetString(buffer, 0, cnt);
                    Broadcast(message, clientName);
                    Log($"{clientName}: {message}");
                }
            }
            catch (Exception ex)
            {
                Log($"Client {clientName} error/disconnect: {ex.Message}");
            }
            finally
            {
                tcpClient.Close();
                TcpClient _;
                connectedClients.TryRemove(clientName, out _);
                UpdateClientListUI();
                Broadcast($"{clientName} left the chat.", "SERVER");
                BroadcastParticipants();
                Log($"Client {clientName} disconnected.");
            }
        }

        private void Broadcast(string message, string sender)
        {
            foreach (var kv in connectedClients.ToList())
            {
                try
                {
                    NetworkStream ns = kv.Value.GetStream();
                    byte[] data = Encoding.UTF8.GetBytes($"{sender}: {message}");
                    ns.Write(data, 0, data.Length);
                }
                catch { }
            }
        }

        private void BroadcastParticipants()
        {
            var msg = "PARTICIPANTS:" + string.Join(",", connectedClients.Keys);
            foreach (var kv in connectedClients.ToList())
            {
                try
                {
                    NetworkStream ns = kv.Value.GetStream();
                    byte[] data = Encoding.UTF8.GetBytes(msg); // No sender prefix
                    ns.Write(data, 0, data.Length);
                }
                catch { }
            }
        }

        private string GetUniqueClientName(string requestedName)
        {
            string name = requestedName;
            int suffix = 1;
            while (connectedClients.ContainsKey(name))
            {
                name = requestedName + $"_{suffix++}";
            }
            return name;
        }

        private void UpdateClientListUI()
        {
            this.Invoke((MethodInvoker)delegate
            {
                listBoxParticipants.Items.Clear();
                foreach (var client in connectedClients.Keys)
                    listBoxParticipants.Items.Add(client);
                lblOnlineCount.Text = $"Online: {connectedClients.Count}";
            });
        }

        private void Log(string logmsg)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtServerLog.AppendText($"{DateTime.Now:T} {logmsg}\r\n");
            });
        }

        private string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    return ip.ToString();
            }
            return "127.0.0.1";
        }

        private void Bai06TCPServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            isRunning = false;
            tcpListener?.Stop();
            foreach (var client in connectedClients.Values)
                client.Close();
            Log("Server stopped.");
        }
    }
}
