using System;
using System.Windows.Forms;

namespace Code_NT106.Q14._2_Lab03_Group3_24521557_24520331_24521560_24521538_24521213
{
    public partial class Bai05Dashboard : Form
    {
        public Bai05Dashboard()
        {
            InitializeComponent();
        }
        private void btnServer_Click(object sender, EventArgs e) => new Bai05TCPServer().Show();
        private void btnClient_Click(object sender, EventArgs e) => new Bai05TCPClient().Show();
    }
}
