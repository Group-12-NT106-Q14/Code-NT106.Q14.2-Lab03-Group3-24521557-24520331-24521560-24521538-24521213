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

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Location = new System.Drawing.Point(170, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(163, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "UDP Client";

            // lblRemoteIp
            this.lblRemoteIp.AutoSize = true;
            this.lblRemoteIp.Font = new System.Drawing.Font("Arial", 11F);
            this.lblRemoteIp.Location = new System.Drawing.Point(30, 70);
            this.lblRemoteIp.Name = "lblRemoteIp";
            this.lblRemoteIp.Size = new System.Drawing.Size(95, 22);
            this.lblRemoteIp.TabIndex = 1;
            this.lblRemoteIp.Text = "IP Server:";

            // txtRemoteIp
            this.txtRemoteIp.Font = new System.Drawing.Font("Arial", 11F);
            this.txtRemoteIp.Location = new System.Drawing.Point(130, 66);
            this.txtRemoteIp.Name = "txtRemoteIp";
            this.txtRemoteIp.Size = new System.Drawing.Size(260, 28);
            this.txtRemoteIp.TabIndex = 2;

            // lblPort
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("Arial", 11F);
            this.lblPort.Location = new System.Drawing.Point(30, 115);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(45, 22);
            this.lblPort.TabIndex = 3;
            this.lblPort.Text = "Port:";

            // txtPort
            this.txtPort.Font = new System.Drawing.Font("Arial", 11F);
            this.txtPort.Location = new System.Drawing.Point(130, 111);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 28);
            this.txtPort.TabIndex = 4;

            // lblMessage
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Arial", 11F);
            this.lblMessage.Location = new System.Drawing.Point(30, 160);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(90, 22);
            this.lblMessage.TabIndex = 5;
            this.lblMessage.Text = "Message:";

            // txtMessage
            this.txtMessage.Font = new System.Drawing.Font("Consolas", 12F);
            this.txtMessage.Location = new System.Drawing.Point(33, 190);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(400, 170);
            this.txtMessage.TabIndex = 6;

            // btnSend
            this.btnSend.BackColor = System.Drawing.Color.LightBlue;
            this.btnSend.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Location = new System.Drawing.Point(33, 380);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(400, 42);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);

            // Bai01UDPClientForm
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(470, 450);
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
