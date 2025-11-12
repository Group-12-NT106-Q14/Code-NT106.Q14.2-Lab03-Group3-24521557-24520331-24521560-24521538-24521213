using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;

namespace Code_NT106.Q14._2_Lab03_Group3_24521557_24520331_24521560_24521538_24521213
{
    public partial class Bai06TCPClient : Form
    {
        TcpClient tcpClient;
        NetworkStream stream;
        string userName = "";
        bool connected = false;

        public Bai06TCPClient()
        {
            InitializeComponent();
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtIpServer.Text))
            {
                MessageBox.Show("Vui lòng nhập tên và IP server!");
                return;
            }
            userName = txtName.Text.Trim();
            try
            {
                tcpClient = new TcpClient();
                await tcpClient.ConnectAsync(txtIpServer.Text.Trim(), 6000);
                stream = tcpClient.GetStream();
                byte[] introMsg = Encoding.UTF8.GetBytes(userName);
                await stream.WriteAsync(introMsg, 0, introMsg.Length);

                connected = true;
                btnConnect.Enabled = false;
                txtName.Enabled = false;
                txtIpServer.Enabled = false;
                btnSend.Enabled = true;
                txtMessage.Enabled = true;
                AddChat("Kết nối thành công!", "SYSTEM");
                _ = ReceiveLoopAsync();
            }
            catch (Exception ex)
            {
                AddChat($"Không kết nối được: {ex.Message}", "SYSTEM");
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            if (!connected || string.IsNullOrWhiteSpace(txtMessage.Text)) return;
            string msgToSend = txtMessage.Text;
            byte[] buf = Encoding.UTF8.GetBytes(msgToSend);
            await stream.WriteAsync(buf, 0, buf.Length);
            txtMessage.Clear();
        }

        private async Task ReceiveLoopAsync()
        {
            byte[] buffer = new byte[4096];
            try
            {
                while (connected)
                {
                    int cnt = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (cnt == 0) break;
                    string msg = Encoding.UTF8.GetString(buffer, 0, cnt);

                    if (msg.StartsWith("PARTICIPANTS:"))
                    {
                        UpdateParticipants(msg);
                        continue;
                    }

                    int idx = msg.IndexOf(':');
                    string sender = idx > 0 ? msg.Substring(0, idx) : "SERVER";
                    string content = idx > 0 ? msg.Substring(idx + 1).Trim() : msg;

                    AddChat(content, sender);
                }
            }
            catch (Exception ex)
            {
                AddChat($"Connection lost: {ex.Message}", "SYSTEM");
                ClearChatUI();
            }
            finally
            {
                connected = false;
            }
        }

        private void UpdateParticipants(string msg)
        {
            if (msg.StartsWith("PARTICIPANTS:"))
            {
                var arr = msg.Substring("PARTICIPANTS:".Length).Split(',');
                Invoke((MethodInvoker)(() =>
                {
                    listBoxParticipants.Items.Clear();
                    foreach (var user in arr)
                        if (!string.IsNullOrWhiteSpace(user))
                            listBoxParticipants.Items.Add(user);
                    lblOnlineCount.Text = $"Online: {arr.Count(x => !string.IsNullOrWhiteSpace(x))}";
                }));
            }
        }

        private void AddChat(string msg, string sender)
        {
            Invoke((MethodInvoker)(() =>
            {
                richTextBoxChat.SelectionColor = sender == "SYSTEM" ? Color.OrangeRed :
                    (sender == userName ? Color.DarkGreen : Color.Blue);
                richTextBoxChat.AppendText($"{DateTime.Now:T} [{sender}]: {msg}\r\n");
                richTextBoxChat.ScrollToCaret();
            }));
        }

        private void ClearChatUI()
        {
            Invoke((MethodInvoker)(() =>
            {
                richTextBoxChat.Clear();
                listBoxParticipants.Items.Clear();
                btnConnect.Enabled = true;
                txtName.Enabled = true;
                txtIpServer.Enabled = true;
                btnSend.Enabled = false;
                txtMessage.Enabled = false;
            }));
        }

        private void Bai06TCPClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            try { tcpClient?.Close(); } catch { }
            connected = false;
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                btnSend.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
    }
}
