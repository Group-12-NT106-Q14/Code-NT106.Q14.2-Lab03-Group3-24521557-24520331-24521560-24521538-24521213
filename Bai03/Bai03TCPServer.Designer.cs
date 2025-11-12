namespace Code_NT106.Q14._2_Lab03_Group3_24521557_24520331_24521560_24521538_24521213
{
    partial class Bai03TCPServerForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.TextBox txtLog;

        private void InitializeComponent()
        {
            btnListen = new Button();
            txtLog = new TextBox();
            SuspendLayout();
            // 
            // btnListen
            // 
            btnListen.Location = new Point(30, 20);
            btnListen.Name = "btnListen";
            btnListen.Size = new Size(180, 36);
            btnListen.TabIndex = 0;
            btnListen.Text = "Listen (Bắt đầu Server)";
            btnListen.Click += btnListen_Click;
            // 
            // txtLog
            // 
            txtLog.Location = new Point(30, 70);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(440, 250);
            txtLog.TabIndex = 1;
            // 
            // Bai03TCPServerForm
            // 
            ClientSize = new Size(500, 350);
            Controls.Add(btnListen);
            Controls.Add(txtLog);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Bai03TCPServerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bài 03 - TCP Server";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
