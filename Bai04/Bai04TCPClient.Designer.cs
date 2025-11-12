namespace Code_NT106.Q14._2_Lab03_Group3_24521557_24520331_24521560_24521538_24521213
{
    partial class Bai04TCPClientForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnConnect, btnDisconnect, btnCalculate, btnReset, btnExit;
        private System.Windows.Forms.ComboBox cmbMovie, cmbRoom;
        private System.Windows.Forms.TextBox txtCustomerName, txtSelectedSeats, txtTotal, txtResult, txtServerIP;
        private System.Windows.Forms.Label lblCustomerName, lblMovie, lblRoom, lblSelectedSeats, lblTotal, lblResult, lblServerIP;
        private System.Windows.Forms.Panel panelSeats;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            btnConnect = new Button();
            btnDisconnect = new Button();
            btnCalculate = new Button();
            btnReset = new Button();
            btnExit = new Button();
            cmbMovie = new ComboBox();
            cmbRoom = new ComboBox();
            txtCustomerName = new TextBox();
            txtSelectedSeats = new TextBox();
            txtTotal = new TextBox();
            txtResult = new TextBox();
            txtServerIP = new TextBox();
            lblCustomerName = new Label();
            lblMovie = new Label();
            lblRoom = new Label();
            lblSelectedSeats = new Label();
            lblTotal = new Label();
            lblResult = new Label();
            lblServerIP = new Label();
            panelSeats = new Panel();
            SuspendLayout();
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(1240, 20);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(120, 36);
            btnConnect.TabIndex = 0;
            btnConnect.Text = "Kết nối server";
            btnConnect.Click += btnConnect_Click;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Location = new Point(1370, 20);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(120, 36);
            btnDisconnect.TabIndex = 1;
            btnDisconnect.Text = "Ngắt kết nối";
            btnDisconnect.Click += btnDisconnect_Click;
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(1240, 70);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(120, 36);
            btnCalculate.TabIndex = 15;
            btnCalculate.Text = "Đặt vé";
            btnCalculate.Click += btnCalculate_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(1370, 70);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(120, 36);
            btnReset.TabIndex = 16;
            btnReset.Text = "Làm mới";
            btnReset.Click += btnReset_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(1240, 420);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(250, 35);
            btnExit.TabIndex = 19;
            btnExit.Text = "Thoát";
            btnExit.Click += btnExit_Click;
            // 
            // cmbMovie
            // 
            cmbMovie.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMovie.DropDownWidth = 800;
            cmbMovie.Location = new Point(130, 67);
            cmbMovie.MaxDropDownItems = 15;
            cmbMovie.Name = "cmbMovie";
            cmbMovie.Size = new Size(600, 28);
            cmbMovie.TabIndex = 5;
            cmbMovie.SelectedIndexChanged += cmbMovie_SelectedIndexChanged;
            // 
            // cmbRoom
            // 
            cmbRoom.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoom.Enabled = false;
            cmbRoom.Location = new Point(130, 107);
            cmbRoom.Name = "cmbRoom";
            cmbRoom.Size = new Size(180, 28);
            cmbRoom.TabIndex = 7;
            cmbRoom.SelectedIndexChanged += cmbRoom_SelectedIndexChanged;
            // 
            // txtCustomerName
            // 
            txtCustomerName.Location = new Point(130, 27);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(300, 27);
            txtCustomerName.TabIndex = 3;
            // 
            // txtSelectedSeats
            // 
            txtSelectedSeats.Location = new Point(925, 27);
            txtSelectedSeats.Name = "txtSelectedSeats";
            txtSelectedSeats.ReadOnly = true;
            txtSelectedSeats.Size = new Size(300, 27);
            txtSelectedSeats.TabIndex = 9;
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(925, 67);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(300, 27);
            txtTotal.TabIndex = 11;
            // 
            // txtResult
            // 
            txtResult.Location = new Point(1240, 180);
            txtResult.Multiline = true;
            txtResult.Name = "txtResult";
            txtResult.ReadOnly = true;
            txtResult.ScrollBars = ScrollBars.Vertical;
            txtResult.Size = new Size(250, 230);
            txtResult.TabIndex = 18;
            // 
            // txtServerIP
            // 
            txtServerIP.Location = new Point(870, 107);
            txtServerIP.Name = "txtServerIP";
            txtServerIP.Size = new Size(160, 27);
            txtServerIP.TabIndex = 13;
            txtServerIP.Text = "127.0.0.1";
            // 
            // lblCustomerName
            // 
            lblCustomerName.Location = new Point(25, 30);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(99, 25);
            lblCustomerName.TabIndex = 2;
            lblCustomerName.Text = "Họ và tên:";
            // 
            // lblMovie
            // 
            lblMovie.Location = new Point(25, 70);
            lblMovie.Name = "lblMovie";
            lblMovie.Size = new Size(99, 25);
            lblMovie.TabIndex = 4;
            lblMovie.Text = "Chọn phim:";
            // 
            // lblRoom
            // 
            lblRoom.Location = new Point(25, 110);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(99, 25);
            lblRoom.TabIndex = 6;
            lblRoom.Text = "Phòng chiếu:";
            // 
            // lblSelectedSeats
            // 
            lblSelectedSeats.Location = new Point(800, 27);
            lblSelectedSeats.Name = "lblSelectedSeats";
            lblSelectedSeats.Size = new Size(120, 25);
            lblSelectedSeats.TabIndex = 8;
            lblSelectedSeats.Text = "Ghế đã chọn:";
            // 
            // lblTotal
            // 
            lblTotal.Location = new Point(800, 67);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(120, 25);
            lblTotal.TabIndex = 10;
            lblTotal.Text = "Tiền tạm tính:";
            // 
            // lblResult
            // 
            lblResult.Location = new Point(1240, 150);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(110, 25);
            lblResult.TabIndex = 17;
            lblResult.Text = "Thông tin vé:";
            // 
            // lblServerIP
            // 
            lblServerIP.Location = new Point(800, 107);
            lblServerIP.Name = "lblServerIP";
            lblServerIP.Size = new Size(70, 25);
            lblServerIP.TabIndex = 12;
            lblServerIP.Text = "IP server:";
            // 
            // panelSeats
            // 
            panelSeats.BorderStyle = BorderStyle.FixedSingle;
            panelSeats.Location = new Point(25, 150);
            panelSeats.Name = "panelSeats";
            panelSeats.Size = new Size(1080, 600);
            panelSeats.TabIndex = 14;
            panelSeats.Visible = false;
            // 
            // Bai04TCPClientForm
            // 
            ClientSize = new Size(1550, 800);
            Controls.Add(btnConnect);
            Controls.Add(btnDisconnect);
            Controls.Add(lblCustomerName);
            Controls.Add(txtCustomerName);
            Controls.Add(lblMovie);
            Controls.Add(cmbMovie);
            Controls.Add(lblRoom);
            Controls.Add(cmbRoom);
            Controls.Add(lblSelectedSeats);
            Controls.Add(txtSelectedSeats);
            Controls.Add(lblTotal);
            Controls.Add(txtTotal);
            Controls.Add(lblServerIP);
            Controls.Add(txtServerIP);
            Controls.Add(panelSeats);
            Controls.Add(btnCalculate);
            Controls.Add(btnReset);
            Controls.Add(lblResult);
            Controls.Add(txtResult);
            Controls.Add(btnExit);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Bai04TCPClientForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bài 04 - TCP Client";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
