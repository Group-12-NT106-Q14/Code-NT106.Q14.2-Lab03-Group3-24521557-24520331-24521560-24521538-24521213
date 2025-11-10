using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Code_NT106.Q14._2_Lab03_Group3_24521557_24520331_24521560_24521538_24521213
{
    public partial class Bai03TCPClientForm : Form
    {
        TcpClient client;
        NetworkStream ns;

        public Bai03TCPClientForm()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                client = new TcpClient();
                client.Connect(IPAddress.Parse("127.0.0.1"), 8080);
                ns = client.GetStream();
                btnConnect.Enabled = false;
                btnSend.Enabled = true;
                btnDisconnect.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Cannot connect to server!");
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (ns == null || !client.Connected)
                return;
            string msg = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(msg)) return;

            byte[] data = Encoding.UTF8.GetBytes(msg + "\n");
            ns.Write(data, 0, data.Length);
            txtMessage.Clear();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (ns != null)
            {
                byte[] quit = Encoding.UTF8.GetBytes("quit\n");
                ns.Write(quit, 0, quit.Length);
                ns.Close();
            }
            if (client != null)
                client.Close();

            btnConnect.Enabled = true;
            btnSend.Enabled = false;
            btnDisconnect.Enabled = false;
        }
    }
}
