namespace Code_NT106.Q14._2_Lab03_Group3_24521557_24520331_24521560_24521538_24521213
{
    partial class Bai01UDPClientForm
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
            this.lblRemoteIp = new System.Windows.Forms.Label();
            this.txtRemoteIp = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Location = new System.Drawing.Point(100, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(129, 27);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "UDP Client";
            // 
            // lblRemoteIp
            // 
            this.lblRemoteIp.AutoSize = true;
            this.lblRemoteIp.Location = new System.Drawing.Point(15, 60);
            this.lblRemoteIp.Name = "lblRemoteIp";
            this.lblRemoteIp.Size = new System.Drawing.Size(71, 16);
            this.lblRemoteIp.TabIndex = 1;
            this.lblRemoteIp.Text = "IP Remote:";
            // 
            // txtRemoteIp
            // 
            this.txtRemoteIp.Location = new System.Drawing.Point(92, 57);
            this.txtRemoteIp.Name = "txtRemoteIp";
            this.txtRemoteIp.Size = new System.Drawing.Size(180, 22);
            this.txtRemoteIp.TabIndex = 2;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(15, 95);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(38, 16);
            this.lblPort.TabIndex = 3;
            this.lblPort.Text = "Port:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(92, 92);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 22);
            this.txtPort.TabIndex = 4;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(15, 130);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(64, 16);
            this.lblMessage.TabIndex = 5;
            this.lblMessage.Text = "Message:";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(18, 155);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(254, 180);
            this.txtMessage.TabIndex = 6;
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.LightBlue;
            this.btnSend.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Location = new System.Drawing.Point(18, 350);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(254, 38);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // Bai01UDPClientForm
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(290, 410);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblRemoteIp);
            this.Controls.Add(this.txtRemoteIp);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnSend);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Bai01UDPClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UDP Client";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRemoteIp;
        private System.Windows.Forms.TextBox txtRemoteIp;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
    }
}
