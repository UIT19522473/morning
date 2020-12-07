using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListNote
{
    public partial class PreDocuments : Form
    {
        private string username = "";

        public string Username { get => username; set => username = value; }

        public PreDocuments()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PreDocuments_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Form f1 in Application.OpenForms)
            {
                if (f1 is ListNote)
                {
                    f1.Show();
                }
            }
        }

        private void PreDocuments_Load(object sender, EventArgs e)
        {
            Screen scr = Screen.PrimaryScreen; //đi lấy màn hình chính
            this.Left = (scr.WorkingArea.Width - this.Width) / 2;
            this.Top = (scr.WorkingArea.Height - this.Height) / 2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddNewQueryDocument ad = new AddNewQueryDocument();
            ad.Username = this.Username;
            Hide();
            ad.ShowDialog();
            this.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Documents dc = new Documents();
            dc.Username = this.Username;
            this.Hide();
            dc.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //DeletecardForm de = new DeletecardForm();
            //Hide();
            //de.ShowDialog();
            //this.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void MonthBF_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
