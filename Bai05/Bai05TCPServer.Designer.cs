namespace Code_NT106.Q14._2_Lab03_Group3_24521557_24520331_24521560_24521538_24521213
{
    partial class Bai05TCPServer
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.ListBox lstLog;
        private void InitializeComponent()
        {
            this.btnStartServer = new System.Windows.Forms.Button();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            //
            this.btnStartServer.Location = new System.Drawing.Point(20, 20);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(180, 36);
            this.btnStartServer.TabIndex = 0;
            this.btnStartServer.Text = "Khởi động Server";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            //
            this.lstLog.Font = new System.Drawing.Font("Consolas", 11F);
            this.lstLog.FormattingEnabled = true;
            this.lstLog.ItemHeight = 26;
            this.lstLog.Location = new System.Drawing.Point(20, 70);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(540, 290);
            this.lstLog.TabIndex = 1;
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 400);
            this.Controls.Add(this.btnStartServer);
            this.Controls.Add(this.lstLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Bai05TCPServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bai05TCPServer - Server Hôm nay ăn gì?";
            this.ResumeLayout(false);
        }
    }
}
