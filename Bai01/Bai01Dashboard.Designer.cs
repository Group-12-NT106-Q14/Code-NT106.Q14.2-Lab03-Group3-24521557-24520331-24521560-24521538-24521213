namespace Code_NT106.Q14._2_Lab03_Group3_24521557_24520331_24521560_24521538_24521213
{
    partial class Bai01DashboardForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnUDPServer = new Button();
            btnUDPClient = new Button();
            SuspendLayout();
            // 
            // btnUDPServer
            // 
            btnUDPServer.BackColor = Color.LightBlue;
            btnUDPServer.Font = new Font("Arial", 12F, FontStyle.Bold);
            btnUDPServer.ForeColor = Color.White;
            btnUDPServer.Location = new Point(42, 58);
            btnUDPServer.Name = "btnUDPServer";
            btnUDPServer.Size = new Size(130, 50);
            btnUDPServer.TabIndex = 1;
            btnUDPServer.Text = "UDP Server";
            btnUDPServer.UseVisualStyleBackColor = false;
            btnUDPServer.Click += btnUDPServer_Click;
            // 
            // btnUDPClient
            // 
            btnUDPClient.BackColor = Color.LightBlue;
            btnUDPClient.Font = new Font("Arial", 12F, FontStyle.Bold);
            btnUDPClient.ForeColor = Color.White;
            btnUDPClient.Location = new Point(212, 58);
            btnUDPClient.Name = "btnUDPClient";
            btnUDPClient.Size = new Size(130, 50);
            btnUDPClient.TabIndex = 2;
            btnUDPClient.Text = "UDP Client";
            btnUDPClient.UseVisualStyleBackColor = false;
            btnUDPClient.Click += btnUDPClient_Click;
            // 
            // Bai01DashboardForm
            // 
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(384, 181);
            Controls.Add(btnUDPServer);
            Controls.Add(btnUDPClient);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Bai01DashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bài 01 - UDP";
            ResumeLayout(false);
        }
        private System.Windows.Forms.Button btnUDPServer;
        private System.Windows.Forms.Button btnUDPClient;
    }
}