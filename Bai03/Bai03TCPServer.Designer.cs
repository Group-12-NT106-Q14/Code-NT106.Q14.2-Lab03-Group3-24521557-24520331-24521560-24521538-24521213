namespace Code_NT106.Q14._2_Lab03_Group3_24521557_24520331_24521560_24521538_24521213
{
    partial class Bai03TCPServerForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnListen;
        private TextBox txtMessages;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnListen = new Button();
            this.txtMessages = new TextBox();
            this.SuspendLayout();

            this.btnListen.Location = new System.Drawing.Point(380, 18);
            this.btnListen.Size = new System.Drawing.Size(100, 34);
            this.btnListen.Text = "Listen";
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);

            this.txtMessages.Location = new System.Drawing.Point(20, 65);
            this.txtMessages.Multiline = true;
            this.txtMessages.Size = new System.Drawing.Size(460, 260);
            this.txtMessages.Font = new System.Drawing.Font("Consolas", 11F);
            this.txtMessages.ScrollBars = ScrollBars.Vertical;

            this.ClientSize = new System.Drawing.Size(500, 350);
            this.Controls.Add(this.btnListen);
            this.Controls.Add(this.txtMessages);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Bai03 - TCP Server";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
