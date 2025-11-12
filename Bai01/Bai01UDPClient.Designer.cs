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
            lblTitle = new Label();
            lblRemoteIp = new Label();
            txtRemoteIp = new TextBox();
            lblPort = new Label();
            txtPort = new TextBox();
            lblMessage = new Label();
            txtMessage = new TextBox();
            btnSend = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Navy;
            lblTitle.Location = new Point(170, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(157, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "UDP Client";
            // 
            // lblRemoteIp
            // 
            lblRemoteIp.AutoSize = true;
            lblRemoteIp.Font = new Font("Arial", 11F);
            lblRemoteIp.Location = new Point(30, 70);
            lblRemoteIp.Name = "lblRemoteIp";
            lblRemoteIp.Size = new Size(95, 22);
            lblRemoteIp.TabIndex = 1;
            lblRemoteIp.Text = "IP Server:";
            // 
            // txtRemoteIp
            // 
            txtRemoteIp.Font = new Font("Arial", 11F);
            txtRemoteIp.Location = new Point(130, 66);
            txtRemoteIp.Name = "txtRemoteIp";
            txtRemoteIp.Size = new Size(260, 29);
            txtRemoteIp.TabIndex = 2;
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Font = new Font("Arial", 11F);
            lblPort.Location = new Point(30, 115);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(50, 22);
            lblPort.TabIndex = 3;
            lblPort.Text = "Port:";
            // 
            // txtPort
            // 
            txtPort.Font = new Font("Arial", 11F);
            txtPort.Location = new Point(130, 111);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(100, 29);
            txtPort.TabIndex = 4;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Font = new Font("Arial", 11F);
            lblMessage.Location = new Point(30, 160);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(93, 22);
            lblMessage.TabIndex = 5;
            lblMessage.Text = "Message:";
            // 
            // txtMessage
            // 
            txtMessage.Font = new Font("Consolas", 12F);
            txtMessage.Location = new Point(33, 190);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.ScrollBars = ScrollBars.Vertical;
            txtMessage.Size = new Size(400, 170);
            txtMessage.TabIndex = 6;
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.LightBlue;
            btnSend.Font = new Font("Arial", 12F, FontStyle.Bold);
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(33, 380);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(400, 42);
            btnSend.TabIndex = 7;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // Bai01UDPClientForm
            // 
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(470, 450);
            Controls.Add(lblTitle);
            Controls.Add(lblRemoteIp);
            Controls.Add(txtRemoteIp);
            Controls.Add(lblPort);
            Controls.Add(txtPort);
            Controls.Add(lblMessage);
            Controls.Add(txtMessage);
            Controls.Add(btnSend);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Bai01UDPClientForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bài 01 - UDP Client";
            ResumeLayout(false);
            PerformLayout();
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
