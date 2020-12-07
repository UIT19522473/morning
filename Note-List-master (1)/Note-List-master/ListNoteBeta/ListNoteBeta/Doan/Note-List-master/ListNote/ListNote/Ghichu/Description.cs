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
    public partial class Description : Form
    {
        protected Account curAcc = new Account();
        private string nameOfNote = "";
        private int typeOfNote = -1;
        private string des = "";
        public Description()
        {
            InitializeComponent();
        }
        public string NameOfNote { get => nameOfNote; set => nameOfNote = value; }
        public int TypeOfNote { get => typeOfNote; set => typeOfNote = value; }
        public string Des { get => des; set => des = value; }
        public Account CurAcc { get => curAcc; set => curAcc = value; }

        private void GetNameAndDesOfNote()
        {
            label1.Text = nameOfNote;
            textBox1.Text = Des;

        }

        private void Description_Load(object sender, EventArgs e)
        {
            GetNameAndDesOfNote();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection Connect = new SqlConnection(curAcc.query);
            Connect.Open();
            string query = "UPDATE Note SET fDescription='" + textBox1.Text + "' WHERE Username = '" + curAcc.Username + "' AND Things = '" + NameOfNote + "' AND ThingType = '" + TypeOfNote + "'";
            SqlCommand Command = new SqlCommand(query, Connect);
            Command.ExecuteNonQuery();
            Connect.Close();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection Connect = new SqlConnection(curAcc.query);
            Connect.Open();
            string query = "Delete FROM Note " + "WHERE Username = '" + curAcc.Username + "' AND Things = '" + NameOfNote + "' AND ThingType = '" + TypeOfNote + "'";
            SqlCommand Command = new SqlCommand(query, Connect);
            Command.ExecuteNonQuery();
            Connect.Close();
            this.Close();
        }
    }
}
