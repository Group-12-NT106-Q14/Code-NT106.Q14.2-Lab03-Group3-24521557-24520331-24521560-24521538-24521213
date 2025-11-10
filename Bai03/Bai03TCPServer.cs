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
        public Bai03TCPServerForm()
        {
            InitializeComponent();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread serverThread = new Thread(ServerThreadFunc);
            serverThread.IsBackground = true;
            serverThread.Start();
        }

        void ServerThreadFunc()
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 8080);
            listener.Start();
            AddMessage("Server started!");
            TcpClient client = listener.AcceptTcpClient();
            IPEndPoint clientEP = (IPEndPoint)client.Client.RemoteEndPoint;
            AddMessage($"Connection accepted from {clientEP.Address}:{clientEP.Port}");

            NetworkStream ns = client.GetStream();
            byte[] buffer = new byte[1024];
            while (true)
            {
                int count = ns.Read(buffer, 0, buffer.Length);
                if (count == 0) break;
                string msg = Encoding.UTF8.GetString(buffer, 0, count);
                if (msg.Trim() == "quit") break;
                AddMessage($"From client: {msg.Trim()}");
            }
            ns.Close();
            client.Close();
            listener.Stop();
        }

        void AddMessage(string s)
        {
            txtMessages.AppendText(s + Environment.NewLine);
        }
    }
}
