namespace Code_NT106.Q14._2_Lab03_Group3_24521557_24520331_24521560_24521538_24521213
{
    partial class Bai03TCPClientForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtMessage;
        private Button btnConnect, btnSend, btnDisconnect;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtMessage = new TextBox();
            this.btnConnect = new Button();
            this.btnSend = new Button();
            this.btnDisconnect = new Button();
            this.SuspendLayout();

            this.txtMessage.Location = new System.Drawing.Point(25, 20);
            this.txtMessage.Size = new System.Drawing.Size(200, 60);
            this.txtMessage.Multiline = true;
            this.txtMessage.Font = new System.Drawing.Font("Consolas", 12F);

            this.btnConnect.Location = new System.Drawing.Point(250, 20);
            this.btnConnect.Size = new System.Drawing.Size(90, 34);
            this.btnConnect.Text = "Connect";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);

            this.btnSend.Location = new System.Drawing.Point(250, 60);
            this.btnSend.Size = new System.Drawing.Size(90, 34);
            this.btnSend.Text = "Send";
            this.btnSend.Enabled = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);

            this.btnDisconnect.Location = new System.Drawing.Point(250, 100);
            this.btnDisconnect.Size = new System.Drawing.Size(90, 34);
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);

            this.ClientSize = new System.Drawing.Size(370, 160);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnDisconnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Bai03 - TCP Client";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
