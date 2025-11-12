namespace Code_NT106.Q14._2_Lab03_Group3_24521557_24520331_24521560_24521538_24521213
{
    partial class Bai06TCPClient
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtIpServer;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.RichTextBox richTextBoxChat;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ListBox listBoxParticipants;
        private System.Windows.Forms.Label lblOnlineCount;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblIp;
        private System.Windows.Forms.Label lblParticipants;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblName = new Label();
            txtName = new TextBox();
            lblIp = new Label();
            txtIpServer = new TextBox();
            btnConnect = new Button();
            richTextBoxChat = new RichTextBox();
            txtMessage = new TextBox();
            btnSend = new Button();
            listBoxParticipants = new ListBox();
            lblOnlineCount = new Label();
            lblParticipants = new Label();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(20, 23);
            lblName.Name = "lblName";
            lblName.Size = new Size(35, 20);
            lblName.TabIndex = 0;
            lblName.Text = "Tên:";
            // 
            // txtName
            // 
            txtName.Location = new Point(65, 20);
            txtName.Name = "txtName";
            txtName.Size = new Size(120, 27);
            txtName.TabIndex = 1;
            // 
            // lblIp
            // 
            lblIp.AutoSize = true;
            lblIp.Location = new Point(200, 23);
            lblIp.Name = "lblIp";
            lblIp.Size = new Size(67, 20);
            lblIp.TabIndex = 2;
            lblIp.Text = "IP server:";
            // 
            // txtIpServer
            // 
            txtIpServer.Location = new Point(276, 20);
            txtIpServer.Name = "txtIpServer";
            txtIpServer.Size = new Size(130, 27);
            txtIpServer.TabIndex = 3;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(420, 16);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(100, 32);
            btnConnect.TabIndex = 4;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // richTextBoxChat
            // 
            richTextBoxChat.Location = new Point(20, 60);
            richTextBoxChat.Name = "richTextBoxChat";
            richTextBoxChat.ReadOnly = true;
            richTextBoxChat.Size = new Size(500, 250);
            richTextBoxChat.TabIndex = 6;
            richTextBoxChat.Text = "";
            // 
            // txtMessage
            // 
            txtMessage.Enabled = false;
            txtMessage.Location = new Point(20, 320);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(360, 50);
            txtMessage.TabIndex = 7;
            txtMessage.KeyDown += txtMessage_KeyDown;
            // 
            // btnSend
            // 
            btnSend.Enabled = false;
            btnSend.Location = new Point(390, 320);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(60, 50);
            btnSend.TabIndex = 8;
            btnSend.Text = "Gửi";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // listBoxParticipants
            // 
            listBoxParticipants.FormattingEnabled = true;
            listBoxParticipants.Location = new Point(540, 90);
            listBoxParticipants.Name = "listBoxParticipants";
            listBoxParticipants.Size = new Size(160, 144);
            listBoxParticipants.TabIndex = 11;
            // 
            // lblOnlineCount
            // 
            lblOnlineCount.AutoSize = true;
            lblOnlineCount.Font = new Font("Segoe UI", 10F);
            lblOnlineCount.Location = new Point(540, 22);
            lblOnlineCount.Name = "lblOnlineCount";
            lblOnlineCount.Size = new Size(78, 23);
            lblOnlineCount.TabIndex = 5;
            lblOnlineCount.Text = "Online: 0";
            // 
            // lblParticipants
            // 
            lblParticipants.AutoSize = true;
            lblParticipants.Location = new Point(540, 60);
            lblParticipants.Name = "lblParticipants";
            lblParticipants.Size = new Size(83, 20);
            lblParticipants.TabIndex = 10;
            lblParticipants.Text = "Thành viên:";
            // 
            // Bai06TCPClient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(730, 400);
            Controls.Add(listBoxParticipants);
            Controls.Add(lblParticipants);
            Controls.Add(lblOnlineCount);
            Controls.Add(btnSend);
            Controls.Add(txtMessage);
            Controls.Add(richTextBoxChat);
            Controls.Add(btnConnect);
            Controls.Add(txtIpServer);
            Controls.Add(lblIp);
            Controls.Add(txtName);
            Controls.Add(lblName);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Bai06TCPClient";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bài 06 - TCP Client";
            FormClosing += Bai06TCPClient_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
