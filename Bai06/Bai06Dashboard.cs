using System;
using System.Windows.Forms;

namespace Code_NT106.Q14._2_Lab03_Group3_24521557_24520331_24521560_24521538_24521213
{
    public partial class Bai06Dashboard : Form
    {
        public Bai06Dashboard()
        {
            InitializeComponent();
        }

        private void btnOpenServer_Click(object sender, EventArgs e)
        {
            var serverForm = new Bai06TCPServer();
            serverForm.Show();
        }

        private void btnOpenClient_Click(object sender, EventArgs e)
        {
            var clientForm = new Bai06TCPClient();
            clientForm.Show();
        }
    }
}
