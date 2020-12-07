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
    public partial class Calendar : Form
    {
        protected Account curAcc;
        #region Peoperties


        string InUser ="";

        private List<List<Button>> matrix;
        public List<List<Button>> Matrix { get => matrix; set => matrix = value; }
        public Account CurAcc { get => curAcc; set => curAcc = value; }
        

        private List<string> dateOfWeek = new List<string>() { "Monday"
        ,"Tuesday","Wednesday","Thursday","Friday","Saturday","Sunday"};
        #endregion
        public Calendar()
        {
            CurAcc = new Account();
            InitializeComponent();
        }
        private void Calendar_Load(object sender, EventArgs e)
        {
            InUser = curAcc.Username;
            LoadMatrix();
        }
       // string InUser = curAcc.Username;

        void LoadMatrix()
        {
            Matrix = new List<List<Button>>();
            Button oldBtn = new Button() { Width = 0, Height = 0, Location = new Point(-Cons.Margin, 0) };
            for (int i = 0; i < Cons.DayOffColumn; i++)
            {
                Matrix.Add(new List<Button>());
                for (int j = 0; j < Cons.DayOfweek; j++)
                {
                    Button a = new Button() { Height = Cons.Height, Width = Cons.Width };

                    //----------

                    //----------
                    a.FlatAppearance.BorderSize = 0;
                    // a.
                    a.Font = new Font("Nirmala UI", 12f);
                    a.FlatAppearance.BorderColor = Color.LightSkyBlue;
                    a.TextAlign = ContentAlignment.TopLeft;
                    a.FlatStyle = FlatStyle.Flat;

                    a.Location = new Point(oldBtn.Location.X + oldBtn.Width + Cons.Margin, oldBtn.Location.Y);

                    a.Click += A_Click;

                    pnMatrix.Controls.Add(a);
                    Matrix[i].Add(a);
                    oldBtn = a;

                }
                oldBtn = new Button() { Width = 0, Height = 0, Location = new Point(-Cons.Margin, oldBtn.Location.Y + Cons.Height+1) };
            }

            SetDefaultDate();
        }

        private void A_Click(object sender, EventArgs e)
        {
            if((sender as Button).Text!="")
            {
                //--
                string[] temp = (sender as Button).Name.Split('/');
                //--

                ListEvent LEvent = new ListEvent(curAcc.Username, this.dtpkDate.Value, temp[1]);
                
                LEvent.Location = new Point((sender as Button).Location.X+150, (sender as Button).Location.Y);

                string s = "";
                DateTime test = new DateTime(this.dtpkDate.Value.Year,this.dtpkDate.Value.Month, Int32.Parse(temp[1]));
                s = s + test.DayOfWeek.ToString() + ", " + NameMonth(dtpkDate.Value.Month.ToString()) + " " + temp[1] + ", " + dtpkDate.Value.Year.ToString();
                LEvent.TileYMD = s;
                LEvent.ShowDialog();
                SetDefaultDate();
                //this.Refresh();
                ////SetDateIng();
                this.Show();
            }
        }

        
        void AddNumberIntoMatrixByDate(DateTime date)
        {
            Clear();
            DateTime useDate = new DateTime(date.Year, date.Month, 1);

            int line = 0;
            for (int i = 1; i <= DayofMonth(date); i++)
            {
                int column = dateOfWeek.IndexOf(useDate.DayOfWeek.ToString());
                Button btn = Matrix[line][column];

                btn.Name = date.Month.ToString()+"/"+i.ToString()+"/"+date.Year.ToString();

                btn.Text = i.ToString();

                if (column >= 6)
                    line++;
                List<string> NameE = new List<string>();
                //if(checkEvent(useDate,InUser, NameE))
                //{
                //    //btn.BackColor = Color.Red;

                //    btn.ForeColor = Color.Red;

                //    for(int u = 0; u<NameE.Count; u++)
                //    {
                //        btn.Text = btn.Text + "\n" + NameE[u];
                //    }
                    
                //}
               /* else */if (isEqualDate(useDate, date))
                {
                    btn.BackColor = Color.Blue;
                }

                else if (isEqualDate(useDate, DateTime.Now))
                {
                    btn.BackColor = Color.Yellow;
                }

                useDate = useDate.AddDays(1);

            }

            DateTime useDate2 = new DateTime(date.Year, date.Month, 1);
            checkEV(useDate2, InUser);


        }


        void checkEV(DateTime Date, string InUser/*, List<string> NameEv*/)
        {
            DataTable tb = new DataTable();
            SqlConnection sql = new SqlConnection(curAcc.query);
            sql.Open();
            SqlDataAdapter read = new SqlDataAdapter("select *from DailyEvent where MONTH(InDTPK) = '" + Date.Month.ToString() + "' and InUser = '" + InUser + "' order by (day(DateTimeEnd) - day(DateTimeStart))", sql);
            read.Fill(tb);
            List<string> arr = new List<string>();
            DataTable temp = new DataTable();
            arr.Add("-1");
           for(int i = 0; i<tb.Rows.Count-1; i++)
           {
                for(int j = i+1;j<tb.Rows.Count; )
                {
                    if (tb.Rows[i][11].ToString() == tb.Rows[j][11].ToString())
                    {
                        tb.Rows.Remove(tb.Rows[j]);
                    }
                    else j++;
                }
           }
            
            //for(int i = tb.Rows.Count-1; i>=0; i--)
            //{
            //    string[] n1 = tb.Rows[i][5].ToString().Split('/');
            //    string[] n2 = tb.Rows[i][6].ToString().Split('/');
            //    string Name = tb.Rows[i][3].ToString();

            //    int a = Int32.Parse(n1[1]);
            //    int b = Int32.Parse(n2[1]);
            //    int count = MaxCountBtn(a, b);
            //    addText(a, b, Name, count,Date);
            //}

            for (int i = tb.Rows.Count - 1; i >= 0; i--)
            {
                string[] n1 = tb.Rows[i][5].ToString().Split('/');
                string[] n2 = tb.Rows[i][6].ToString().Split('/');
                string Name = tb.Rows[i][3].ToString();

                DateTime a = new DateTime(Int32.Parse(n1[2]), Int32.Parse(n1[0]), Int32.Parse(n1[1]));

                DateTime b = new DateTime(Int32.Parse(n2[2]), Int32.Parse(n2[0]), Int32.Parse(n2[1]));

                //int a = Int32.Parse(n1[1]);
                //int b = Int32.Parse(n2[1]);
                int count = MaxCountBtn(a, b);
                addText(a, b, Name, count, Date);
            }
        }

        int MaxCountBtn(DateTime a, DateTime b)
        {
            int max = 0;

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Button x = Matrix[i][j];
                    string[] temp = x.Name.Split('/');
                    if (x.Name == "")
                    {
                        j++;
                    }

                    else
                    {
                        DateTime main = new DateTime(Int32.Parse(temp[2]), Int32.Parse(temp[0]), Int32.Parse(temp[1]));
                        if(main>=a &&main<=b)
                        {
                            string[] sum = x.Text.ToString().Split('\n');
                            if (max < sum.Length)
                            {
                                max = sum.Length;
                            }
                        }
                       
                    }
                }
            }
            return max;
        }

        void addText(DateTime a, DateTime b, string name, int count, DateTime check)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Button x = Matrix[i][j];
                    string[] temp1 = x.Name.Split('/');

                    if (x.Name == "")
                    {
                        j++;
                    }
                    else
                    {
                        DateTime main = new DateTime(Int32.Parse(temp1[2]), Int32.Parse(temp1[0]), Int32.Parse(temp1[1]));
                        DateTime comp = new DateTime(check.Year, check.Month, Int32.Parse(temp1[1]));
                        if(main>=a && main<=b)
                        {

                            if (main == a || temp1[1] == "1" || comp.DayOfWeek.ToString() == "Monday")
                            {
                                string[] sum = x.Text.ToString().Split('\n');
                                int temp = sum.Length;
                                x.Text = x.Text + ReSpace(count - temp) + name+Line(name);
                                x.ForeColor = Color.Red;
                            }

                            else
                            {
                                if (x.Name.ToString() != "")
                                {
                                    string[] sum = x.Text.ToString().Split('\n');
                                    int temp = sum.Length;
                                    x.Text = x.Text + ReSpace(count - temp) + "-----------------";
                                    x.ForeColor = Color.Red;
                                }

                            }
                        }


                    }
                }
            }
        }

        string Line(string s)
        {
            string k = "";

            for(int i = 0; i<17-s.Length*2;i++)
            {
                k += "-";
            }
            return k;
        }

        string ReSpace(int count)
        {
            string s = "";
            for(int i = 0; i<=count; i++)
            {
                s += "\n";
            }
            return s;
        }
        
        bool checkEvent(DateTime useDate,string InUser,List<string> NameEv)
        {
            string s = "";
            s = s + useDate.Month.ToString() + "/" + useDate.Day.ToString() + "/" + useDate.Year.ToString();

            DataTable tb = new DataTable();
            SqlConnection sql = new SqlConnection(curAcc.query);
            sql.Open();
            SqlDataAdapter read = new SqlDataAdapter("select *from DailyEvent where InDTPK = '" + s + "' and InUser = '" + InUser + "'", sql);
            read.Fill(tb);
            List<int> arr = new List<int>();

            for (int j = 0; j < tb.Rows.Count; j++)
            {
                if (tb.Rows[j][0].ToString() == s)
                {
                    sql.Close();
                    arr.Add(Int32.Parse(tb.Rows[j][11].ToString()));
                }

                if (j == tb.Rows.Count -1)
                {
                    arr.Sort();

                    for(int h = 0; h<arr.Count; h++)
                    {
                        for(int f = 0; f<arr.Count; f++)
                        {
                            if(Int32.Parse(tb.Rows[f][11].ToString())==arr[h])
                            {
                               // NameEv.Add(tb.Rows[f][3].ToString());


                                if (tb.Rows[f][0].ToString() == tb.Rows[f][5].ToString())
                                    NameEv.Add(tb.Rows[f][3].ToString()+" "+Line(tb.Rows[f][3].ToString().Length));
                                else
                                {
                                    string temp = "-----------------";
                                    NameEv.Add(temp);
                                }


                            }
                        }
                    }


                    return true;
                }
            }
                sql.Close();

            return false;
        }


        string Line(int k)
        {
            string row = "";
            int n = 17 - k*2;
            for(int i = 0; i<n;i++)
            {
                row += "-";
            }    
            return row;
        }
            
        void SetDefaultDate()
        {
            dtpkDate.Value = DateTime.Now;

           // dtpkDate.Value = dtpkDate.Value;
        }

        void SetDateIng()
        {
            dtpkDate.Value = dtpkDate.Value;
        }

        void Clear()
        {
            for (int i = 0; i < Matrix.Count; i++)
            {
                for (int j = 0; j < Matrix[i].Count; j++)
                {
                    Button x = Matrix[i][j];
                    x.Text = "";
                    x.ForeColor = Color.Black;
                    x.BackColor = Color.WhiteSmoke;
                }
            }
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

        bool isEqualDate(DateTime a, DateTime b)
        {
            return a.Year == b.Year && a.Month == b.Month && a.Day == b.Day;
        }
        private void dtpkDate_ValueChanged_1(object sender, EventArgs e)
        {
            AddNumberIntoMatrixByDate((sender as DateTimePicker).Value);
            this.lbDay.Text = NameMonth(dtpkDate.Value.Month.ToString())+" "+dtpkDate.Value.Year.ToString();
        }

        private void MonthBF_Click_1(object sender, EventArgs e)
        {
            dtpkDate.Value = dtpkDate.Value.AddMonths(-1);
        }

        private void MonthATer_Click_1(object sender, EventArgs e)
        {
            dtpkDate.Value = dtpkDate.Value.AddMonths(1);
        }

        private void btnDayNow_Click_1(object sender, EventArgs e)
        {
            SetDefaultDate();
        }
        int DayofMonth(DateTime date)
        {
            switch (date.Month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 2:
                    if ((date.Year % 4 == 0 && date.Year % 100 != 0) || date.Year % 400 == 0)
                        return 29;
                    else return 28;
                default:
                    return 30;
            }
        }

    }
}
