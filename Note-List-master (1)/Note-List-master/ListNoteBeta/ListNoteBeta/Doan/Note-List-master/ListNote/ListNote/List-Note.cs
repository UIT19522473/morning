using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListNote
{
    public partial class ListNote : Form
    {
        
        protected Account curacc;

        public Account Curacc { get => curacc; set => curacc = value; }

        string Admin;

        public ListNote()
        {
            curacc = new Account();
            InitializeComponent();

        }
        private void UpData()
        {
            
            string query = curacc.query;
            SqlConnection connect = new SqlConnection(query);
            connect.Open();
            string cmdquery = "SELECT * FROM DailyEvent WHERE InUser = '" + this.curacc.Username + "'";
            SqlCommand cmd = new SqlCommand(cmdquery, connect);
            SqlDataReader read =  cmd.ExecuteReader();
            while(read.HasRows)
            {
                if (read.Read() == false) break;
                Curacc.JobList.Add(new Job(read.GetString(0), read.GetString(1), read.GetString(2), read.GetString(3), read.GetString(4), read.GetString(5), read.GetString(6), read.GetString(7), read.GetString(8), read.GetBoolean(9), read.GetString(10)));
            }
        }
        private void bntDocument_Click(object sender, EventArgs e)
        {
            PreDocuments pre = new PreDocuments();
            pre.Username = this.curacc.Username;
            Hide();
            pre.ShowDialog();
            this.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Screen scr = Screen.PrimaryScreen; //đi lấy màn hình chính
            this.Left = (scr.WorkingArea.Width - this.Width) / 2;
            this.Top = (scr.WorkingArea.Height - this.Height) / 2;
            //UpData();

            Calendar Cldar = new Calendar() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Cldar.CurAcc = this.curacc;
            this.pnShow.Controls.Add(Cldar);
            Cldar.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnWeek_Click(object sender, EventArgs e)
        {
            this.pnShow.Controls.Clear();
            CldWeek ClWeek = new CldWeek() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            ClWeek.CurAcc = this.curacc;
            this.pnShow.Controls.Add(ClWeek);
            ClWeek.Show();

        }

        private void btnMonth_Click(object sender, EventArgs e)
        {
            // Form1_Load(sender, e);
            this.pnShow.Controls.Clear();
            Calendar Cldar = new Calendar() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Cldar.CurAcc = this.curacc;
            this.pnShow.Controls.Add(Cldar);
            Cldar.Show();
        }

        private void btnNote_Click(object sender, EventArgs e)
        {
            GhiChu fGhiChu = new GhiChu();
            fGhiChu.CurAcc.Username = this.curacc.Username;
            this.Hide();
            fGhiChu.ShowDialog();
            this.Show();
        }
    }
}
