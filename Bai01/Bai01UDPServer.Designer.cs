namespace Code_NT106.Q14._2_Lab03_Group3_24521557_24520331_24521560_24521538_24521213
{
    partial class Bai01UDPServerForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnListen = new System.Windows.Forms.Button();
            this.lstMessages = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Location = new System.Drawing.Point(100, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(144, 27);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "UDP Server";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(18, 58);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(38, 16);
            this.lblPort.TabIndex = 1;
            this.lblPort.Text = "Port:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(62, 55);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(90, 22);
            this.txtPort.TabIndex = 2;
            // 
            // btnListen
            // 
            this.btnListen.BackColor = System.Drawing.Color.LightBlue;
            this.btnListen.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnListen.ForeColor = System.Drawing.Color.White;
            this.btnListen.Location = new System.Drawing.Point(170, 50);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(126, 32);
            this.btnListen.TabIndex = 3;
            this.btnListen.Text = "Listen";
            this.btnListen.UseVisualStyleBackColor = false;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // lstMessages
            // 
            this.lstMessages.FormattingEnabled = true;
            this.lstMessages.ItemHeight = 16;
            this.lstMessages.Location = new System.Drawing.Point(20, 100);
            this.lstMessages.Name = "lstMessages";
            this.lstMessages.Size = new System.Drawing.Size(276, 324);
            this.lstMessages.TabIndex = 4;
            // 
            // Bai01UDPServerForm
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(320, 450);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.btnListen);
            this.Controls.Add(this.lstMessages);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Bai01UDPServerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UDP Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Bai01UDPServerForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.ListBox lstMessages;
    }
}
