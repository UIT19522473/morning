using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ListNote
{
    public partial class ListEvent : Form
    {
        Account acc = new Account();
        string Admin = "";
       // DateTime dayTime;
        string InDTPK = "";

        string TimeStart = "";
        string TimeEnd = "";

        int chanel = 0;

        public string TileYMD;
        public string TileYMD1 { get => TileYMD; set => TileYMD = value; }

        string CurDay, CurMonth, CurYear;

        DataTable tb = new DataTable();

        

        public ListEvent()
        {
            InitializeComponent();
        }
        //DailyEvent dlev = new DailyEvent("tuan", dtpkDate.Value, (sender as Button).Text);

        public ListEvent(string User,DateTime dayUser, string day)
        {
            InitializeComponent();
            Admin = User;
            InDTPK = InDTPK + dayUser.Month.ToString() + "/" + day + "/" + dayUser.Year.ToString();

            CurDay = day;   CurMonth = dayUser.Month.ToString();    CurYear = dayUser.Year.ToString();

        }

        public ListEvent(string User, DateTime dayUser, string day, int x, string TimeS,string TimeE)
        {
            InitializeComponent();
            Admin = User;
            InDTPK = InDTPK + dayUser.Month.ToString() + "/" + day + "/" + dayUser.Year.ToString();

            CurDay = day; CurMonth = dayUser.Month.ToString(); CurYear = dayUser.Year.ToString();

            chanel = x;

            TimeStart = TimeS;

            TimeEnd = TimeE;
        }

        public void LoadData()
        {
            if(chanel == 0)
            {
                string query = acc.query;
                SqlConnection connection = new SqlConnection(query);
                connection.Open();
                string cmdquery = "SELECT * FROM DailyEvent WHERE InUser = '" + Admin + "' and InDTPK = '" + InDTPK + "'";
                SqlCommand cmd = new SqlCommand(cmdquery, connection);
                try
                {
                    SqlDataAdapter read = new SqlDataAdapter(cmdquery, connection);
                    read.Fill(tb);

                    connection.Close();

                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        DataGridViewRow row = (DataGridViewRow)dgvShow.Rows[i].Clone();

                        //tb.Rows.Remove(tb.Rows[i]);
                        string s = tb.Rows[i][7] + "-" + tb.Rows[i][8];
                        row.Cells[0].Value = s;
                        row.Cells[1].Value = tb.Rows[i][3];
                        dgvShow.Rows.Add(row);
                    }
                }
                catch
                {

                }
            }

            else
            {
                ChildLoadData();
            }
            
            
        }

        int ReTime(string n)
        {
            string[] k = n.Split(':', ' ');
            int rex;
            if (k[2] == "AM")
            {
                int tm;
                if(k[0]=="12")
                {
                    tm = 0;
                    rex = tm + Int32.Parse(k[1]) * 60;
                }
               else
                {
                    rex = Int32.Parse(k[0]) * 3600 + Int32.Parse(k[1]) * 60;
                }
               
            }
            else
            {
                if (k[0] != "12")
                    rex = (Int32.Parse(k[0]) + 12) * 3600 + Int32.Parse(k[1]) * 60;
                else
                    rex = (Int32.Parse(k[0])) * 3600 + Int32.Parse(k[1]) * 60;
                
            }
            return rex;
        }

        int Dex(int a, int b)
        {
            if (a < b)
                return b - a;
            else return a - b;
        }
        // thu nghiem
        void ChildLoadData()
        {
            int timeStart = ReTime(TimeStart);
            int timeEnd = ReTime(TimeEnd);

            string query = acc.query;
            SqlConnection connection = new SqlConnection(query);
            connection.Open();
            string cmdquery = "SELECT * FROM DailyEvent WHERE InUser = '" + Admin + "' and InDTPK = '" + InDTPK + "'";
            SqlCommand cmd = new SqlCommand(cmdquery, connection);
            try
            {
                SqlDataAdapter read = new SqlDataAdapter(cmdquery, connection);
                read.Fill(tb);

                connection.Close();

                for (int i = 0; i < tb.Rows.Count;)
                {
                    int timeSTUp = ReTime(tb.Rows[i][7].ToString()); 
                    int timeEndUp = ReTime(tb.Rows[i][8].ToString());
                  
                    if((Dex(timeSTUp, timeStart) < 1800))
                    {
                        i++;
                    }

                    else if(!((timeSTUp<=timeStart&&timeStart<=timeEndUp)&&(timeSTUp<=timeEnd&&timeEnd<=timeEndUp)))
                    {
                        tb.Rows.Remove(tb.Rows[i]);
                    }
                    else
                    {
                        i++;
                    }

                }

                for(int j = 0; j<tb.Rows.Count;j++)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvShow.Rows[j].Clone();
                    string s = tb.Rows[j][7] + "-" + tb.Rows[j][8];
                    row.Cells[0].Value = s;
                    row.Cells[1].Value = tb.Rows[j][3];
                    dgvShow.Rows.Add(row);
                }
            }
            catch
            {

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ListEvent_Load(object sender, EventArgs e)
        {
            LoadData();
            this.lbTile.Text = TileYMD;
        }

        private void dgvShow_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int curIndex = dgvShow.CurrentRow.Index;
                DailyEvent DlEv = new DailyEvent(Admin, InDTPK, tb.Rows[curIndex][11].ToString());
                this.Hide();
                DlEv.ShowDialog();
              
            }
            catch
            {

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DailyEvent DlEv = new DailyEvent(Admin,InDTPK);
            DlEv.CurYear = CurYear;
            DlEv.CurDay = CurDay;
            DlEv.CurMonth = CurMonth;
            this.Hide();
            DlEv.ShowDialog();
            this.Close();
        }

    }
}
