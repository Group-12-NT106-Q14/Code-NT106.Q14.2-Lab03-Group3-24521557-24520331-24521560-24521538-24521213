namespace Code_NT106.Q14._2_Lab03_Group3_24521557_24520331_24521560_24521538_24521213
{
    partial class Bai05TCPClient
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtServerIP, txtHoVaTen, txtTenMonAn, txtHinhAnh;
        private System.Windows.Forms.Button btnConnect, btnDisconnect, btnThem, btnChonHinh;
        private System.Windows.Forms.Label lblServerIP, label1, label2, label3;

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listViewMonAn;
        private System.Windows.Forms.ColumnHeader colIDMA, colTenMonAn, colHinhAnh, colNguoiDongGop;

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox pictureBoxMonAn;
        private System.Windows.Forms.Label lblKetQua, label4;
        private System.Windows.Forms.Button btnRandomAll, btnRandomSelf, btnXoa, btnThoat;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            lblServerIP = new Label();
            txtServerIP = new TextBox();
            btnConnect = new Button();
            btnDisconnect = new Button();
            label1 = new Label();
            txtHoVaTen = new TextBox();
            label2 = new Label();
            txtTenMonAn = new TextBox();
            label3 = new Label();
            txtHinhAnh = new TextBox();
            btnChonHinh = new Button();
            btnThem = new Button();
            groupBox2 = new GroupBox();
            listViewMonAn = new ListView();
            colIDMA = new ColumnHeader();
            colTenMonAn = new ColumnHeader();
            colHinhAnh = new ColumnHeader();
            colNguoiDongGop = new ColumnHeader();
            groupBox3 = new GroupBox();
            pictureBoxMonAn = new PictureBox();
            lblKetQua = new Label();
            label4 = new Label();
            btnRandomSelf = new Button();
            btnRandomAll = new Button();
            btnXoa = new Button();
            btnThoat = new Button();
            openFileDialog1 = new OpenFileDialog();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMonAn).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblServerIP);
            groupBox1.Controls.Add(txtServerIP);
            groupBox1.Controls.Add(btnConnect);
            groupBox1.Controls.Add(btnDisconnect);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtHoVaTen);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtTenMonAn);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtHinhAnh);
            groupBox1.Controls.Add(btnChonHinh);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Location = new Point(12, 15);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(500, 300);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thêm món ăn mới";
            // 
            // lblServerIP
            // 
            lblServerIP.Location = new Point(15, 31);
            lblServerIP.Name = "lblServerIP";
            lblServerIP.Size = new Size(70, 20);
            lblServerIP.TabIndex = 0;
            lblServerIP.Text = "IP server:";
            // 
            // txtServerIP
            // 
            txtServerIP.Location = new Point(90, 28);
            txtServerIP.Name = "txtServerIP";
            txtServerIP.Size = new Size(120, 27);
            txtServerIP.TabIndex = 1;
            txtServerIP.Text = "127.0.0.1";
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(220, 25);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(80, 28);
            btnConnect.TabIndex = 2;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Enabled = false;
            btnDisconnect.Location = new Point(310, 25);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(108, 28);
            btnDisconnect.TabIndex = 3;
            btnDisconnect.Text = "Ngắt kết nối";
            btnDisconnect.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Location = new Point(15, 70);
            label1.Name = "label1";
            label1.Size = new Size(70, 20);
            label1.TabIndex = 4;
            label1.Text = "Họ tên:";
            // 
            // txtHoVaTen
            // 
            txtHoVaTen.Location = new Point(90, 66);
            txtHoVaTen.Name = "txtHoVaTen";
            txtHoVaTen.Size = new Size(220, 27);
            txtHoVaTen.TabIndex = 5;
            // 
            // label2
            // 
            label2.Location = new Point(15, 115);
            label2.Name = "label2";
            label2.Size = new Size(90, 20);
            label2.TabIndex = 6;
            label2.Text = "Tên món:";
            // 
            // txtTenMonAn
            // 
            txtTenMonAn.Location = new Point(110, 112);
            txtTenMonAn.Name = "txtTenMonAn";
            txtTenMonAn.Size = new Size(200, 27);
            txtTenMonAn.TabIndex = 7;
            // 
            // label3
            // 
            label3.Location = new Point(15, 160);
            label3.Name = "label3";
            label3.Size = new Size(80, 20);
            label3.TabIndex = 8;
            label3.Text = "Hình ảnh:";
            // 
            // txtHinhAnh
            // 
            txtHinhAnh.Location = new Point(95, 157);
            txtHinhAnh.Name = "txtHinhAnh";
            txtHinhAnh.Size = new Size(245, 27);
            txtHinhAnh.TabIndex = 9;
            // 
            // btnChonHinh
            // 
            btnChonHinh.Location = new Point(350, 157);
            btnChonHinh.Name = "btnChonHinh";
            btnChonHinh.Size = new Size(144, 27);
            btnChonHinh.TabIndex = 10;
            btnChonHinh.Text = "Chọn ảnh từ máy";
            btnChonHinh.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(180, 210);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(110, 40);
            btnThem.TabIndex = 11;
            btnThem.Text = "Thêm món";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(listViewMonAn);
            groupBox2.Location = new Point(520, 15);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(570, 300);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách món ăn";
            // 
            // listViewMonAn
            // 
            listViewMonAn.Columns.AddRange(new ColumnHeader[] { colIDMA, colTenMonAn, colHinhAnh, colNguoiDongGop });
            listViewMonAn.FullRowSelect = true;
            listViewMonAn.GridLines = true;
            listViewMonAn.Location = new Point(15, 31);
            listViewMonAn.Name = "listViewMonAn";
            listViewMonAn.Size = new Size(540, 250);
            listViewMonAn.TabIndex = 0;
            listViewMonAn.UseCompatibleStateImageBehavior = false;
            listViewMonAn.View = View.Details;
            // 
            // colIDMA
            // 
            colIDMA.Text = "ID";
            colIDMA.Width = 50;
            // 
            // colTenMonAn
            // 
            colTenMonAn.Text = "Tên món ăn";
            colTenMonAn.Width = 150;
            // 
            // colHinhAnh
            // 
            colHinhAnh.Text = "Hình ảnh";
            colHinhAnh.Width = 180;
            // 
            // colNguoiDongGop
            // 
            colNguoiDongGop.Text = "Người đóng góp";
            colNguoiDongGop.Width = 120;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(pictureBoxMonAn);
            groupBox3.Controls.Add(lblKetQua);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(btnRandomSelf);
            groupBox3.Controls.Add(btnRandomAll);
            groupBox3.Controls.Add(btnXoa);
            groupBox3.Controls.Add(btnThoat);
            groupBox3.Location = new Point(12, 330);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1078, 260);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Kết quả/ngẫu nhiên";
            // 
            // pictureBoxMonAn
            // 
            pictureBoxMonAn.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxMonAn.Location = new Point(646, 35);
            pictureBoxMonAn.Name = "pictureBoxMonAn";
            pictureBoxMonAn.Size = new Size(430, 200);
            pictureBoxMonAn.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxMonAn.TabIndex = 0;
            pictureBoxMonAn.TabStop = false;
            // 
            // lblKetQua
            // 
            lblKetQua.Font = new Font("Microsoft Sans Serif", 12F);
            lblKetQua.ForeColor = Color.Red;
            lblKetQua.Location = new Point(30, 70);
            lblKetQua.Name = "lblKetQua";
            lblKetQua.Size = new Size(340, 90);
            lblKetQua.TabIndex = 1;
            lblKetQua.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label4.Location = new Point(30, 35);
            label4.Name = "label4";
            label4.Size = new Size(340, 25);
            label4.TabIndex = 2;
            label4.Text = "Ăn gì hôm nay: (Random)";
            // 
            // btnRandomSelf
            // 
            btnRandomSelf.Location = new Point(400, 90);
            btnRandomSelf.Name = "btnRandomSelf";
            btnRandomSelf.Size = new Size(170, 36);
            btnRandomSelf.TabIndex = 3;
            btnRandomSelf.Text = "Ngẫu nhiên của tôi";
            btnRandomSelf.UseVisualStyleBackColor = true;
            // 
            // btnRandomAll
            // 
            btnRandomAll.Location = new Point(400, 40);
            btnRandomAll.Name = "btnRandomAll";
            btnRandomAll.Size = new Size(170, 36);
            btnRandomAll.TabIndex = 4;
            btnRandomAll.Text = "Ngẫu nhiên cộng đồng";
            btnRandomAll.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(400, 160);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(100, 35);
            btnXoa.TabIndex = 5;
            btnXoa.Text = "Xóa DB";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(540, 160);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(100, 35);
            btnThoat.TabIndex = 6;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // Bai05TCPClient
            // 
            ClientSize = new Size(1100, 610);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox3);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Bai05TCPClient";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bài 05 - TCP Client";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxMonAn).EndInit();
            ResumeLayout(false);

        }
    }
}
