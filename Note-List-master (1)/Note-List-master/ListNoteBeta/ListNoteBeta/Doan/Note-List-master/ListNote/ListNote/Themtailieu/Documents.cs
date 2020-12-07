using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Diagnostics;
namespace ListNote
{
    public partial class Documents : Form
    {
        Account acc = new Account();
        private string username = "";

        public string Username { get => username; set => username = value; }

        public Documents()
        {
            InitializeComponent();
        }
        private void LoadDocumentList()
        {
            dataGridView1.Rows.Clear();
            SqlConnection Connect = new SqlConnection(acc.query);
            Connect.Open();
            string query = "SELECT DOCUMENTNAME FROM Tailieu WHERE USERNAME = '" + this.username + "';";
            SqlCommand cmd = new SqlCommand(query, Connect);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.HasRows)
            {
                if (r.Read() == false) break;
                dataGridView1.Rows.Add(r.GetString(0));
            }
            Connect.Close();
        }
        private void LoadFileList(string cardname)
        {
            dataGridView2.Rows.Clear();
            SqlConnection Connect = new SqlConnection(acc.query);
            Connect.Open();
            string query = "SELECT FileNameF FROM TheTaiLieu WHERE MaTheTaiLieu = '" + cardname + "'AND Username = '" + this.username + "';";
            SqlCommand cmd = new SqlCommand(query, Connect);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.HasRows)
            {
                if (r.Read() == false) break;
                dataGridView2.Rows.Add(r.GetString(0));
            }
            Connect.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Documents_Load(object sender, EventArgs e)
        {
            Screen scr = Screen.PrimaryScreen; //đi lấy màn hình chính
            this.Left = (scr.WorkingArea.Width - this.Width) / 2;
            this.Top = (scr.WorkingArea.Height - this.Height) / 2;
            LoadDocumentList();
        }
        private void ShowAndOpenFile()
        {
            SqlConnection Connect = new SqlConnection(acc.query);
            Connect.Open();
            var selectedRow = dataGridView2.SelectedRows;
            string query = "SELECT FileNameF,ContentType,Data FROM TheTaiLieu WHERE MaTheTaiLieu = '" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "'AND Username = '" + this.username + "';";
            SqlCommand cmd = new SqlCommand(query, Connect);
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                var name = reader["FileNameF"].ToString();
                var data = (byte[])reader["Data"];
                var extn = reader["ContentType"].ToString();
                var newFileName = name.Replace(extn, DateTime.Now.ToString("ddMMyyyyhhmmss")) + extn;
                File.WriteAllBytes(newFileName, data);
                System.Diagnostics.Process.Start(newFileName);
            }
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            LoadFileList(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult rs = MessageBox.Show("Do you want to delete this document card ?", "Delete Card", buttons);
            if (rs == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    SqlConnection Connect = new SqlConnection(acc.query);
                    Connect.Open();
                    string query2 = "DELETE FROM TaiLieu WHERE USERNAME = '" + this.username + "' AND DOCUMENTNAME = '" + row.Cells[0].Value.ToString() + "';";
                    SqlCommand cmd2 = new SqlCommand(query2, Connect);
                    int j = cmd2.ExecuteNonQuery();
                    string query = "DELETE FROM TheTailieu WHERE USERNAME = '" + this.username + "' AND MaTheTaiLieu = '" + row.Cells[0].Value.ToString() + "';";
                    SqlCommand cmd = new SqlCommand(query, Connect);
                    int k = cmd.ExecuteNonQuery();
                    if (j > 0 && k > 0)
                    {
                        continue;
                    }
                }
                MessageBox.Show("Deleted successfully.");
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.Remove(row);
                }
                dataGridView2.Rows.Clear();
            }
            else
            {
                return;
            }


        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadFileList(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowAndOpenFile();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
