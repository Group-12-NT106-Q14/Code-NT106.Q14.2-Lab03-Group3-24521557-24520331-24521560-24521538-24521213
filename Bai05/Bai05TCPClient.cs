using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Code_NT106.Q14._2_Lab03_Group3_24521557_24520331_24521560_24521538_24521213
{
    public partial class Bai05TCPClient : Form
    {
        TcpClient client;
        NetworkStream ns;

        public Bai05TCPClient()
        {
            InitializeComponent();
            btnThem.Enabled = btnRandomAll.Enabled = btnRandomSelf.Enabled = btnXoa.Enabled = btnDisconnect.Enabled = false;
            txtHinhAnh.TextChanged += (s, e) => PreviewImage();
            btnConnect.Click += btnConnect_Click;
            btnDisconnect.Click += btnDisconnect_Click;
            btnThem.Click += btnThem_Click;
            btnChonHinh.Click += btnChonHinh_Click;
            btnRandomAll.Click += btnRandomAll_Click;
            btnRandomSelf.Click += btnRandomSelf_Click;
            btnXoa.Click += btnXoa_Click;
            btnThoat.Click += btnThoat_Click;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            btnConnect.Enabled = false;
            var ip = txtServerIP.Text.Trim();
            if (string.IsNullOrEmpty(ip)) ip = "127.0.0.1";

            Task.Run(() =>
            {
                try
                {
                    client = new TcpClient();
                    client.Connect(ip, 5000);
                    ns = client.GetStream();

                    SendRequest(new { action = "GET" });
                    string line = ReadLine();

                    this.Invoke(new Action(() =>
                    {
                        ProcessFoodsJson(line);
                        btnConnect.Enabled = false;
                        btnDisconnect.Enabled = true;
                        btnThem.Enabled = btnRandomAll.Enabled = btnRandomSelf.Enabled = btnXoa.Enabled = true;
                    }));
                }
                catch (SocketException ex)
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show("Kết nối không thành công!\nLý do: Server chưa bật hoặc không thể truy cập địa chỉ này.",
                            "Kết nối thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnConnect.Enabled = true;
                    }));
                }
                catch (Exception ex)
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show("Kết nối không thành công!\nChi tiết: " + ex.Message,
                            "Kết nối thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnConnect.Enabled = true;
                    }));
                }
            });
        }


        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try { ns?.Close(); client?.Close(); } catch { }
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            btnThem.Enabled = btnRandomAll.Enabled = btnRandomSelf.Enabled = btnXoa.Enabled = false;
            listViewMonAn.Items.Clear();
            lblKetQua.Text = "";
            pictureBoxMonAn.Image = null;
        }

        private void btnChonHinh_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Ảnh|*.png;*.jpg;*.jpeg;*.bmp;*.gif;*.webp";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtHinhAnh.Text = openFileDialog1.FileName;
                PreviewImage();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenMonAn = txtTenMonAn.Text.Trim();
            string hinhAnh = txtHinhAnh.Text.Trim();
            string hoVaTen = txtHoVaTen.Text.Trim();

            if (string.IsNullOrEmpty(hoVaTen))
            {
                MessageBox.Show("Hãy nhập họ tên!");
                return;
            }
            if (string.IsNullOrEmpty(tenMonAn))
            {
                MessageBox.Show("Vui lòng nhập tên món ăn!");
                return;
            }

            string fileBase64 = null;
            if (!string.IsNullOrEmpty(hinhAnh) && File.Exists(hinhAnh))
            {
                fileBase64 = Convert.ToBase64String(File.ReadAllBytes(hinhAnh));
                hinhAnh = "";
            }
            else if (!string.IsNullOrWhiteSpace(hinhAnh) && !hinhAnh.StartsWith("http"))
            {
                MessageBox.Show("Vui lòng nhập URL hợp lệ hoặc chọn file từ máy!");
                return;
            }

            Task.Run(() =>
            {
                try
                {
                    SendRequest(new
                    {
                        action = "ADD",
                        food = tenMonAn,
                        image = hinhAnh,
                        user = hoVaTen,
                        imageBase64 = fileBase64
                    });
                    string line = ReadLine();
                    this.Invoke(new Action(() =>
                    {
                        if (string.IsNullOrWhiteSpace(line))
                        {
                            MessageBox.Show("Không nhận được phản hồi từ server.");
                            return;
                        }
                        ProcessFoodsJson(line);
                        ClearInput();
                        MessageBox.Show("Đã thêm món thành công!");
                    }));
                }
                catch (Exception)
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show("Mất kết nối khi gửi yêu cầu thêm món!");
                        btnDisconnect_Click(null, null);
                    }));
                }
            });
        }

        private void btnRandomSelf_Click(object sender, EventArgs e)
        {
            string hoVaTen = txtHoVaTen.Text.Trim();
            Task.Run(() =>
            {
                try
                {
                    SendRequest(new { action = "RANDOM", scope = "self", user = hoVaTen });
                    string line = ReadLine();
                    object resObj = null;
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        var dict = JsonSerializer.Deserialize<Dictionary<string, object>>(line);
                        resObj = (dict != null && dict.ContainsKey("res")) ? dict["res"] : null;
                    }
                    this.Invoke(new Action(() => ShowResult(resObj)));
                }
                catch (Exception)
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show("Kết nối bị gián đoạn!");
                        btnDisconnect_Click(null, null);
                    }));
                }
            });
        }

        private void btnRandomAll_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    SendRequest(new { action = "RANDOM", scope = "all" });
                    string line = ReadLine();
                    object resObj = null;
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        var dict = JsonSerializer.Deserialize<Dictionary<string, object>>(line);
                        resObj = (dict != null && dict.ContainsKey("res")) ? dict["res"] : null;
                    }
                    this.Invoke(new Action(() => ShowResult(resObj)));
                }
                catch (Exception)
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show("Kết nối bị gián đoạn!");
                        btnDisconnect_Click(null, null);
                    }));
                }
            });
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    SendRequest(new { action = "DELETE_ALL" });
                    string line = ReadLine();
                    this.Invoke(new Action(() =>
                    {
                        ProcessFoodsJson(line);
                        lblKetQua.Text = "";
                        pictureBoxMonAn.Image = null;
                    }));
                }
                catch (Exception)
                {
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show("Kết nối bị gián đoạn!");
                        btnDisconnect_Click(null, null);
                    }));
                }
            });
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            try { ns?.Close(); client?.Close(); } catch { }
            Close();
        }

        void SendRequest(object obj)
        {
            var s = JsonSerializer.Serialize(obj) + "\n";
            var buf = Encoding.UTF8.GetBytes(s);
            ns.Write(buf, 0, buf.Length);
        }

        string ReadLine()
        {
            StringBuilder sb = new();
            int b;
            try
            {
                while ((b = ns.ReadByte()) >= 0)
                {
                    if (b == '\n') break;
                    sb.Append((char)b);
                }
            }
            catch
            {
                return null;
            }
            return sb.Length > 0 ? sb.ToString() : null;
        }

        private void ProcessFoodsJson(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) return;
            var dict = JsonSerializer.Deserialize<Dictionary<string, object>>(line);
            var foodsObj = dict != null && dict.ContainsKey("foods") ? dict["foods"] : null;
            if (foodsObj == null) return;
            var jsonArr = JsonSerializer.Serialize(foodsObj);
            var foods = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(jsonArr) ?? new List<Dictionary<string, string>>();

            listViewMonAn.Items.Clear();
            foreach (var food in foods)
            {
                var item = new ListViewItem(food["IDMA"]);
                item.SubItems.Add(food["TenMonAn"]);
                item.SubItems.Add(food["HinhAnh"]);
                item.SubItems.Add(food["HoVaTen"]);
                listViewMonAn.Items.Add(item);
            }
        }

        private void ShowResult(object obj)
        {
            if (obj == null)
            {
                lblKetQua.Text = "Không tìm được món nào!";
                pictureBoxMonAn.Image = null;
                return;
            }
            string json = JsonSerializer.Serialize(obj);
            var food = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            if (food == null || !food.ContainsKey("TenMonAn") || string.IsNullOrWhiteSpace(food["TenMonAn"]))
            {
                lblKetQua.Text = "Không tìm được món nào!";
                pictureBoxMonAn.Image = null;
                return;
            }
            lblKetQua.Text = $"{food["TenMonAn"]}\n\n(Đóng góp bởi: {food["HoVaTen"]})";
            ShowFoodImage(food.GetValueOrDefault("HinhAnh"));
        }

        private void PreviewImage()
        {
            if (txtHinhAnh.Text.Trim().StartsWith("http"))
            {
                try
                {
                    using var wc = new System.Net.WebClient();
                    byte[] data = wc.DownloadData(txtHinhAnh.Text.Trim());
                    using var ms = new MemoryStream(data);
                    pictureBoxMonAn.Image = Image.FromStream(ms);
                }
                catch { pictureBoxMonAn.Image = null; }
            }
            else if (File.Exists(txtHinhAnh.Text))
            {
                try
                {
                    pictureBoxMonAn.Image = Image.FromFile(txtHinhAnh.Text);
                }
                catch { pictureBoxMonAn.Image = null; }
            }
            else
            {
                pictureBoxMonAn.Image = null;
            }
        }

        private void ShowFoodImage(string urlOrPath)
        {
            pictureBoxMonAn.Image = null;
            if (string.IsNullOrEmpty(urlOrPath)) return;
            try
            {
                if (urlOrPath.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                {
                    using var wc = new System.Net.WebClient();
                    byte[] data = wc.DownloadData(urlOrPath);
                    using var ms = new MemoryStream(data);
                    pictureBoxMonAn.Image = Image.FromStream(ms);
                }
                else if (File.Exists(urlOrPath))
                {
                    pictureBoxMonAn.Image = Image.FromFile(urlOrPath);
                }
            }
            catch { pictureBoxMonAn.Image = null; }
        }

        private void ClearInput()
        {
            txtTenMonAn.Clear();
            txtHinhAnh.Clear();
            pictureBoxMonAn.Image = null;
        }
    }
}
