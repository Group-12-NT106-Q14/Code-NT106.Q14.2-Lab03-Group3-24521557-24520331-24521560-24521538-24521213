using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;
using System.Linq;

namespace Code_NT106.Q14._2_Lab03_Group3_24521557_24520331_24521560_24521538_24521213
{
    public partial class Bai04TCPClientForm : Form
    {
        private Dictionary<string, dynamic> movies = new Dictionary<string, dynamic>();
        private Dictionary<string, bool> bookedSeats = new Dictionary<string, bool>();
        private Dictionary<string, Button> seatButtons = new Dictionary<string, Button>();
        private List<string> selectedSeats = new List<string>();
        private int currentRoom = 0;
        private string currentMovie = "";
        private TcpClient client;
        private NetworkStream ns;
        private Thread listenThread;
        private bool isConnected = false;

        public Bai04TCPClientForm()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string ip = txtServerIP.Text.Trim();
            if (string.IsNullOrEmpty(ip)) ip = "127.0.0.1";
            try
            {
                client = new TcpClient();
                client.Connect(ip, 4000);
                ns = client.GetStream();
                listenThread = new Thread(ListenLoop) { IsBackground = true };
                listenThread.Start();
                isConnected = true;
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
                MessageBox.Show("Kết nối server thành công!");
            }
            catch
            {
                MessageBox.Show("Không thể kết nối đến server! (Chưa khởi động server hoặc sai IP/port)");
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try { ns?.Close(); client?.Close(); listenThread?.Abort(); } catch { }
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            isConnected = false;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                MessageBox.Show("Chưa kết nối đến server!");
                return;
            }
            if (string.IsNullOrEmpty(txtCustomerName.Text))
            {
                MessageBox.Show("Vui lòng nhập họ và tên khách hàng!");
                return;
            }
            if (cmbMovie.SelectedItem == null || cmbRoom.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn phim và phòng chiếu!");
                return;
            }
            if (selectedSeats.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một ghế!");
                return;
            }
            string movie = cmbMovie.SelectedItem.ToString();
            string room = cmbRoom.SelectedItem.ToString().Split(' ')[1];
            string seatStr = string.Join(';', selectedSeats);
            string customer = txtCustomerName.Text.Trim();
            var dict = new Dictionary<string, string>
            {
                ["movie"] = movie,
                ["room"] = room,
                ["seats"] = seatStr,
                ["customer"] = customer
            };
            string request = "BOOK:" + JsonSerializer.Serialize(dict);
            try
            {
                ns.Write(Encoding.UTF8.GetBytes(request), 0, Encoding.UTF8.GetByteCount(request));
            }
            catch
            {
                MessageBox.Show("Đã mất kết nối với server!");
            }
        }

        private string ReadFullJson(NetworkStream ns)
        {
            StringBuilder sb = new StringBuilder();
            byte[] buffer = new byte[8192];
            int len;
            while (true)
            {
                len = ns.Read(buffer, 0, buffer.Length);
                if (len <= 0) break;
                sb.Append(Encoding.UTF8.GetString(buffer, 0, len));
                var tmp = sb.ToString();
                if (tmp.StartsWith("SYNC:") && tmp.LastIndexOf('}') == tmp.Length - 1)
                    break;
                if (tmp == "OK" || tmp == "FAILED") break;
            }
            return sb.ToString();
        }

