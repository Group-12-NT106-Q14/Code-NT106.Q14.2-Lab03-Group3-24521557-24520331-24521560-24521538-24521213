namespace Code_NT106.Q14._2_Lab03_Group3_24521557_24520331_24521560_24521538_24521213
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnBai01_Click(object sender, EventArgs e)
        {
            Bai01DashboardForm Bai01 = new Bai01DashboardForm();
            Bai01.Show();
        }

        private void btnBai02_Click(object sender, EventArgs e)
        {
            Bai02Form Bai02 = new Bai02Form();
            Bai02.Show();
        }

        private void btnBai03_Click(object sender, EventArgs e)
        {
            Bai03DashboardForm Bai03 = new Bai03DashboardForm();
            Bai03.Show();
        }

        private void btnBai04_Click(object sender, EventArgs e)
        {
            Bai04DashboardForm Bai04 = new Bai04DashboardForm();
            Bai04.Show();
        }
    }
}
