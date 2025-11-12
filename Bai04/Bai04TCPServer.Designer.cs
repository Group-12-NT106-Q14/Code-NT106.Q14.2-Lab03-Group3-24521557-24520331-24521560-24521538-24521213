namespace Code_NT106.Q14._2_Lab03_Group3_24521557_24520331_24521560_24521538_24521213
{
    partial class Bai04TCPServerForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnLoadFile, btnExportReport, btnStartServer;
        private System.Windows.Forms.TextBox txtLog;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            btnLoadFile = new Button();
            btnExportReport = new Button();
            btnStartServer = new Button();
            txtLog = new TextBox();
            SuspendLayout();
            // 
            // btnLoadFile
            // 
            btnLoadFile.Location = new Point(16, 18);
            btnLoadFile.Name = "btnLoadFile";
            btnLoadFile.Size = new Size(120, 36);
            btnLoadFile.TabIndex = 0;
            btnLoadFile.Text = "Đọc file phim";
            btnLoadFile.Click += btnLoadFile_Click;
            // 
            // btnExportReport
            // 
            btnExportReport.Location = new Point(146, 18);
            btnExportReport.Name = "btnExportReport";
            btnExportReport.Size = new Size(140, 36);
            btnExportReport.TabIndex = 1;
            btnExportReport.Text = "Xuất báo cáo";
            btnExportReport.Click += btnExportReport_Click;
            // 
            // btnStartServer
            // 
            btnStartServer.Enabled = false;
            btnStartServer.Location = new Point(300, 18);
            btnStartServer.Name = "btnStartServer";
            btnStartServer.Size = new Size(140, 36);
            btnStartServer.TabIndex = 2;
            btnStartServer.Text = "Start Server";
            btnStartServer.Click += btnStartServer_Click;
            // 
            // txtLog
            // 
            txtLog.Location = new Point(16, 68);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(424, 280);
            txtLog.TabIndex = 3;
            // 
            // Bai04TCPServerForm
            // 
            ClientSize = new Size(460, 370);
            Controls.Add(btnLoadFile);
            Controls.Add(btnExportReport);
            Controls.Add(btnStartServer);
            Controls.Add(txtLog);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Bai04TCPServerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bài 04 - TCP Server";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
