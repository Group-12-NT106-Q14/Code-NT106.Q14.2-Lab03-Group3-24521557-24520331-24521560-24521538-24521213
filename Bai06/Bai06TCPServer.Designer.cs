namespace Code_NT106.Q14._2_Lab03_Group3_24521557_24520331_24521560_24521538_24521213
{
    partial class Bai06TCPServer
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtServerLog;
        private System.Windows.Forms.ListBox listBoxParticipants;
        private System.Windows.Forms.Label lblOnlineCount;
        private System.Windows.Forms.Button btnListen;

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
            txtServerLog = new TextBox();
            listBoxParticipants = new ListBox();
            lblOnlineCount = new Label();
            btnListen = new Button();
            SuspendLayout();
            // 
            // txtServerLog
            // 
            txtServerLog.Location = new Point(25, 70);
            txtServerLog.Multiline = true;
            txtServerLog.Name = "txtServerLog";
            txtServerLog.ReadOnly = true;
            txtServerLog.ScrollBars = ScrollBars.Vertical;
            txtServerLog.Size = new Size(420, 330);
            txtServerLog.TabIndex = 0;
            // 
            // listBoxParticipants
            // 
            listBoxParticipants.FormattingEnabled = true;
            listBoxParticipants.Location = new Point(470, 70);
            listBoxParticipants.Name = "listBoxParticipants";
            listBoxParticipants.Size = new Size(180, 324);
            listBoxParticipants.TabIndex = 1;
            // 
            // lblOnlineCount
            // 
            lblOnlineCount.AutoSize = true;
            lblOnlineCount.Font = new Font("Segoe UI", 10F);
            lblOnlineCount.Location = new Point(470, 30);
            lblOnlineCount.Name = "lblOnlineCount";
            lblOnlineCount.Size = new Size(78, 23);
            lblOnlineCount.TabIndex = 2;
            lblOnlineCount.Text = "Online: 0";
            // 
            // btnListen
            // 
            btnListen.Font = new Font("Segoe UI", 12F);
            btnListen.Location = new Point(25, 20);
            btnListen.Name = "btnListen";
            btnListen.Size = new Size(180, 35);
            btnListen.TabIndex = 3;
            btnListen.Text = "Listen";
            btnListen.UseVisualStyleBackColor = true;
            btnListen.Click += btnListen_Click;
            // 
            // Bai06TCPServer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(680, 420);
            Controls.Add(btnListen);
            Controls.Add(lblOnlineCount);
            Controls.Add(listBoxParticipants);
            Controls.Add(txtServerLog);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Bai06TCPServer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bài 06 - TCP Server";
            FormClosing += Bai06TCPServer_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
