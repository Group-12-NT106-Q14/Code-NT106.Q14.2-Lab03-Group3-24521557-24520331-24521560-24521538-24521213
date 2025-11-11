using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Code_NT106.Q14._2_Lab03_Group3_24521557_24520331_24521560_24521538_24521213
{
    public partial class Bai01UDPServerForm : Form
    {
        private Thread listenerThread;
        private UdpClient udpListener;
        private bool isListening = false;

        public Bai01UDPServerForm()
        {
            InitializeComponent();
            txtPort.Text = string.Empty;

            // Thêm dòng báo IP của server khi mở form
            string ipLan = GetLocalIPv4();
            AddMessage($"Địa chỉ IP của Server: {ipLan}");
        }

        // Hàm lấy IPv4 đầu tiên (LAN)
        public static string GetLocalIPv4()
        {
            string localIP = "";
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork && !ip.ToString().StartsWith("169.254"))
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPort.Text))
            {
                MessageBox.Show("Vui lòng nhập Port.");
                return;
            }
            if (!int.TryParse(txtPort.Text.Trim(), out int port) || port < 1 || port > 65535)
            {
                MessageBox.Show("Port không hợp lệ (1-65535).");
                return;
            }

            if (!isListening)
            {
                try
                {
                    udpListener = new UdpClient(port);
                    isListening = true;
                    btnListen.Text = "Stop Listen";
                    AddMessage($"Đang lắng nghe trên port {port}...");
                    listenerThread = new Thread(ListenLoop);
                    listenerThread.IsBackground = true;
                    listenerThread.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi mở port: {ex.Message}");
                    isListening = false;
                    btnListen.Text = "Listen";
                }
            }
            else
            {
                StopListening();
            }
        }

        private void ListenLoop()
        {
            while (isListening)
            {
                try
                {
                    IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    byte[] receivedBytes = udpListener.Receive(ref remoteEndPoint);
                    string message = Encoding.UTF8.GetString(receivedBytes);
                    string display = $"{remoteEndPoint.Address}:{remoteEndPoint.Port} - {message}";
                    if (lstMessages.InvokeRequired)
                        lstMessages.Invoke(new Action<string>(AddMessage), display);
                    else
                        AddMessage(display);
                }
                catch (SocketException ex)
                {
                    if (!isListening && ex.SocketErrorCode == SocketError.Interrupted)
                        break; 
                    if (lstMessages.InvokeRequired)
                        lstMessages.Invoke(new Action<string>(AddMessage), $"Lỗi nhận: {ex.Message}");
                    else
                        AddMessage($"Lỗi nhận: {ex.Message}");
                }
                catch (Exception ex)
                {
                    if (isListening)
                    {
                        if (lstMessages.InvokeRequired)
                            lstMessages.Invoke(new Action<string>(AddMessage), $"Lỗi nhận: {ex.Message}");
                        else
                            AddMessage($"Lỗi nhận: {ex.Message}");
                    }
                }
            }
        }


        private void AddMessage(string message)
        {
            lstMessages.Items.Add(message);
            lstMessages.SelectedIndex = lstMessages.Items.Count - 1;
            lstMessages.TopIndex = lstMessages.Items.Count - 1;
        }

        private void StopListening()
        {
            isListening = false;
            try
            {
                udpListener?.Close();
            }
            catch { }
            if (listenerThread != null && listenerThread.IsAlive)
            {
                listenerThread.Join(1000);
            }
            btnListen.Text = "Listen";
            if (lstMessages.InvokeRequired)
            {
                lstMessages.Invoke(new Action(() => AddMessage("Đã dừng lắng nghe.")));
            }
            else
            {
                AddMessage("Đã dừng lắng nghe.");
            }
        }

        private void Bai01UDPServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopListening();
        }
    }
}
