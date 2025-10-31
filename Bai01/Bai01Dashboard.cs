using System;
using System.Windows.Forms;

namespace Code_NT106.Q14._2_Lab03_Group3_24521557_24520331_24521560_24521538_24521213
{
    public partial class Bai01DashboardForm : Form
    {
        public Bai01DashboardForm()
        {
            InitializeComponent();
        }

        private void btnUDPServer_Click(object sender, EventArgs e)
        {
            // Mở form Server và đóng dashboard con
            Bai01UDPServerForm serverForm = new Bai01UDPServerForm();
            serverForm.Show();
            this.Close();
        }

        private void btnUDPClient_Click(object sender, EventArgs e)
        {
            // Mở form Client và đóng dashboard con
            Bai01UDPClientForm clientForm = new Bai01UDPClientForm();
            clientForm.Show();
            this.Close();
        }
    }
}
