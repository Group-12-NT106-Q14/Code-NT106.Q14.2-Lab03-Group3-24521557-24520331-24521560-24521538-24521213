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
            lblTitle = new Label();
            lblPort = new Label();
            txtPort = new TextBox();
            btnListen = new Button();
            lstMessages = new ListBox();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Navy;
            lblTitle.Location = new Point(170, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(165, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "UDP Server";
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Font = new Font("Arial", 11F);
            lblPort.Location = new Point(27, 64);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(50, 22);
            lblPort.TabIndex = 1;
            lblPort.Text = "Port:";
            // 
            // txtPort
            // 
            txtPort.Font = new Font("Arial", 11F);
            txtPort.Location = new Point(73, 60);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(110, 29);
            txtPort.TabIndex = 2;
            // 
            // btnListen
            // 
            btnListen.BackColor = Color.LightBlue;
            btnListen.Font = new Font("Arial", 11F, FontStyle.Bold);
            btnListen.ForeColor = Color.White;
            btnListen.Location = new Point(210, 56);
            btnListen.Name = "btnListen";
            btnListen.Size = new Size(150, 38);
            btnListen.TabIndex = 3;
            btnListen.Text = "Listen";
            btnListen.UseVisualStyleBackColor = false;
            btnListen.Click += btnListen_Click;
            // 
            // lstMessages
            // 
            lstMessages.Font = new Font("Consolas", 12F);
            lstMessages.FormattingEnabled = true;
            lstMessages.ItemHeight = 23;
            lstMessages.Location = new Point(20, 110);
            lstMessages.Name = "lstMessages";
            lstMessages.Size = new Size(450, 326);
            lstMessages.TabIndex = 4;
            // 
            // Bai01UDPServerForm
            // 
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(490, 470);
            Controls.Add(lblTitle);
            Controls.Add(lblPort);
            Controls.Add(txtPort);
            Controls.Add(btnListen);
            Controls.Add(lstMessages);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Bai01UDPServerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bài 01 - UDP Server";
            FormClosing += Bai01UDPServerForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.ListBox lstMessages;
    }
}
