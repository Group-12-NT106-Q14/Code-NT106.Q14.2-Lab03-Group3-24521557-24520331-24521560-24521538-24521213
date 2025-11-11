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
            btnConnect = new System.Windows.Forms.Button();
            btnDisconnect = new System.Windows.Forms.Button();
            btnCalculate = new System.Windows.Forms.Button();
            btnReset = new System.Windows.Forms.Button();
            btnExit = new System.Windows.Forms.Button();
            cmbMovie = new System.Windows.Forms.ComboBox();
            cmbRoom = new System.Windows.Forms.ComboBox();
            txtCustomerName = new System.Windows.Forms.TextBox();
            txtSelectedSeats = new System.Windows.Forms.TextBox();
            txtTotal = new System.Windows.Forms.TextBox();
            txtResult = new System.Windows.Forms.TextBox();
            txtServerIP = new System.Windows.Forms.TextBox();
            lblCustomerName = new System.Windows.Forms.Label();
            lblMovie = new System.Windows.Forms.Label();
            lblRoom = new System.Windows.Forms.Label();
            lblSelectedSeats = new System.Windows.Forms.Label();
            lblTotal = new System.Windows.Forms.Label();
            lblResult = new System.Windows.Forms.Label();
            lblServerIP = new System.Windows.Forms.Label();
            panelSeats = new System.Windows.Forms.Panel();

            SuspendLayout();

            btnConnect.Location = new System.Drawing.Point(1240, 20);
            btnConnect.Size = new System.Drawing.Size(120, 36);
            btnConnect.Text = "Kết nối server";
            btnConnect.Click += btnConnect_Click;

            btnDisconnect.Location = new System.Drawing.Point(1370, 20);
            btnDisconnect.Size = new System.Drawing.Size(120, 36);
            btnDisconnect.Text = "Ngắt kết nối";
            btnDisconnect.Click += btnDisconnect_Click;

            lblCustomerName.Location = new System.Drawing.Point(25, 30);
            lblCustomerName.Size = new System.Drawing.Size(110, 25);
            lblCustomerName.Text = "Họ và tên:";

            txtCustomerName.Location = new System.Drawing.Point(130, 27);
            txtCustomerName.Size = new System.Drawing.Size(300, 27);

            lblMovie.Location = new System.Drawing.Point(25, 70);
            lblMovie.Size = new System.Drawing.Size(120, 25);
            lblMovie.Text = "Chọn phim:";

            cmbMovie.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMovie.Location = new System.Drawing.Point(130, 67);
            cmbMovie.Size = new System.Drawing.Size(600, 27);
            cmbMovie.DropDownWidth = 800;
            cmbMovie.MaxDropDownItems = 15;
            cmbMovie.SelectedIndexChanged += cmbMovie_SelectedIndexChanged;

            lblRoom.Location = new System.Drawing.Point(25, 110);
            lblRoom.Size = new System.Drawing.Size(120, 25);
            lblRoom.Text = "Phòng chiếu:";

            cmbRoom.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoom.Location = new System.Drawing.Point(130, 107);
            cmbRoom.Size = new System.Drawing.Size(180, 27);
            cmbRoom.Enabled = false;
            cmbRoom.SelectedIndexChanged += cmbRoom_SelectedIndexChanged;

            lblSelectedSeats.Location = new System.Drawing.Point(800, 27);
            lblSelectedSeats.Size = new System.Drawing.Size(120, 25);
            lblSelectedSeats.Text = "Ghế đã chọn:";

            txtSelectedSeats.Location = new System.Drawing.Point(925, 27);
            txtSelectedSeats.Size = new System.Drawing.Size(300, 27);
            txtSelectedSeats.ReadOnly = true;

            lblTotal.Location = new System.Drawing.Point(800, 67);
            lblTotal.Size = new System.Drawing.Size(120, 25);
            lblTotal.Text = "Tiền tạm tính:";

            txtTotal.Location = new System.Drawing.Point(925, 67);
            txtTotal.Size = new System.Drawing.Size(300, 27);
            txtTotal.ReadOnly = true;

            lblServerIP.Location = new System.Drawing.Point(800, 107);
            lblServerIP.Size = new System.Drawing.Size(70, 25);
            lblServerIP.Text = "IP server:";
            txtServerIP.Location = new System.Drawing.Point(870, 107);
            txtServerIP.Size = new System.Drawing.Size(160, 27);
            txtServerIP.Text = "127.0.0.1";

            btnCalculate.Location = new System.Drawing.Point(1240, 70);
            btnCalculate.Size = new System.Drawing.Size(120, 36);
            btnCalculate.Text = "Đặt vé";
            btnCalculate.Click += btnCalculate_Click;

            btnReset.Location = new System.Drawing.Point(1370, 70);
            btnReset.Size = new System.Drawing.Size(120, 36);
            btnReset.Text = "Làm mới";
            btnReset.Click += btnReset_Click;

            panelSeats.Location = new System.Drawing.Point(25, 150);
            panelSeats.Size = new System.Drawing.Size(1080, 600);
            panelSeats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelSeats.Visible = false;

            lblResult.Location = new System.Drawing.Point(1240, 150);
            lblResult.Size = new System.Drawing.Size(110, 25);
            lblResult.Text = "Thông tin vé:";

            txtResult.Location = new System.Drawing.Point(1240, 180);
            txtResult.Size = new System.Drawing.Size(250, 230);
            txtResult.Multiline = true;
            txtResult.ReadOnly = true;
            txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

            btnExit.Location = new System.Drawing.Point(1240, 420);
            btnExit.Size = new System.Drawing.Size(250, 35);
            btnExit.Text = "Thoát";
            btnExit.Click += btnExit_Click;

            this.ClientSize = new System.Drawing.Size(1550, 800);

            this.Controls.Add(btnConnect); this.Controls.Add(btnDisconnect);
            this.Controls.Add(lblCustomerName); this.Controls.Add(txtCustomerName);
            this.Controls.Add(lblMovie); this.Controls.Add(cmbMovie);
            this.Controls.Add(lblRoom); this.Controls.Add(cmbRoom);
            this.Controls.Add(lblSelectedSeats); this.Controls.Add(txtSelectedSeats);
            this.Controls.Add(lblTotal); this.Controls.Add(txtTotal);
            this.Controls.Add(lblServerIP); this.Controls.Add(txtServerIP);
            this.Controls.Add(panelSeats);
            this.Controls.Add(btnCalculate); this.Controls.Add(btnReset);
            this.Controls.Add(lblResult); this.Controls.Add(txtResult);
            this.Controls.Add(btnExit);

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client - Đặt vé phòng vé";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
