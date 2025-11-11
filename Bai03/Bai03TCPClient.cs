using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Code_NT106.Q14._2_Lab03_Group3_24521557_24520331_24521560_24521538_24521213
{
    public partial class Bai03TCPClientForm : Form
    {
        private TcpClient client;
        private NetworkStream ns;

        public Bai03TCPClientForm()
        {
            InitializeComponent();
            btnSend.Enabled = false;
            btnDisconnect.Enabled = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string ip = txtServerIP.Text.Trim();
            if (string.IsNullOrEmpty(ip)) ip = "127.0.0.1";
            try
            {
                client = new TcpClient();
                client.Connect(ip, 3000);
                ns = client.GetStream();
                btnSend.Enabled = true;
                btnDisconnect.Enabled = true;
                btnConnect.Enabled = false;
                txtLog.Text += $"[+] Đã kết nối tới server {ip}\r\n";
            }
            catch
            {
                MessageBox.Show("Không thể kết nối đến server!");
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string msg = txtMessage.Text;
            if (string.IsNullOrEmpty(msg) || ns == null) return;

            ThreadPool.QueueUserWorkItem(_ =>
            {
                try
                {
                    byte[] data = Encoding.UTF8.GetBytes(msg);
                    ns.Write(data, 0, data.Length);
                    byte[] buff = new byte[1024];
                    int n = ns.Read(buff, 0, buff.Length);
                    string response = Encoding.UTF8.GetString(buff, 0, n);
                    this.Invoke(new Action(() => txtResponse.Text = response));
                    this.Invoke(new Action(() => txtLog.Text += $"[>] Sent: {msg}\r\n[<] Recv: {response}\r\n"));
                }
                catch
                {
                    this.Invoke(new Action(() => MessageBox.Show("Mất kết nối tới server!")));
                }
            });
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try { ns?.Close(); client?.Close(); } catch { }
            ns = null; client = null;
            btnConnect.Enabled = true;
            btnSend.Enabled = false;
            btnDisconnect.Enabled = false;
            txtLog.Text += "[x] Đã ngắt kết nối với server\r\n";
        }
    }
}
