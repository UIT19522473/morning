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
    public partial class CldWeek : Form
    {
        string InUser = "";

        private Account curAcc;
        public Account CurAcc { get => curAcc; set => curAcc = value; }

        private List<Button> TbHead;
        public List<Button> TbHead1 { get => TbHead; set => TbHead = value; }


        private List<List<Button>> matrix;
        public List<List<Button>> Matrix { get => matrix; set => matrix = value; }


        public CldWeek()
        {
            InitializeComponent();
        }

        //tao ra ma tran cua tbHead
        void LoadTime()
        {
            DateTime check = dtpkDate.Value;

            Button oldBtn = new Button() { Width = 0, Height = 0, Location = new Point(-Cons.Margin, 0) };
            TbHead = new List<Button>();
            for (int i = 0; i < 7; i++)
            {

                Button a = new Button() { Height = Cons.Height, Width = Cons.Width - 10 };
                a.FlatAppearance.BorderSize = 1;
                a.FlatAppearance.BorderColor = Color.LightSkyBlue;
                a.TextAlign = ContentAlignment.TopLeft;
                a.FlatStyle = FlatStyle.Flat;

                a.Location = new Point(oldBtn.Location.X + oldBtn.Width + Cons.Margin, oldBtn.Location.Y);
                a.Click += A_Click1;
                this.pnDayOfMonth.Controls.Add(a);
               


                TbHead.Add(a);
                oldBtn = a;
            }

            LoadMatrix();
            SetDefaultDate();
        }


        //click matrix
        private void A_Click(object sender, EventArgs e)
        {

            //idea
            string[] temp = (sender as Button).Name.Split('-');

            ListEvent LEvent = new ListEvent(curAcc.Username, this.dtpkDate.Value, temp[0], 1, temp[1], temp[2]);

            LEvent.Location = new Point((sender as Button).Location.X + 150, (sender as Button).Location.Y);

            string s = "";
            DateTime test = new DateTime(this.dtpkDate.Value.Year, this.dtpkDate.Value.Month, Int32.Parse(temp[0]));
            s = s + test.DayOfWeek.ToString() + ", " + NameMonth(dtpkDate.Value.Month.ToString()) + " " + temp[0] + ", " + dtpkDate.Value.Year.ToString();
            LEvent.TileYMD = s;
            LEvent.ShowDialog();
            // SetDefaultDate();
            this.Show();

        }


        //click table
        private void A_Click1(object sender, EventArgs e)
        {
            string[] temp = (sender as Button).Text.Split('/');

           

            if ((sender as Button).Text != "")
            {
                ListEvent LEvent = new ListEvent(curAcc.Username, this.dtpkDate.Value,temp[1]);

                LEvent.Location = new Point((sender as Button).Location.X + 150, (sender as Button).Location.Y);

                string s = "";
                DateTime test = new DateTime(this.dtpkDate.Value.Year, this.dtpkDate.Value.Month, Int32.Parse(temp[1]));
                s = s + test.DayOfWeek.ToString() + ", " + NameMonth(dtpkDate.Value.Month.ToString()) + " " + temp[1] + ", " + dtpkDate.Value.Year.ToString();
                LEvent.TileYMD = s;
                LEvent.ShowDialog();
                SetDefaultDate();
                this.Show();
            }
        }

        // ham add ngay cua cac thu trong tuan
        void AddNumberTbHead(DateTime date)
        {
            ClearTbhead();

            DateTime check = date;

            if (check.DayOfWeek.ToString() != "Monday")
            {
                bool bl = true;
                while (bl)
                {

                    check = check.AddDays(-1);
                    if (check.DayOfWeek.ToString() == "Monday")
                    {
                        bl = false;
                    }
                }
            }


            for (int i = 0; i < TbHead.Count; i++)
            {
                Button btn = TbHead[i];
                btn.Text = check.Month.ToString() + "/" + check.Day.ToString();

                //DateTime useDate = new DateTime(date.Year, date.Month, 1);

                if (checkEvent(check, InUser))
                {
                    btn.BackColor = Color.Red;
                }
               

                check = check.AddDays(1);
            }


        }

        //kiem tra su kien cua tbhead neu thoa de to mau
        bool checkEvent(DateTime useDate, string InUser)
        {
            string s = "";
            s = s + useDate.Month.ToString() + "/" + useDate.Day.ToString() + "/" + useDate.Year.ToString();

            DataTable tb = new DataTable();
            SqlConnection sql = new SqlConnection(curAcc.query);
            sql.Open();
            SqlDataAdapter read = new SqlDataAdapter("select *from DailyEvent where InDTPK = '" + s + "' and InUser = '" + InUser + "'", sql);
            read.Fill(tb);
            for (int j = 0; j < tb.Rows.Count; j++)
            {
                if (tb.Rows[0][j].ToString() == s)
                {
                    sql.Close();

                    return true;
                }

            }

            sql.Close();

            return false;
        }


        //-------------------------

        //tinh tong thoi gian
        int ReTime(string n)
        {
            string[] k = n.Split(':', ' ');
            int rex;
            if (k[2] == "AM")
            {
                int tm;
                if (k[0] == "12")
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

        // ham tri tuyet doi
        int Dex(int a, int b)
        {
            if (a < b)
                return b - a;
            else return a - b;
        }

        //---------------------

        //kiem tra su kien trong ma tran tuan co dung de to mau
        bool checkEventMatrix(DateTime useDate, string InUser,string TimeStart, string TimeEnd)
        {
           // int sum = 0;

            int timeStart = ReTime(TimeStart);
            int timeEnd = ReTime(TimeEnd);

            string s = "";
            s = s + useDate.Month.ToString() + "/" + useDate.Day.ToString() + "/" + useDate.Year.ToString();

            DataTable tb = new DataTable();
            SqlConnection sql = new SqlConnection(curAcc.query);
            sql.Open();
            SqlDataAdapter read = new SqlDataAdapter("select *from DailyEvent where InDTPK = '" + s + "' and InUser = '" + InUser + "'", sql);
            read.Fill(tb);
            sql.Close();
            for (int j = 0; j < tb.Rows.Count;)
            {
               

                int timeSTUp = ReTime(tb.Rows[j][7].ToString());
                int timeEndUp = ReTime(tb.Rows[j][8].ToString());
                
                if ((Dex(timeSTUp, timeStart) < 1800))
                {
                    return true;
                }

                if (!((timeSTUp <= timeStart && timeStart <= timeEndUp) && (timeSTUp <= timeEnd && timeEnd <= timeEndUp)))
                {
                    j++;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        //xoa tbhead
        void ClearTbhead()
        {
            for (int i = 0; i < TbHead.Count; i++)
            {
                Button x = TbHead[i];
                x.BackColor = Color.WhiteSmoke;
                x.Text = "";
            }
        }

        //xoa ma tran
        void ClearMatrix()
        {
            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix[i].Count; j++)
                {
                    Button x = Matrix[i][j];
                    x.Text = "";
                    x.BackColor = Color.White;
                }
            }
        }


        //tao ra ma tran tuan
        void LoadMatrix()
        {
            Matrix = new List<List<Button>>();
            Button oldBtn = new Button() { Width = 0, Height = 0, Location = new Point(-Cons.Margin + 55, 0) };
            for (int i = 0; i < Cons.CountTimeofDay * 2; i++)
            {
                Matrix.Add(new List<Button>());
                for (int j = 0; j < Cons.DayOfweek; j++)
                {
                    Button a = new Button() { Height = Cons.Height / 3, Width = Cons.Width - 10 };

                    a.FlatAppearance.BorderSize = 1;
                    a.FlatAppearance.BorderColor = Color.LightSkyBlue;
                    a.TextAlign = ContentAlignment.TopLeft;
                    a.FlatStyle = FlatStyle.Flat;
                    a.Location = new Point(oldBtn.Location.X + oldBtn.Width + Cons.Margin, oldBtn.Location.Y);
                    //a.Text = i.ToString();
                    a.Click += A_Click;

                    pnMatrix.Controls.Add(a);
                    Matrix[i].Add(a);
                    oldBtn = a;

                }
                oldBtn = new Button() { Width = 0, Height = 0, Location = new Point(-Cons.Margin + 55, oldBtn.Location.Y + Cons.Height / 3) };
            }

            SetDefaultDate();
        }

        //-----------

        //xac dinh event thoa vs button trong ma tran tuan
        string  ChildSerach(string TimeStart, string TimeEnd, string InputDay)
        {
            string final = "";
            int timeStart = ReTime(TimeStart);
            int timeEnd = ReTime(TimeEnd);
            DataTable tb = new DataTable();

            string query = curAcc.query;
            SqlConnection connection = new SqlConnection(query);
            connection.Open();
            string cmdquery = "SELECT * FROM DailyEvent WHERE InUser = '" + InUser + "' and InDTPK = '" + InputDay + "'";
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

                    if ((Dex(timeSTUp, timeStart) < 1800))
                    {
                        i++;
                    }

                    else if (!((timeSTUp <= timeStart && timeStart <= timeEndUp) && (timeSTUp <= timeEnd && timeEnd <= timeEndUp)))
                    {
                        tb.Rows.Remove(tb.Rows[i]);
                    }
                    else
                    {
                        i++;
                    }

                }

                for (int j = 0; j < tb.Rows.Count; j++)
                {
                    final += " | ";
                    final += tb.Rows[j][3];
                    
                }
            }
            catch
            {

            }
            return final;
        }
        
       // them ten event tuong ung
        void Search()
        {
            for (int i = 0; i < matrix.Count; i++)
            {
                //DateTime temp = check;
                for (int j = 0; j < matrix[i].Count; j++)
                {

                   
                    Button x = matrix[i][j];
                    string[] n = x.Name.Split('-');
                    string day = this.dtpkDate.Value.Month.ToString() + "/" + n[0] + "/" + this.dtpkDate.Value.Year.ToString();
                    if(x.BackColor == Color.Tomato)
                    {
                        x.Text = ChildSerach(n[1],n[2],day);
                    }

                }
            }
        }
        //------------

        // them mau cho lich tuan
        void AddNumberMatrix(DateTime date)
        {
            ClearMatrix();
            DateTime check = date;

            if (check.DayOfWeek.ToString() != "Monday")
            {
                bool bl = true;
                while (bl)
                {

                    check = check.AddDays(-1);
                    if (check.DayOfWeek.ToString() == "Monday")
                    {
                        bl = false;
                    }
                }
            }

            for (int i = 0; i < matrix.Count; i++)
            {
                DateTime temp = check;
                for (int j = 0; j < matrix[i].Count; j++)
                {
                    Button x = matrix[i][j];

                    string n1 = ReturnTime(i);
                    string n2 = ReturnTime(i + 1);

                    //idea
                    x.Name = temp.Day.ToString() + "-" + n1 + "-" + n2;

                    x.ForeColor = Color.Red;

                    if (checkEventMatrix(temp, InUser, n1, n2))
                    {
                      
                        x.BackColor = Color.Tomato;
                        x.ForeColor = Color.White;
                    }
                    
                    temp = temp.AddDays(1);
                }
            }
            Search();

        }

     
        void SetDefaultDate()
        {
            dtpkDate.Value = DateTime.Now;
        }

        private void CldWeek_Load(object sender, EventArgs e)
        {
            InUser = curAcc.Username;
            LoadTime();
        }

        private void button26_Click(object sender, EventArgs e)
        {

        }

        private void MonthATer_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = dtpkDate.Value.AddDays(7);
        }

        private void MonthBF_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(dtpkDate.Value.DayOfWeek.ToString());
            dtpkDate.Value = dtpkDate.Value.AddDays(-7);
        }

        private void dtpkDate_ValueChanged(object sender, EventArgs e)
        {
            AddNumberTbHead((sender as DateTimePicker).Value);
            AddNumberMatrix((sender as DateTimePicker).Value);
        }

        private void btnDayNow_Click(object sender, EventArgs e)
        {
            SetDefaultDate();
        }

        string ReturnTime(int i)
        {
            string s = "";
            switch (i)
            {
                case 0: s = "12:00 AM"; break;
                case 1: s = "12:30 AM"; break;
                case 2: s = "1:00 AM"; break;
                case 3: s = "1:30 AM"; break;
                case 4: s = "2:00 AM"; break;
                case 5: s = "2:30 AM"; break;
                case 6: s = "3:00 AM"; break;
                case 7: s = "3:30 AM"; break;
                case 8: s = "4:00 AM"; break;
                case 9: s = "4:30 AM"; break;
                case 10: s = "5:00 AM"; break;
                case 11: s = "5:30 AM"; break;
                case 12: s = "6:00 AM"; break;
                case 13: s = "6:30 AM"; break;
                case 14: s = "7:00 AM"; break;
                case 15: s = "7:30 AM"; break;
                case 16: s = "8:00 AM"; break;
                case 17: s = "8:30 AM"; break;
                case 18: s = "9:00 AM"; break;
                case 19: s = "9:30 AM"; break;
                case 20: s = "10:00 AM"; break;
                case 21: s = "10:30 AM"; break;
                case 22: s = "11:00 AM"; break;
                case 23: s = "11:30 AM"; break;
                case 24: s = "12:00 PM"; break;
                case 25: s = "12:30 PM"; break;
                case 26: s = "1:00 PM"; break;
                case 27: s = "1:30 PM"; break;
                case 28: s = "2:00 PM"; break;
                case 29: s = "2:30 PM"; break;
                case 30: s = "3:00 PM"; break;
                case 31: s = "3:30 PM"; break;
                case 32: s = "4:00 PM"; break;
                case 33: s = "4:30 PM"; break;
                case 34: s = "5:00 PM"; break;
                case 35: s = "5:30 PM"; break;
                case 36: s = "6:00 PM"; break;
                case 37: s = "6:30 PM"; break;
                case 38: s = "7:00 PM"; break;
                case 39: s = "7:30 PM"; break;
                case 40: s = "8:00 PM"; break;
                case 41: s = "8:30 PM"; break;
                case 42: s = "9:00 PM"; break;
                case 43: s = "9:30 PM"; break;
                case 44: s = "10:00 PM"; break;
                case 45: s = "10:30 PM"; break;
                case 46: s = "11:00 PM"; break;
                case 47: s = "11:30 PM"; break;
                case 48: s = "12:00 PM"; break;

                default:
                    // code block
                    break;
            }
            return s;
        }

        private string NameMonth(string s)
        {
            switch (s)
            {
                case "1":
                    s = "january";
                    break;
                case "2":
                    s = "February";
                    break;
                case "3":
                    s = "March";
                    break;
                case "4":
                    s = "April";
                    break;
                case "5":
                    s = "May";
                    break;
                case "6":
                    s = "June";
                    break;
                case "7":
                    s = "July";
                    break;
                case "8":
                    s = "August";
                    break;
                case "9":
                    s = "September";
                    break;
                case "10":
                    s = "October";
                    break;
                case "11":
                    s = "November";
                    break;
                case "12":
                    s = "December";
                    break;


                default:
                    break;
            }
            return s;
        }
    }
}
