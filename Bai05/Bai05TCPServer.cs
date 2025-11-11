using System;
using System.Collections.Generic;
using System.Data.SQLite;
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
    public partial class Bai05TCPServer : Form
    {
        readonly string connectionString = "Data Source=Foods.db;Version=3;";
        TcpListener tcpListener;
        bool isServerRunning = false;
        List<TcpClient> clients = new();

        public Bai05TCPServer()
        {
            InitializeComponent();
            AddMessage($"Server IP: {GetLocalIPv4()} - Port: 5000");
            InitDatabase();
        }

        public static string GetLocalIPv4()
        {
            foreach (var ip in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
                if (ip.AddressFamily == AddressFamily.InterNetwork && !ip.ToString().StartsWith("169.254"))
                    return ip.ToString();
            return "127.0.0.1";
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            if (!isServerRunning)
            {
                tcpListener = new TcpListener(IPAddress.Any, 5000);
                tcpListener.Start();
                isServerRunning = true;
                btnStartServer.Enabled = false;
                AddMessage("Server started! Đang lắng nghe kết nối...");
                new Thread(AcceptClients) { IsBackground = true }.Start();
            }
        }

        private void AcceptClients()
        {
            while (isServerRunning)
            {
                var client = tcpListener.AcceptTcpClient();
                lock (clients) clients.Add(client);
                AddMessage($"Client mới: {((IPEndPoint)client.Client.RemoteEndPoint).Address}");
                new Thread(() => HandleClient(client)) { IsBackground = true }.Start();
            }
        }

        private void HandleClient(TcpClient client)
        {
            var ns = client.GetStream();
            try
            {
                while (isServerRunning && client.Connected)
                {
                    string line = ReadLine(ns);
                    if (line == null) break;
                    var request = JsonSerializer.Deserialize<Dictionary<string, string>>(line);
                    string action = request.GetValueOrDefault("action", "");
                    Dictionary<string, object> response = new();

                    if (action == "GET")
                    {
                        response["foods"] = GetFoodsList();
                        WriteJson(ns, response);
                    }
                    else if (action == "ADD")
                    {
                        string name = request["food"];
                        string image = request.GetValueOrDefault("image", "");
                        string username = request["user"];
                        string imageBase64 = request.GetValueOrDefault("imageBase64", null);

                        // XỬ LÝ ẢNH FILE GỬI LÊN
                        if (!string.IsNullOrWhiteSpace(imageBase64))
                        {
                            string imgFolder = "images";
                            if (!Directory.Exists(imgFolder)) Directory.CreateDirectory(imgFolder);
                            string fname = Path.Combine(imgFolder, $"{Guid.NewGuid()}.png");
                            File.WriteAllBytes(fname, Convert.FromBase64String(imageBase64));
                            image = Path.GetFullPath(fname);
                        }

                        int idncc = GetOrCreateUser(username);
                        AddFood(name, image, idncc);

                        var result = new Dictionary<string, object>
                        {
                            ["foods"] = GetFoodsList()
                        };
                        WriteJson(ns, result);
                        BroadcastFoods();
                    }
                    else if (action == "RANDOM")
                    {
                        string scope = request.GetValueOrDefault("scope", "all");
                        string username = request.GetValueOrDefault("user", "");
                        var info = RandomFood(scope == "self" ? username : null);
                        response["res"] = info ?? new Dictionary<string, string>();
                        WriteJson(ns, response);
                    }
                    else if (action == "DELETE_ALL")
                    {
                        TruncateAll();
                        var result = new Dictionary<string, object>
                        {
                            ["foods"] = GetFoodsList()
                        };
                        WriteJson(ns, result);
                        BroadcastFoods();
                    }
                }
            }
            catch { }
            try { ns.Close(); client.Close(); } catch { }
            lock (clients) clients.Remove(client);
        }

        private void InitDatabase()
        {
            if (!File.Exists("Foods.db")) SQLiteConnection.CreateFile("Foods.db");
            using var conn = new SQLiteConnection(connectionString);
            conn.Open();
            string createUsers = """
                CREATE TABLE IF NOT EXISTS NguoiDung (
                    IDNCC INTEGER PRIMARY KEY AUTOINCREMENT,
                    HoVaTen TEXT NOT NULL
                );
                """;
            string createFoods = """
                CREATE TABLE IF NOT EXISTS MonAn (
                    IDMA INTEGER PRIMARY KEY AUTOINCREMENT,
                    TenMonAn TEXT NOT NULL,
                    HinhAnh TEXT,
                    IDNCC INTEGER,
                    FOREIGN KEY (IDNCC) REFERENCES NguoiDung(IDNCC)
                );
                """;
            foreach (var cmdText in new[] { createUsers, createFoods })
                using (var cmd = new SQLiteCommand(cmdText, conn)) cmd.ExecuteNonQuery();
            AddDefaultData(conn);
        }

        private void AddDefaultData(SQLiteConnection conn)
        {
            string checkFood = "SELECT COUNT(*) FROM MonAn";
            using var cmd = new SQLiteCommand(checkFood, conn);
            long count = (long)cmd.ExecuteScalar();
            if (count > 0) return;
            string[] foods = { "Phở", "Bún bò Huế", "Cơm tấm", "Bánh mì", "Gỏi cuốn" };
            string[] urls =
            {
                "https://cdn2.fptshop.com.vn/unsafe/1920x0/filters:format(webp):quality(75)/cach_nau_pho_bo_nam_dinh_0_1d94be153c.png",
                "https://mms.img.susercontent.com/vn-11134513-7r98o-lsvdf3utj44905@resize_ss640x400!@crop_w640_h400_cT",
                "https://sakos.vn/wp-content/uploads/2024/09/bia.jpg",
                "https://cleverjunior.vn/wp-content/uploads/2022/08/gioi-thieu-banh-mi-bang-tieng-anh-1-768x480.jpg",
                "https://cdn.tcdulichtphcm.vn/upload/2-2021/images/2021-05-14/1620967472-5fd6cc95e23f4d1eb34009678c2d6556.jpg"
            };
            string[] users = { "Nguyen", "Reyna", "Nhan" };
            int[] uids = new int[users.Length];
            for (int i = 0; i < users.Length; i++)
            {
                string insertUser = "INSERT INTO NguoiDung (HoVaTen) VALUES (@n); SELECT last_insert_rowid();";
                using var cmdUser = new SQLiteCommand(insertUser, conn);
                cmdUser.Parameters.AddWithValue("@n", users[i]);
                uids[i] = Convert.ToInt32(cmdUser.ExecuteScalar());
            }
            int[] userIndex = { 0, 1, 2, 0, 1 };
            for (int i = 0; i < foods.Length; i++)
            {
                string insertFood = "INSERT INTO MonAn (TenMonAn, HinhAnh, IDNCC) VALUES (@f, @url, @id)";
                using var cmdFood = new SQLiteCommand(insertFood, conn);
                cmdFood.Parameters.AddWithValue("@f", foods[i]);
                cmdFood.Parameters.AddWithValue("@url", urls[i]);
                cmdFood.Parameters.AddWithValue("@id", uids[userIndex[i]]);
                cmdFood.ExecuteNonQuery();
            }
        }

        private object GetFoodsList()
        {
            List<Dictionary<string, string>> foods = new();
            using var conn = new SQLiteConnection(connectionString);
            conn.Open();
            string query = "SELECT m.IDMA, m.TenMonAn, m.HinhAnh, n.HoVaTen FROM MonAn m INNER JOIN NguoiDung n ON m.IDNCC= n.IDNCC ORDER BY m.IDMA";
            using var cmd = new SQLiteCommand(query, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                foods.Add(new()
                {
                    ["IDMA"] = reader["IDMA"].ToString(),
                    ["TenMonAn"] = reader["TenMonAn"].ToString(),
                    ["HinhAnh"] = reader["HinhAnh"].ToString(),
                    ["HoVaTen"] = reader["HoVaTen"].ToString()
                });
            }
            return foods;
        }

        private int GetOrCreateUser(string name)
        {
            using var conn = new SQLiteConnection(connectionString);
            conn.Open();
            using (var cmd = new SQLiteCommand("SELECT IDNCC FROM NguoiDung WHERE HoVaTen=@Name", conn))
            {
                cmd.Parameters.AddWithValue("@Name", name);
                var res = cmd.ExecuteScalar();
                if (res != null)
                    return Convert.ToInt32(res);
            }
            using (var cmd = new SQLiteCommand("INSERT INTO NguoiDung (HoVaTen) VALUES (@Name)", conn))
            {
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.ExecuteNonQuery();
            }
            using (var cmd = new SQLiteCommand("SELECT last_insert_rowid();", conn))
                return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private void AddFood(string food, string image, int idncc)
        {
            using var conn = new SQLiteConnection(connectionString);
            conn.Open();
            using var cmd = new SQLiteCommand("INSERT INTO MonAn (TenMonAn, HinhAnh, IDNCC) VALUES (@food, @img, @idncc)", conn);
            cmd.Parameters.AddWithValue("@food", food);
            cmd.Parameters.AddWithValue("@img", image);
            cmd.Parameters.AddWithValue("@idncc", idncc);
            cmd.ExecuteNonQuery();
        }

        private object RandomFood(string username = null)
        {
            using var conn = new SQLiteConnection(connectionString);
            conn.Open();
            string query = "SELECT m.TenMonAn, m.HinhAnh, n.HoVaTen FROM MonAn m INNER JOIN NguoiDung n ON m.IDNCC=n.IDNCC " + ((username != null) ? "WHERE n.HoVaTen=@User " : "") + "ORDER BY RANDOM() LIMIT 1";
            using var cmd = new SQLiteCommand(query, conn);
            if (username != null) cmd.Parameters.AddWithValue("@User", username);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Dictionary<string, string>
                {
                    ["TenMonAn"] = reader["TenMonAn"].ToString(),
                    ["HinhAnh"] = reader["HinhAnh"].ToString(),
                    ["HoVaTen"] = reader["HoVaTen"].ToString()
                };
            }
            return null;
        }

        private void TruncateAll()
        {
            using var conn = new SQLiteConnection(connectionString);
            conn.Open();
            foreach (var sql in new[]
            {
                "DELETE FROM MonAn;",
                "DELETE FROM NguoiDung;",
                "DELETE FROM sqlite_sequence WHERE name='MonAn';",
                "DELETE FROM sqlite_sequence WHERE name='NguoiDung';"
            })
                using (var cmd = new SQLiteCommand(sql, conn))
                    cmd.ExecuteNonQuery();
            AddDefaultData(conn);
        }

        private string ReadLine(NetworkStream ns)
        {
            StringBuilder sb = new();
            int b;
            while ((b = ns.ReadByte()) >= 0)
            {
                if (b == '\n') break;
                sb.Append((char)b);
            }
            return sb.Length > 0 ? sb.ToString() : null;
        }
        private void WriteJson(NetworkStream ns, object obj)
        {
            var str = JsonSerializer.Serialize(obj) + "\n";
            var buf = Encoding.UTF8.GetBytes(str);
            ns.Write(buf, 0, buf.Length);
        }
        private void BroadcastFoods()
        {
            var msg = JsonSerializer.Serialize(new Dictionary<string, object> { ["foods"] = GetFoodsList() }) + "\n";
            var buf = Encoding.UTF8.GetBytes(msg);
            lock (clients)
            {
                foreach (var cli in clients.ToList())
                {
                    try { if (cli.Connected) cli.GetStream().Write(buf, 0, buf.Length); }
                    catch { }
                }
            }
        }

        private void AddMessage(string msg)
        {
            if (InvokeRequired)
                Invoke(new Action<string>(AddMessage), msg);
            else
            {
                lstLog.Items.Add(msg);
                lstLog.TopIndex = lstLog.Items.Count - 1;
            }
        }
    }
}
