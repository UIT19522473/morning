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
using System.Data.Common;

namespace ListNote.Taolich
{
    public partial class DailyDocument : Form
    {
        Account acc = new Account();
        private string username = "";
        private string date = "";
        public string Date { get => date; set => date = value; }
        private List<string> LinkDocument = new List<string>();
        public string Username { get => username; set => username = value; }
        public DailyDocument()
        {
            InitializeComponent();
        }

        private void DailyDocument_Load(object sender, EventArgs e)
        {
            Screen scr = Screen.PrimaryScreen; //đi lấy màn hình chính
            this.Left = (scr.WorkingArea.Width - this.Width) / 2;
            this.Top = (scr.WorkingArea.Height - this.Height) / 2;
            //update();
            LoadDocumentList();
        }
        private void LoadDocumentList()
        {
            dataGridView2.Rows.Clear();
            SqlConnection Connect = new SqlConnection(acc.query);
            Connect.Open();
            string query = "SELECT FileNameF FROM DailyDocument WHERE USERNAME = '" + this.username + "'AND DateDoc = '" + this.date + "';";
            SqlCommand cmd = new SqlCommand(query, Connect);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.HasRows)
            {
                if (r.Read() == false) break;
                dataGridView2.Rows.Add(r.GetString(0));
            }
            Connect.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void AddFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = ".pdf,.doc,.xls,.xlsx |*.pdf;*.doc;*.xls;*xlsx| All file (*.*)|*.*";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.dataGridView1.Rows.Add(ofd.FileName);
            }
        }
        private void loadLinkDoc(List<string> t)
        {
            string item = "";
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                item = dataGridView1.Rows[i].Cells[0].Value.ToString();
                LinkDocument.Add(item);
            }
        }
        private void SaveFileButton_Click(object sender, EventArgs e)
        {
            loadLinkDoc(LinkDocument);
            try
            {
                SqlConnection Connect2 = new SqlConnection(acc.query);
                Connect2.Open();
                foreach (string fl in LinkDocument)
                {
                    using (Stream stream = File.OpenRead(fl))
                    {
                        byte[] buffer = new byte[stream.Length];
                        stream.Read(buffer, 0, buffer.Length);
                        string extn = new FileInfo(fl).Extension;
                        string query1 = "INSERT INTO DailyDocument(DateDoc, ContentType, Username, Data, FileNameF) VALUES (@datedoc, @extn, @username, @data, @filenamef)";
                        SqlCommand cmd1 = new SqlCommand(query1, Connect2);
                        cmd1.Parameters.Add("@data", SqlDbType.VarBinary).Value = buffer;
                        cmd1.Parameters.Add("@datedoc", SqlDbType.NVarChar).Value = this.date;
                        cmd1.Parameters.Add("@extn", SqlDbType.NVarChar).Value = extn;
                        cmd1.Parameters.Add("@username", SqlDbType.Char).Value = username;
                        cmd1.Parameters.Add("@filenamef", SqlDbType.NVarChar).Value = Path.GetFileNameWithoutExtension(fl);
                        cmd1.ExecuteNonQuery();
                    }
                }
                Connect2.Close();
                MessageBox.Show("Added successfully.", "List Note Master");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void ShowAndOpenFile(string d)
        {
            try
            {
                SqlConnection Connect = new SqlConnection(@"Data Source=LAPTOP-DKIC94F6\SQLEXPRESS;Initial Catalog=DTBEvent;Integrated Security=True");
                string query = "SELECT FileNameF,ContentType,Data FROM DailyDocument WHERE FileNameF = '"
                                     + /*dataGridView2.CurrentCell.Value.ToString()*/ d + "'AND Username = '"
                                     + this.username + "'AND DateDoc = '" + this.date + "';";
                Connect.Open();
                SqlCommand cmd1 = new SqlCommand(query, Connect);
                //var reader1 = cmd1.ExecuteReader();
                using (DbDataReader reader = cmd1.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        //MessageBox.Show(reader["FileNameF"].ToString());
                        var name = reader["FileNameF"].ToString();
                        var data = (byte[])reader["Data"];
                        var extn = reader["ContentType"].ToString();
                        var newFileName = name.Replace(extn, DateTime.Now.ToString("ddMMyyyyhhmmss")) + extn;
                        File.WriteAllBytes(newFileName, data);
                        System.Diagnostics.Process.Start(newFileName);
                    }
                }
                Connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadDocumentList();
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            string d = dataGridView2.CurrentCell.Value.ToString();
            int rowSelected = Convert.ToInt32(dataGridView2.CurrentRow.Index);
            ShowAndOpenFile(dataGridView2.Rows[rowSelected].Cells[0].Value.ToString());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            LinkDocument.Clear();
        }


    }
}
