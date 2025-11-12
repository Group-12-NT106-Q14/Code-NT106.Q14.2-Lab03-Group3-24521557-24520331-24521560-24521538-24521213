namespace Code_NT106.Q14._2_Lab03_Group3_24521557_24520331_24521560_24521538_24521213
{
    partial class Bai03TCPClientForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.TextBox txtMessage, txtServerIP, txtResponse, txtLog;
        private System.Windows.Forms.Label lblServerIP, lblMsg, lblResp;
        private System.Windows.Forms.Button btnConnect, btnSend, btnDisconnect;

        private void InitializeComponent()
        {
            txtServerIP = new TextBox();
            lblServerIP = new Label();
            txtMessage = new TextBox();
            txtResponse = new TextBox();
            txtLog = new TextBox();
            lblMsg = new Label();
            lblResp = new Label();
            btnConnect = new Button();
            btnSend = new Button();
            btnDisconnect = new Button();
            SuspendLayout();
            // 
            // txtServerIP
            // 
            txtServerIP.Font = new Font("Segoe UI", 12F);
            txtServerIP.Location = new Point(130, 25);
            txtServerIP.Name = "txtServerIP";
            txtServerIP.Size = new Size(220, 34);
            txtServerIP.TabIndex = 1;
            txtServerIP.Text = "127.0.0.1";
            // 
            // lblServerIP
            // 
            lblServerIP.Font = new Font("Segoe UI", 12F);
            lblServerIP.Location = new Point(30, 28);
            lblServerIP.Name = "lblServerIP";
            lblServerIP.Size = new Size(90, 28);
            lblServerIP.TabIndex = 0;
            lblServerIP.Text = "IP server:";
            // 
            // txtMessage
            // 
            txtMessage.Font = new Font("Segoe UI", 12F);
            txtMessage.Location = new Point(130, 75);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(350, 34);
            txtMessage.TabIndex = 3;
            // 
            // txtResponse
            // 
            txtResponse.Font = new Font("Segoe UI", 12F);
            txtResponse.Location = new Point(130, 122);
            txtResponse.Name = "txtResponse";
            txtResponse.ReadOnly = true;
            txtResponse.Size = new Size(350, 34);
            txtResponse.TabIndex = 5;
            // 
            // txtLog
            // 
            txtLog.Font = new Font("Consolas", 11F);
            txtLog.Location = new Point(30, 170);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(560, 180);
            txtLog.TabIndex = 9;
            // 
            // lblMsg
            // 
            lblMsg.Font = new Font("Segoe UI", 12F);
            lblMsg.Location = new Point(30, 75);
            lblMsg.Name = "lblMsg";
            lblMsg.Size = new Size(90, 28);
            lblMsg.TabIndex = 2;
            lblMsg.Text = "Message:";
            // 
            // lblResp
            // 
            lblResp.Font = new Font("Segoe UI", 12F);
            lblResp.Location = new Point(30, 122);
            lblResp.Name = "lblResp";
            lblResp.Size = new Size(90, 28);
            lblResp.TabIndex = 4;
            lblResp.Text = "Response:";
            // 
            // btnConnect
            // 
            btnConnect.Font = new Font("Segoe UI", 12F);
            btnConnect.Location = new Point(370, 25);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(110, 44);
            btnConnect.TabIndex = 6;
            btnConnect.Text = "Connect";
            btnConnect.Click += btnConnect_Click;
            // 
            // btnSend
            // 
            btnSend.Font = new Font("Segoe UI", 12F);
            btnSend.Location = new Point(500, 72);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(105, 37);
            btnSend.TabIndex = 7;
            btnSend.Text = "Send";
            btnSend.Click += btnSend_Click;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Font = new Font("Segoe UI", 12F);
            btnDisconnect.Location = new Point(500, 122);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(118, 32);
            btnDisconnect.TabIndex = 8;
            btnDisconnect.Text = "Disconnect";
            btnDisconnect.Click += btnDisconnect_Click;
            // 
            // Bai03TCPClientForm
            // 
            ClientSize = new Size(630, 380);
            Controls.Add(lblServerIP);
            Controls.Add(txtServerIP);
            Controls.Add(lblMsg);
            Controls.Add(txtMessage);
            Controls.Add(lblResp);
            Controls.Add(txtResponse);
            Controls.Add(btnConnect);
            Controls.Add(btnSend);
            Controls.Add(btnDisconnect);
            Controls.Add(txtLog);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Bai03TCPClientForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bài 03 - TCP Client ";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
