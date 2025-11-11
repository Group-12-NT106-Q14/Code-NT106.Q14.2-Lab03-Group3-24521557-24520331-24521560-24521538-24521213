using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;

namespace Code_NT106.Q14._2_Lab03_Group3_24521557_24520331_24521560_24521538_24521213
{
    public partial class Bai04TCPServerForm : Form
    {
        private class MovieInfo
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public List<int> Rooms { get; set; }
            public int TotalSeats { get; set; }
            public int SoldSeats { get; set; }
            public int RemainingSeats => TotalSeats - SoldSeats;
            public decimal SalesPercentage => TotalSeats > 0 ? (decimal)SoldSeats / TotalSeats * 100 : 0;
            public decimal Revenue { get; set; }
        }

        private TcpListener listener;
        private List<TcpClient> clientList = new List<TcpClient>();
        private Dictionary<string, MovieInfo> movies = new Dictionary<string, MovieInfo>();
        private Dictionary<string, decimal> seatPriceMultipliers = new Dictionary<string, decimal>();
        private Dictionary<string, bool> bookedSeats = new Dictionary<string, bool>();

        public Bai04TCPServerForm()
        {
            InitializeComponent();
            InitializeSeatMultipliers();
            btnStartServer.Enabled = false;
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            string filePath = "movies.txt";
            if (!File.Exists(filePath))
            {
                MessageBox.Show("File movies.txt không tồn tại!");
                return;
            }
            try
            {
                LoadDataFromFile(filePath);
                MessageBox.Show("Đọc file thành công!");
                btnStartServer.Enabled = true;
                txtLog.AppendText("Đã đọc dữ liệu phim, bạn có thể khởi động server.\r\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đọc file: {ex.Message}");
            }
        }

        private void btnExportReport_Click(object sender, EventArgs e)
        {
            ExportReportAsync("output_bai4.txt");
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            btnStartServer.Enabled = false;
            Thread t = new Thread(RunServer); t.IsBackground = true; t.Start();
            string localIP = "";
            var ips = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList;
            foreach (var a in ips)
            {
                if (a.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    localIP = a.ToString();
                    break;
                }
            }
            txtLog.AppendText("IP server: " + localIP + ":4000" + Environment.NewLine);
            txtLog.AppendText("Server đã khởi động thành công!\r\n");
            MessageBox.Show("Server đã khởi động thành công!");
        }

        public void RunServer()
        {
            listener = new TcpListener(System.Net.IPAddress.Any, 4000);
            listener.Start();
            while (true)
            {
                var client = listener.AcceptTcpClient();
                lock (clientList) clientList.Add(client);
                Thread t = new Thread(() => HandleClient(client));
                t.IsBackground = true; t.Start();
            }
        }

        private void HandleClient(TcpClient client)
        {
            var ns = client.GetStream();
            try
            {
                SendFullData(ns);
                while (client.Connected)
                {
                    byte[] buffer = new byte[4096];
                    int n = ns.Read(buffer, 0, buffer.Length);
                    if (n <= 0) break;
                    string req = Encoding.UTF8.GetString(buffer, 0, n);
                    if (req.StartsWith("BOOK:"))
                    {
                        var parts = JsonSerializer.Deserialize<Dictionary<string, string>>(req.Substring(5));
                        string movie = parts["movie"];
                        int room = int.Parse(parts["room"]);
                        string[] seatList = parts["seats"].Split(';', StringSplitOptions.RemoveEmptyEntries);
                        string customer = parts["customer"];
                        bool success = true;
                        lock (bookedSeats)
                        {
                            foreach (var seatName in seatList)
                            {
                                string seatKey = $"{movie}_{room}_{seatName}";
                                if (bookedSeats.ContainsKey(seatKey) && bookedSeats[seatKey])
                                    success = false;
                            }
                            if (success)
                            {
                                foreach (var seatName in seatList)
                                    bookedSeats[$"{movie}_{room}_{seatName}"] = true;
                            }
                        }
                        string resp = success ? "OK" : "FAILED";
                        ns.Write(Encoding.UTF8.GetBytes(resp));
                        BroadcastFullData();
                    }
                    else if (req.StartsWith("REFRESH"))
                    {
                        SendFullData(ns);
                    }
                }
            }
            catch { }
            lock (clientList) clientList.Remove(client);
            ns.Close(); client.Close();
        }

        private void SendFullData(NetworkStream ns)
        {
            var data = new { Movies = movies, Seats = bookedSeats };
            string json = JsonSerializer.Serialize(data);
            var sendBuff = Encoding.UTF8.GetBytes("SYNC:" + json);
            ns.Write(sendBuff, 0, sendBuff.Length);
        }

        private void BroadcastFullData()
        {
            var data = new { Movies = movies, Seats = bookedSeats };
            string json = JsonSerializer.Serialize(data);
            var sendBuff = Encoding.UTF8.GetBytes("SYNC:" + json);
            lock (clientList)
            {
                foreach (var cli in clientList.ToArray())
                {
                    try { if (cli.Connected) cli.GetStream().Write(sendBuff, 0, sendBuff.Length); }
                    catch { }
                }
            }
        }

