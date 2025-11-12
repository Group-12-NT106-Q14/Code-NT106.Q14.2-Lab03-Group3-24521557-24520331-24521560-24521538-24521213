namespace Code_NT106.Q14._2_Lab03_Group3_24521557_24520331_24521560_24521538_24521213
{
    partial class Bai03DashboardForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnOpenServer, btnOpenClient;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnOpenServer = new Button();
            btnOpenClient = new Button();
            SuspendLayout();
            // 
            // btnOpenServer
            // 
            btnOpenServer.Location = new Point(30, 32);
            btnOpenServer.Name = "btnOpenServer";
            btnOpenServer.Size = new Size(320, 40);
            btnOpenServer.TabIndex = 0;
            btnOpenServer.Text = "Open TCP Server";
            btnOpenServer.Click += btnOpenServer_Click;
            // 
            // btnOpenClient
            // 
            btnOpenClient.Location = new Point(30, 90);
            btnOpenClient.Name = "btnOpenClient";
            btnOpenClient.Size = new Size(320, 40);
            btnOpenClient.TabIndex = 1;
            btnOpenClient.Text = "Open new TCP client";
            btnOpenClient.Click += btnOpenClient_Click;
            // 
            // Bai03DashboardForm
            // 
            ClientSize = new Size(380, 170);
            Controls.Add(btnOpenServer);
            Controls.Add(btnOpenClient);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Bai03DashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bài 03 - Dashboard";
            ResumeLayout(false);
        }
    }
}
