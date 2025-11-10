using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Code_NT106.Q14._2_Lab03_Group3_24521557_24520331_24521560_24521538_24521213
{
    public partial class Bai02Form : Form
    {
        public Bai02Form()
        {
            InitializeComponent();
        }

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
        private void StartListen(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread serverThread = new Thread(new ThreadStart(StartUnsafeThread));
            serverThread.IsBackground = true;
            serverThread.Start();
        }
        void StartUnsafeThread()
        {
            int bytesReceived = 0;
            byte[] recv = new byte[8]; 
            string ipLan = GetLocalIPv4();
            Socket listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipepServer = new IPEndPoint(IPAddress.Parse(ipLan), 8080);
            listenerSocket.Bind(ipepServer);
            listenerSocket.Listen(-1);
            listViewCommand.Items.Add(new ListViewItem($"Telnet running on {ipLan}:8080"));
            Socket clientSocket = listenerSocket.Accept();
            IPEndPoint remoteEndPoint = (IPEndPoint)clientSocket.RemoteEndPoint;
            listViewCommand.Items.Add(new ListViewItem($"New client connected: {remoteEndPoint.Address}:{remoteEndPoint.Port}"));
            while (clientSocket.Connected)
            {
                string text = "";
                do
                {
                    bytesReceived = clientSocket.Receive(recv);
                    text += Encoding.UTF8.GetString(recv, 0, bytesReceived);
                }
                while (text.Length == 0 || text[text.Length - 1] != '\n');

                string notify = $"[{remoteEndPoint.Address}]: {text.TrimEnd('\r', '\n')}";
                listViewCommand.Items.Add(new ListViewItem(notify));
            }
            listenerSocket.Close();
        }
    }
}
