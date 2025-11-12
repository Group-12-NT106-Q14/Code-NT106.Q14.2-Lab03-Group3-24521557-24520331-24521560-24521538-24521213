namespace Code_NT106.Q14._2_Lab03_Group3_24521557_24520331_24521560_24521538_24521213
{
    partial class Bai05TCPServer
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.ListBox lstLog;
        private void InitializeComponent()
        {
            btnStartServer = new Button();
            lstLog = new ListBox();
            SuspendLayout();
            // 
            // btnStartServer
            // 
            btnStartServer.Location = new Point(18, 20);
            btnStartServer.Name = "btnStartServer";
            btnStartServer.Size = new Size(160, 36);
            btnStartServer.TabIndex = 0;
            btnStartServer.Text = "Khởi động Server";
            btnStartServer.UseVisualStyleBackColor = true;
            btnStartServer.Click += btnStartServer_Click;
            // 
            // lstLog
            // 
            lstLog.Font = new Font("Consolas", 11F);
            lstLog.FormattingEnabled = true;
            lstLog.ItemHeight = 22;
            lstLog.Location = new Point(18, 70);
            lstLog.Name = "lstLog";
            lstLog.Size = new Size(480, 290);
            lstLog.TabIndex = 1;
            // 
            // Bai05TCPServer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(524, 400);
            Controls.Add(btnStartServer);
            Controls.Add(lstLog);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Bai05TCPServer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bài 05 - TCP Server";
            ResumeLayout(false);
        }
    }
}
