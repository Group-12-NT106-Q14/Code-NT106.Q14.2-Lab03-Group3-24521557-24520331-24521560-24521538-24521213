namespace Code_NT106.Q14._2_Lab03_Group3_24521557_24520331_24521560_24521538_24521213
{
    partial class Bai04DashboardForm
    {
        private Button btnOpenServer, btnOpenClient;
        private void InitializeComponent()
        {
            btnOpenServer = new Button();
            btnOpenClient = new Button();
            SuspendLayout();
            btnOpenServer.Location = new System.Drawing.Point(30, 32);
            btnOpenServer.Size = new System.Drawing.Size(320, 40);
            btnOpenServer.Text = "Open TCP Server";
            btnOpenServer.Click += btnOpenServer_Click;

            btnOpenClient.Location = new System.Drawing.Point(30, 90);
            btnOpenClient.Size = new System.Drawing.Size(320, 40);
            btnOpenClient.Text = "Open new TCP Client";
            btnOpenClient.Click += btnOpenClient_Click;

            this.ClientSize = new System.Drawing.Size(380, 170);
            this.Controls.Add(btnOpenServer);
            this.Controls.Add(btnOpenClient);

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Lab04_Bai04 Dashboard";
            this.ResumeLayout(false);
        }
    }
}