        private void ListenLoop()
        {
            while (true)
            {
                string resp = ReadFullJson(ns);
                if (resp.StartsWith("SYNC:"))
                {
                    var data = JsonSerializer.Deserialize<Dictionary<string, object>>(resp.Substring(5));
                    var moviesData = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(data["Movies"].ToString());
                    var seatsData = JsonSerializer.Deserialize<Dictionary<string, bool>>(data["Seats"].ToString());
                    this.Invoke((MethodInvoker)delegate {
                        movies = moviesData; bookedSeats = seatsData;
                        UpdateMovieComboBox();
                        if (currentMovie != "" && currentRoom != 0)
                        {
                            CreateSeatLayout();
                            UpdateSelectedSeatsDisplay();
                        }
                    });
                }
                else if (resp == "OK")
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show("Đặt vé thành công!");
                        string movie = cmbMovie.SelectedItem?.ToString() ?? "";
                        string customer = txtCustomerName.Text.Trim();
                        string room = (cmbRoom.SelectedItem != null) ? cmbRoom.SelectedItem.ToString().Split(' ')[1] : "";
                        string seatList = string.Join(", ", selectedSeats);
                        decimal price = 0;
                        if (movies.ContainsKey(movie))
                            try { price = decimal.Parse(movies[movie].GetProperty("Price").ToString()); } catch { }
                        decimal totalAmount = 0;
                        foreach (var seatName in selectedSeats)
                        {
                            decimal multiplier = 1;
                            string[] discountSeats = { "A1", "A5", "C1", "C5" };
                            string[] vipSeats = { "B2", "B3", "B4" };
                            string[] coupleSeats = { "M1+2", "M3+4", "M5+6", "M7+8", "M9+10", "M11+12" };
                            if (discountSeats.Contains(seatName)) multiplier = 0.25m;
                            else if (vipSeats.Contains(seatName) || coupleSeats.Contains(seatName)) multiplier = 2m;
                            totalAmount += price * multiplier;
                        }
                        string result = "";
                        result += $"Họ và tên: {customer}\r\n";
                        result += $"Tên phim: {movie}\r\n";
                        result += $"Phòng chiếu: {room}\r\n";
                        result += $"Vé đã chọn: {seatList}\r\n";
                        result += $"Tổng tiền: {totalAmount:N0}đ\r\n";
                        txtResult.Text = result;
                        selectedSeats.Clear(); UpdateSelectedSeatsDisplay();
                    });
                }
                else if (resp == "FAILED")
                {
                    this.Invoke((MethodInvoker)delegate { MessageBox.Show("Có ghế đã bị đặt mất, vui lòng chọn lại!"); });
                }
            }
        }

        private decimal ComputeTotalAmount()
        {
            if (cmbMovie.SelectedItem == null) return 0;
            string movie = cmbMovie.SelectedItem.ToString();
            decimal price = 0;
            if (movies.ContainsKey(movie))
                try { price = decimal.Parse(movies[movie].GetProperty("Price").ToString()); } catch { }
            decimal totalAmount = 0;
            foreach (var seatName in selectedSeats)
            {
                decimal multiplier = 1;
                string[] discountSeats = { "A1", "A5", "C1", "C5" };
                string[] vipSeats = { "B2", "B3", "B4" };
                string[] coupleSeats = { "M1+2", "M3+4", "M5+6", "M7+8", "M9+10", "M11+12" };
                if (discountSeats.Contains(seatName)) multiplier = 0.25m;
                else if (vipSeats.Contains(seatName) || coupleSeats.Contains(seatName)) multiplier = 2m;
                totalAmount += price * multiplier;
            }
            return totalAmount;
        }

        private void UpdateSelectedSeatsDisplay()
        {
            txtSelectedSeats.Text = string.Join(", ", selectedSeats);
            txtTotal.Text = $"{ComputeTotalAmount():N0}đ";
        }

        private void UpdateMovieComboBox()
        {
            var sel = cmbMovie.SelectedItem as string;
            cmbMovie.Items.Clear();
            cmbMovie.DropDownWidth = 800;
            foreach (var movie in movies.Keys)
                cmbMovie.Items.Add(movie);
            if (sel != null && movies.ContainsKey(sel)) cmbMovie.SelectedItem = sel;
        }

        private void cmbMovie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMovie.SelectedItem == null) return;
            cmbRoom.Items.Clear();
            currentMovie = cmbMovie.SelectedItem.ToString();
            var movie = movies[currentMovie];
            foreach (var r in movie.GetProperty("Rooms").ToString().Trim('[', ']').Split(','))
                cmbRoom.Items.Add($"Phòng {r.Trim()}");
            cmbRoom.Enabled = true;
            panelSeats.Visible = false;
        }

        private void cmbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRoom.SelectedItem == null) return;
            currentRoom = int.Parse(cmbRoom.SelectedItem.ToString().Split(' ')[1]);
            selectedSeats.Clear();
            CreateSeatLayout();
            panelSeats.Visible = true;
        }

        private void CreateSeatLayout()
        {
            panelSeats.Controls.Clear(); seatButtons.Clear();
            int startX = 50, startY = 80, btnW = 35, btnH = 30, sx = 40, sy = 35;
            char[] rows = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M' };
            for (int i = 0; i < rows.Length; i++)
            {
                if (rows[i] == 'M')
                {
                    string[] coupleSeats = { "1+2", "3+4", "5+6", "7+8", "9+10", "11+12" };
                    for (int j = 0; j < coupleSeats.Length; j++)
                    {
                        string seatName = $"M{coupleSeats[j]}", seatKey = $"{currentRoom}_{seatName}";
                        Button btn = new Button { Text = coupleSeats[j], Location = new System.Drawing.Point(startX + j * sx * 2 + (j * 10), startY + i * sy), Size = new System.Drawing.Size(btnW * 2 + 10, btnH), Tag = seatName, FlatStyle = FlatStyle.Flat };
                        SetSeatButtonColor(btn, seatName, seatKey);
                        btn.Click += SeatButton_Click; seatButtons[seatKey] = btn; panelSeats.Controls.Add(btn);
                    }
                }
                else
                {
                    for (int j = 1; j <= 14; ++j)
                    {
                        string seatName = $"{rows[i]}{j}", seatKey = $"{currentRoom}_{seatName}";
                        Button btn = new Button { Text = j.ToString(), Location = new System.Drawing.Point(startX + (j - 1) * sx, startY + i * sy), Size = new System.Drawing.Size(btnW, btnH), Tag = seatName, FlatStyle = FlatStyle.Flat };
                        SetSeatButtonColor(btn, seatName, seatKey);
                        btn.Click += SeatButton_Click; seatButtons[seatKey] = btn; panelSeats.Controls.Add(btn);
                    }
                }
            }
        }

        private void SetSeatButtonColor(Button btn, string seatName, string seatKey)
        {
            if (bookedSeats.ContainsKey(seatKey) && bookedSeats[seatKey])
            {
                btn.BackColor = System.Drawing.Color.DarkGray;
                btn.ForeColor = System.Drawing.Color.White;
                btn.Enabled = false;
                return;
            }
            if (selectedSeats.Contains(seatName))
            {
                btn.BackColor = System.Drawing.Color.Orange;
                btn.ForeColor = System.Drawing.Color.Black;
                return;
            }
            btn.BackColor = System.Drawing.Color.White;
            btn.ForeColor = System.Drawing.Color.Black;
            btn.Enabled = true;
        }

        private void SeatButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string seatName = btn.Tag.ToString(), seatKey = $"{currentRoom}_{seatName}";
            if (bookedSeats.ContainsKey(seatKey) && bookedSeats[seatKey])
            {
                MessageBox.Show("Ghế này đã được đặt!");
                return;
            }
            if (selectedSeats.Contains(seatName)) selectedSeats.Remove(seatName); else selectedSeats.Add(seatName);
            SetSeatButtonColor(btn, seatName, seatKey); UpdateSelectedSeatsDisplay();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtCustomerName.Clear();
            cmbMovie.SelectedIndex = -1; cmbRoom.SelectedIndex = -1; cmbRoom.Items.Clear(); cmbRoom.Enabled = false;
            txtSelectedSeats.Clear(); txtResult.Clear(); txtTotal.Clear();
            selectedSeats.Clear(); panelSeats.Visible = false; panelSeats.Controls.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try { ns?.Close(); client?.Close(); } catch { }
            Application.Exit();
        }
    }
}
