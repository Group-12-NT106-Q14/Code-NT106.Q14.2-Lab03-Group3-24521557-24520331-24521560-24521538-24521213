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
            this.btnOpenServer = new Button();
            this.btnOpenClient = new Button();
            this.SuspendLayout();

            // btnOpenServer
            this.btnOpenServer.Location = new System.Drawing.Point(30, 32);
            this.btnOpenServer.Size = new System.Drawing.Size(320, 40);
            this.btnOpenServer.Text = "Open TCP Server";
            this.btnOpenServer.Click += new System.EventHandler(this.btnOpenServer_Click);

            // btnOpenClient
            this.btnOpenClient.Location = new System.Drawing.Point(30, 90);
            this.btnOpenClient.Size = new System.Drawing.Size(320, 40);
            this.btnOpenClient.Text = "Open new TCP client";
            this.btnOpenClient.Click += new System.EventHandler(this.btnOpenClient_Click);

            // Form
            this.ClientSize = new System.Drawing.Size(380, 170);
            this.Controls.Add(this.btnOpenServer);
            this.Controls.Add(this.btnOpenClient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lab03_Bai03";
            this.ResumeLayout(false);
        }
    }
}
