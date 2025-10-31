using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Code_NT106.Q14._2_Lab03_Group3_24521557_24520331_24521560_24521538_24521213
{
    public partial class Bai01UDPClientForm : Form
    {
        public Bai01UDPClientForm()
        {
            InitializeComponent();
            txtRemoteIp.Text = string.Empty;
            txtPort.Text = string.Empty;
            txtMessage.Text = string.Empty;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRemoteIp.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ IP.");
                txtRemoteIp.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPort.Text))
            {
                MessageBox.Show("Vui lòng nhập Port.");
                txtPort.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                MessageBox.Show("Vui lòng nhập Message.");
                txtMessage.Focus();
                return;
            }
            if (!IPAddress.TryParse(txtRemoteIp.Text.Trim(), out IPAddress ip))
            {
                MessageBox.Show("Địa chỉ IP không hợp lệ.");
                txtRemoteIp.Focus();
                return;
            }
            if (!int.TryParse(txtPort.Text.Trim(), out int port) || port < 1 || port > 65535)
            {
                MessageBox.Show("Port không hợp lệ (1-65535).");
                txtPort.Focus();
                return;
            }
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(txtMessage.Text.Trim());
                using (UdpClient client = new UdpClient())
                {
                    client.Send(data, data.Length, new IPEndPoint(ip, port));
                }
                MessageBox.Show("Đã gửi message thành công.");
                txtMessage.Clear();  
                txtMessage.Focus(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi gửi: {ex.Message}");
            }
        }
    }
}