namespace Code_NT106.Q14._2_Lab03_Group3_24521557_24520331_24521560_24521538_24521213
{
    partial class Bai03TCPServerForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.TextBox txtLog;

        private void InitializeComponent()
        {
            this.btnListen = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();

            this.btnListen.Location = new System.Drawing.Point(30, 20);
            this.btnListen.Size = new System.Drawing.Size(180, 36);
            this.btnListen.Text = "Listen (Bắt đầu Server)";
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);

            this.txtLog.Location = new System.Drawing.Point(30, 70);
            this.txtLog.Multiline = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(440, 250);
            this.txtLog.ReadOnly = true;

            this.Controls.Add(this.btnListen);
            this.Controls.Add(this.txtLog);

            this.ClientSize = new System.Drawing.Size(500, 350);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Text = "TCP Server Bài 3";
        }
    }
}
