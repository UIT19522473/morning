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
    public partial class Login : Form
    {
        Account acc = new Account();
        public Login()
        {
            InitializeComponent();
        }
        public bool Checkaccount()
        {

            string query = acc.query;
            SqlConnection connection = new SqlConnection(query);
            connection.Open();
            string cmdquery = "SELECT * FROM Account WHERE USERNAME = '" + txtUsername.Text + "' AND PASSWORD = '" + txtPassword.Text + "'";
            SqlCommand cmd = new SqlCommand(cmdquery, connection);
            // cmd.Parameters.AddWithValue("@username", txtUsername.Text);
            //cmd.Parameters.AddWithValue("@password", txtPassword.Text);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read() == true)
                return true;
            return false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            Screen scr = Screen.PrimaryScreen; //đi lấy màn hình chính
            this.Left = (scr.WorkingArea.Width - this.Width) / 2;
            this.Top = (scr.WorkingArea.Height - this.Height) / 2;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Checkaccount())
            {
                MessageBox.Show("Signed in successfully", "Note List");
                ListNote fNoteList = new ListNote();
                fNoteList.Curacc.Username = txtUsername.Text;
                this.Hide();
                fNoteList.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("User or password was wrong !", "NoteList");
            }

        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            SignUp fSu = new SignUp();
            this.Hide();
            fSu.ShowDialog();
            this.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dl = MessageBox.Show("Are you sure want to exit ?", "Note-List", MessageBoxButtons.YesNo);
            if (dl == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                return;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
