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
    public partial class DailyEvent : Form
    {
        protected Account curacc = new Account();
        DataTable BigTb = new DataTable();
        //public string Date = "";

        public string curMonth;
        private string getDate()
        {
            return this.txtStartEvent.Text;
        }

        public string CurMonth { get => curMonth; set => curMonth = value; }

        public string curDay;
        public string CurDay { get => curDay; set => curDay = value; }


        public string curYear;
        public string CurYear { get => curYear; set => curYear = value; }



        public DailyEvent()
        {
            InitializeComponent();

        }

        private void SetValueDTPKSE()
        {
            try
            {
                dtpkStartEvent.Value = new DateTime(Int32.Parse(CurYear), Int32.Parse(CurMonth), Int32.Parse(CurDay));
                dtpkEndEvent.Value = new DateTime(Int32.Parse(CurYear), Int32.Parse(CurMonth), Int32.Parse(CurDay));
            }
            catch
            {

            }

        }

        string InID = "";
        string inDTPK = "", InUser = "", EventName = "", TimeReminder = "";
        string Locations = "", DateTimeStart = "", DateTimeEnd = "";
        string TimeInDayStart = "", TimeInDayEnd = "", CkbAllDay = "", EventDescription = "";



        private void dtpkStartEvent_ValueChanged(object sender, EventArgs e)
        {
            txtStartEvent.Text = dtpkStartEvent.Value.Month.ToString() + "/" + dtpkStartEvent.Value.Day.ToString() + "/" + dtpkStartEvent.Value.Year.ToString();
        }

        private void dtpkEndEvent_ValueChanged(object sender, EventArgs e)
        {
            if (dtpkEndEvent.Value < dtpkStartEvent.Value)
            {
                dtpkEndEvent.Value = dtpkStartEvent.Value;
                txtEndEvent.Text = dtpkEndEvent.Value.Month.ToString() + "/" + dtpkEndEvent.Value.Day.ToString() + "/" + dtpkEndEvent.Value.Year.ToString();
            }
            else
            {
                txtEndEvent.Text = dtpkEndEvent.Value.Month.ToString() + "/" + dtpkEndEvent.Value.Day.ToString() + "/" + dtpkEndEvent.Value.Year.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
            MessageBox.Show("Xoa Thanh Cong ");
            this.Close();
        }

        private void lbReminder_Click(object sender, EventArgs e)
        {

        }

        private void cmbReminder_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ckbAllD_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbAllD.Checked == true)
            {
                CkbAllDay = "1";
                this.cmbTimeStart.Enabled = false;
                this.cmbTimeEnd.Enabled = false;
                this.cmbTimeStart.Text = "12:00 AM";
                this.cmbTimeEnd.Text = "12:00 AM";
            }
            else
            {
                CkbAllDay = "0";
                this.cmbTimeStart.Enabled = true;
                this.cmbTimeEnd.Enabled = true;
            }
        }

        private void txtEventName_TextChanged(object sender, EventArgs e)
        {
            //this.txtEventName.Text.Replace();
        }

        private void DailyEvent_Load(object sender, EventArgs e)
        {
            SetValueDTPKSE();
        }

        private void btnAddDCM_Click(object sender, EventArgs e)
        {
            Taolich.DailyDocument d = new Taolich.DailyDocument();
            d.Username = this.InUser;
            d.Date = this.getDate();
            this.Hide();
            d.ShowDialog();
            this.Show();
        }

        int SumEvent()
        {
            try
            {
                int max = 0;
                SqlConnection sql = new SqlConnection(curacc.query);
                sql.Open();
                // MessageBox.Show("select *from DailyEvent where InDTPK = '" + inDTPK + "' and InUser = '" + InUser + "' and Id = '" + InID + "'");
                SqlDataAdapter read = new SqlDataAdapter("select *from DailyEvent where InUser = '" + InUser + "'", sql);
                read.Fill(BigTb);
                sql.Close();
                for (int i = 0; i < BigTb.Rows.Count; i++)
                {
                    if (Int32.Parse(BigTb.Rows[i][11].ToString()) >= max)
                    {
                        max = Int32.Parse(BigTb.Rows[i][11].ToString());
                    }
                }
                return max + 1;
            }
            catch
            {
                return 0;
            }
            //string query = curacc.query;
            //SqlConnection connection = new SqlConnection(query);
            //connection.Open();


        }

        void Save(DateTime T1, DateTime T2, string SId)
        {
            //T2 = T2.AddDays(1);
            bool Set = true;
            string query = curacc.query;
            SqlConnection connection = new SqlConnection(query);
            connection.Open();
            RememberInfor();
            while (Set)
            {
                if (T1.Day == T2.Day && T1.Month == T2.Month && T1.Year == T2.Year)
                {
                    Set = false;
                }

                string InDt = "";
                InDt = InDt + T1.Month.ToString() + "/" + T1.Day.ToString() + "/" + T1.Year.ToString();
                // string cmdquery = "SELECT * FROM Account WHERE USERNAME = '@username' AND PASSWORD = '@password'";
                string cmdquery = "INSERT INTO DailyEvent values ('" + InDt + "','" + InUser + "','" + TimeReminder + "','" + EventName + "','" + Locations + "','" + DateTimeStart +
                    "','" + DateTimeEnd + "','" + TimeInDayStart + "','" + TimeInDayEnd + "','" + CkbAllDay + "','" + EventDescription + "','" + SId + "')";

                SqlCommand cmd = new SqlCommand(cmdquery, connection);

                //  MessageBox.Show(cmdquery);



                cmd.ExecuteNonQuery();
                T1 = T1.AddDays(1);

            }
            connection.Close();


        }

        void Delete()
        {
            try
            {
                SqlConnection connection = new SqlConnection(curacc.query);
                connection.Open();
                string cmdquery = "delete from DailyEvent where InUser = '" + InUser + "' and Id = '" + InID + "'";
                //  MessageBox.Show(cmdquery);
                SqlCommand cmd = new SqlCommand(cmdquery, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {

            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            string n = SumEvent().ToString();
            Delete();
            Save(this.dtpkStartEvent.Value, this.dtpkEndEvent.Value, n);
            MessageBox.Show("Luu Thanh Cong");
            //Calendar CLdar = new Calendar();
            //CLdar.Show();
            this.Close();
            //SqlConnection Connect = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DTBEvent;Integrated Security=True");
            //Connect.Open();
            //string query = "INSERT INTO DailyEvent VALUES "
        }


        void LoadSql()
        {
            try
            {
                DataTable tb = new DataTable();
                SqlConnection sql = new SqlConnection(curacc.query);
                sql.Open();
                // MessageBox.Show("select *from DailyEvent where InDTPK = '" + inDTPK + "' and InUser = '" + InUser + "' and Id = '"+ InID + "'");
                SqlDataAdapter read = new SqlDataAdapter("select *from DailyEvent where InDTPK = '" + inDTPK + "' and InUser = '" + InUser + "' and Id = '" + InID + "'", sql);
                read.Fill(tb);
                sql.Close();


                cmbReminder.Text = tb.Rows[0][2].ToString();
                txtEventName.Text = tb.Rows[0][3].ToString();
                txtlocation.Text = tb.Rows[0][4].ToString();
                txtStartEvent.Text = tb.Rows[0][5].ToString();
                txtEndEvent.Text = tb.Rows[0][6].ToString();
                cmbTimeStart.Text = tb.Rows[0][7].ToString();
                cmbTimeEnd.Text = tb.Rows[0][8].ToString();
                txtEventDcrt.Text = tb.Rows[0][10].ToString();

                if (tb.Rows[0][9].ToString() == "True")
                {
                    ckbAllD.Checked = true;
                }
                else
                {
                    ckbAllD.Checked = false;
                }

                try
                {
                    string[] TimeStart;
                    string[] TimeEnd;

                    TimeStart = txtStartEvent.Text.Split('/');
                    TimeEnd = txtEndEvent.Text.Split('/');

                    this.dtpkStartEvent.Value = new DateTime(int.Parse(TimeStart[2]), int.Parse(TimeStart[0]), int.Parse(TimeStart[1]));
                    this.dtpkEndEvent.Value = new DateTime(int.Parse(TimeEnd[2]), int.Parse(TimeEnd[0]), int.Parse(TimeEnd[1]));
                }
                catch
                {

                }
            }
            catch
            {
                MessageBox.Show("Chua Co Du lieu");
            }

        }


        void RememberInfor()
        {
            TimeReminder = cmbReminder.Text;
            EventName = txtEventName.Text;
            Locations = txtlocation.Text;
            DateTimeStart = txtStartEvent.Text;
            DateTimeEnd = txtEndEvent.Text;
            TimeInDayStart = cmbTimeStart.Text;
            TimeInDayEnd = cmbTimeEnd.Text;
            if (ckbAllD.Checked == true)
            {
                CkbAllDay = "1";
            }
            else
            {
                CkbAllDay = "0";
            }
            EventDescription = txtEventDcrt.Text;

        }

        //string Time = "";

        public DailyEvent(string User, string Time, string Id)
        {
            InitializeComponent();
            inDTPK = Time;
            InUser = User;
            InID = Id;
            LoadSql();
            //this.ShowDialog();
        }
        public DailyEvent(string User, string Time)
        {
            InitializeComponent();
            inDTPK = Time;
            InUser = User;
            //InID = Id;
            //LoadSql();
            //this.ShowDialog();
        }
    }
}
