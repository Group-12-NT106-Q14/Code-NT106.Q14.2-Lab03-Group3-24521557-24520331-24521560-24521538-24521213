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
            btnLoadFile = new System.Windows.Forms.Button();
            btnExportReport = new System.Windows.Forms.Button();
            btnStartServer = new System.Windows.Forms.Button();
            txtLog = new System.Windows.Forms.TextBox();
            SuspendLayout();
            btnLoadFile.Location = new System.Drawing.Point(16, 18);
            btnLoadFile.Size = new System.Drawing.Size(120, 36);
            btnLoadFile.Text = "Đọc file phim";
            btnLoadFile.Click += btnLoadFile_Click;

            btnExportReport.Location = new System.Drawing.Point(146, 18);
            btnExportReport.Size = new System.Drawing.Size(140, 36);
            btnExportReport.Text = "Xuất báo cáo";
            btnExportReport.Click += btnExportReport_Click;

            btnStartServer.Location = new System.Drawing.Point(300, 18);
            btnStartServer.Size = new System.Drawing.Size(140, 36);
            btnStartServer.Text = "Start Server";
            btnStartServer.Click += btnStartServer_Click;
            btnStartServer.Enabled = false;

            txtLog.Location = new System.Drawing.Point(16, 68);
            txtLog.Size = new System.Drawing.Size(424, 280);
            txtLog.Multiline = true;
            txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtLog.ReadOnly = true;

            this.ClientSize = new System.Drawing.Size(460, 370);
            this.Controls.Add(btnLoadFile);
            this.Controls.Add(btnExportReport);
            this.Controls.Add(btnStartServer);
            this.Controls.Add(txtLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server - Quản lý phòng vé";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