        private void LoadDataFromFile(string filePath)
        {
            movies.Clear();
            bookedSeats.Clear();
            string[] lines = File.ReadAllLines(filePath);
            if (lines.Length == 0) throw new Exception("File rỗng!");
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                string[] parts = line.Split('|');
                if (parts.Length < 3) throw new Exception($"Sai thông tin dòng: {line}");
                string movieName = parts[0].Trim();
                decimal price = decimal.Parse(parts[1].Trim());
                List<int> rooms = parts[2].Trim().Split(',').Select(x => int.Parse(x.Trim())).ToList();
                movies[movieName] = new MovieInfo
                {
                    Name = movieName,
                    Price = price,
                    Rooms = rooms,
                    TotalSeats = rooms.Count * 188
                };
            }
            foreach (var mv in movies.Values)
                foreach (int room in mv.Rooms)
                    InitializeSeatsForRoom(mv.Name, room);
        }

        private async void ExportReportAsync(string filePath)
        {
            try
            {
                await System.Threading.Tasks.Task.Run(() =>
                {
                    foreach (var movie in movies.Values)
                    {
                        movie.SoldSeats = 0;
                        movie.Revenue = 0;
                        foreach (var room in movie.Rooms)
                        {
                            char[] rows = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M' };
                            foreach (char row in rows)
                            {
                                if (row == 'M')
                                {
                                    string[] coupleSeats = { "M1+2", "M3+4", "M5+6", "M7+8", "M9+10", "M11+12" };
                                    foreach (var seat in coupleSeats)
                                    {
                                        string seatKey = $"{movie.Name}_{room}_{seat}";
                                        if (bookedSeats.ContainsKey(seatKey) && bookedSeats[seatKey])
                                        {
                                            movie.SoldSeats++;
                                            decimal t = seatPriceMultipliers.ContainsKey(seat) ? seatPriceMultipliers[seat] : 1m;
                                            movie.Revenue += movie.Price * t;
                                        }
                                    }
                                }
                                else
                                {
                                    for (int col = 1; col <= 14; ++col)
                                    {
                                        string name = $"{row}{col}";
                                        string seatKey = $"{movie.Name}_{room}_{name}";
                                        if (bookedSeats.ContainsKey(seatKey) && bookedSeats[seatKey])
                                        {
                                            movie.SoldSeats++;
                                            decimal t = seatPriceMultipliers.ContainsKey(name) ? seatPriceMultipliers[name] : 1m;
                                            movie.Revenue += movie.Price * t;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    var sorted = movies.Values.OrderByDescending(m => m.Revenue).ToList();
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        writer.WriteLine("THONG KE PHONG VE".PadLeft(58));
                        writer.WriteLine($"{"Xếp hạng",-12}{"Tên phim",-30}{"Vé bán",-12}{"Vé tồn",-12}{"Tỉ lệ (%)",-12}{"Doanh thu",-20}");
                        int idx = 1;
                        foreach (var mv in sorted)
                        {
                            writer.WriteLine($"{idx++,-12}{mv.Name,-30}{mv.SoldSeats,-12}{mv.RemainingSeats,-12}{mv.SalesPercentage,-12:F2}{mv.Revenue,-20:N0}");
                        }
                        writer.WriteLine($"Tổng doanh thu: {sorted.Sum(m => m.Revenue):N0}");
                        writer.WriteLine($"Tổng vé bán ra: {sorted.Sum(m => m.SoldSeats)}");
                    }
                });
                MessageBox.Show("Xuất báo cáo thành công!");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi xuất file: " + ex.Message); }
        }

        private void InitializeSeatMultipliers()
        {
            string[] discountSeats = { "A1", "A5", "C1", "C5" };
            foreach (var seat in discountSeats) seatPriceMultipliers[seat] = 0.25m;
            string[] normalSeats = { "A2", "A3", "A4", "C2", "C3", "C4" };
            foreach (var seat in normalSeats) seatPriceMultipliers[seat] = 1m;
            string[] vipSeats = { "B2", "B3", "B4" };
            foreach (var seat in vipSeats) seatPriceMultipliers[seat] = 2m;
            string[] coupleSeats = { "M1+2", "M3+4", "M5+6", "M7+8", "M9+10", "M11+12" };
            foreach (var seat in coupleSeats) seatPriceMultipliers[seat] = 2m;
        }

        private void InitializeSeatsForRoom(string movieName, int room)
        {
            char[] rows = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M' };
            foreach (char row in rows)
            {
                if (row == 'M')
                {
                    string[] coupleSeats = { "M1+2", "M3+4", "M5+6", "M7+8", "M9+10", "M11+12" };
                    foreach (var seat in coupleSeats)
                    {
                        string seatKey = $"{movieName}_{room}_{seat}";
                        if (!bookedSeats.ContainsKey(seatKey))
                            bookedSeats[seatKey] = false;
                    }
                }
                else
                {
                    for (int col = 1; col <= 14; ++col)
                    {
                        string seatKey = $"{movieName}_{room}_{row}{col}";
                        if (!bookedSeats.ContainsKey(seatKey))
                            bookedSeats[seatKey] = false;
                    }
                }
            }
        }
    }
}
