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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnUDPServer = new System.Windows.Forms.Button();
            this.btnUDPClient = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Location = new System.Drawing.Point(100, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Bài 01 - UDP";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnUDPServer
            // 
            this.btnUDPServer.BackColor = System.Drawing.Color.LightBlue;
            this.btnUDPServer.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnUDPServer.ForeColor = System.Drawing.Color.White;
            this.btnUDPServer.Location = new System.Drawing.Point(40, 80);
            this.btnUDPServer.Name = "btnUDPServer";
            this.btnUDPServer.Size = new System.Drawing.Size(130, 50);
            this.btnUDPServer.TabIndex = 1;
            this.btnUDPServer.Text = "UDP Server";
            this.btnUDPServer.UseVisualStyleBackColor = false;
            this.btnUDPServer.Click += new System.EventHandler(this.btnUDPServer_Click);
            // 
            // btnUDPClient
            // 
            this.btnUDPClient.BackColor = System.Drawing.Color.LightBlue;
            this.btnUDPClient.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnUDPClient.ForeColor = System.Drawing.Color.White;
            this.btnUDPClient.Location = new System.Drawing.Point(210, 80);
            this.btnUDPClient.Name = "btnUDPClient";
            this.btnUDPClient.Size = new System.Drawing.Size(130, 50);
            this.btnUDPClient.TabIndex = 2;
            this.btnUDPClient.Text = "UDP Client";
            this.btnUDPClient.UseVisualStyleBackColor = false;
            this.btnUDPClient.Click += new System.EventHandler(this.btnUDPClient_Click);
            // 
            // Bai01DashboardForm
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(384, 181);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnUDPServer);
            this.Controls.Add(this.btnUDPClient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Bai01DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bài 01 - UDP";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnUDPServer;
        private System.Windows.Forms.Button btnUDPClient;
    }
}