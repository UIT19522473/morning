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
    public partial class SignUp : Form
    {
        Account acc = new Account();
        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            Screen scr = Screen.PrimaryScreen; //đi lấy màn hình chính
            this.Left = (scr.WorkingArea.Width - this.Width) / 2;
            this.Top = (scr.WorkingArea.Height - this.Height) / 2;
        }
        private void SignUpAccount()
        {
            try
            {
                SqlConnection Connect = new SqlConnection(acc.query);
                string query = "INSERT INTO Account VALUES('" + txtUsername.Text + "','" + txtPassword.Text + "')";
                Connect.Open();
                SqlCommand cmd = new SqlCommand(query, Connect);
                cmd.ExecuteReader();
                Connect.Close();
                MessageBox.Show("Signed up successfully", "List Note");
            }
            catch (Exception e)
            {
                MessageBox.Show("This account is exist !", "List Note");
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "" || txtPassword2.Text == "")
            {
                MessageBox.Show("Please enter all fields ! ", "List Note");
            }
            else
            {
                if (txtPassword.Text != txtPassword2.Text)
                {
                    MessageBox.Show("Password does not match !", "List Note");
                }
                else
                {
                    SignUpAccount();
                }
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
