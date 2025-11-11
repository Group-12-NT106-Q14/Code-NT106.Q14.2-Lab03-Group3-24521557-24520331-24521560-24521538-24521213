using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Code_NT106.Q14._2_Lab03_Group3_24521557_24520331_24521560_24521538_24521213
{
    public partial class Bai03TCPServerForm : Form
    {
        private TcpListener listener;
        private Thread listenThread;

        public Bai03TCPServerForm()
        {
            InitializeComponent();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            btnListen.Enabled = false;
            listenThread = new Thread(ListenThreadFunc);
            listenThread.IsBackground = true;
            listenThread.Start();

            string localIP = "";
            var ips = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            foreach (var a in ips)
            {
                if (a.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = a.ToString();
                    break;
                }
            }
            txtLog.AppendText($"Server đang lắng nghe tại địa chỉ {localIP}:3000{Environment.NewLine}");
            txtLog.AppendText("Server đã khởi động thành công!\r\n");
            MessageBox.Show("Server đã khởi động thành công!");
        }

        private void ListenThreadFunc()
        {
            listener = new TcpListener(IPAddress.Any, 3000);
            listener.Start();
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Thread thr = new Thread(() => ClientProcessing(client));
                thr.IsBackground = true;
                thr.Start();
            }
        }

        private void ClientProcessing(TcpClient client)
        {
            try
            {
                NetworkStream ns = client.GetStream();
                byte[] buffer = new byte[1024];
                int n = ns.Read(buffer, 0, buffer.Length);
                string msg = Encoding.UTF8.GetString(buffer, 0, n);
                string resp = $"Server nhận: {msg}";
                ns.Write(Encoding.UTF8.GetBytes(resp), 0, Encoding.UTF8.GetByteCount(resp));
                BeginInvoke(new Action(() => txtLog.AppendText($"Client gửi: {msg}\r\n")));
                ns.Close();
                client.Close();
            }
            catch { }
        }
    }
}
