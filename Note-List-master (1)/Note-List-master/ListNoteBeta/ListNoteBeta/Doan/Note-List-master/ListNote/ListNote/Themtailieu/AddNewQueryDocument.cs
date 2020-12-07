using System;
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
using System.Configuration;

namespace ListNote
{
    public partial class AddNewQueryDocument : Form
    {
        Account acc = new Account();
        private string username = "";
        private List<string> LinkDocument = new List<string>();
        public string Username { get => username; set => username = value; }
        public AddNewQueryDocument()
        {
            InitializeComponent();

        }

        public void update()
        {
            dataGridView1.ColumnCount = 1;
            dataGridView1.Columns[0].Width = 300;
            dataGridView1.Columns[0].Name = "File path";
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Text = "Cancle this";
            btn.HeaderText = "";
            btn.Name = "Cancle this";
            btn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btn);
        }
        private void AddNewQueryDocument_Load(object sender, EventArgs e)
        {
            Screen scr = Screen.PrimaryScreen; //đi lấy màn hình chính
            this.Left = (scr.WorkingArea.Width - this.Width) / 2;
            this.Top = (scr.WorkingArea.Height - this.Height) / 2;
            update();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Multiselect = true;
            //ofd.Filter = ".pdf,.doc,.xls,.xlsx,|*.pdf;*.doc;*.xls;*xlsx| All file (*.*)|*.*";
            ofd.Filter = "All files (*.*)|*.*|All files(*.*) | *.* ";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //foreach(string str in ofd.FileNames)
                //{
                this.dataGridView1.Rows.Add(ofd.FileName);

                //}             
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadLinkDoc(LinkDocument);
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please type the document card name", "List Note");
            }
            else
            {
                try
                {
                    SqlConnection Connect = new SqlConnection(acc.query);
                    Connect.Open();
                    string ContainerPath = @".\Document\" + username + @"\" + textBox1.Text;
                    string targetPath = Application.StartupPath + @"\" + @"\Document\" + username + @"\" + textBox1.Text;
                    if (!Directory.Exists(targetPath))
                    {
                        Directory.CreateDirectory(targetPath);
                    }
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
                                string query1 = "INSERT INTO TheTaiLieu(MaTheTaiLieu, ContentType, Username, Data, FileNameF) VALUES (@mathetailieu, @extn, @username, @data, @filenamef)";
                                SqlCommand cmd1 = new SqlCommand(query1, Connect2);
                                cmd1.Parameters.Add("@data", SqlDbType.VarBinary).Value = buffer;
                                cmd1.Parameters.Add("@mathetailieu", SqlDbType.NVarChar).Value = textBox1.Text;
                                cmd1.Parameters.Add("@extn", SqlDbType.NVarChar).Value = extn;
                                cmd1.Parameters.Add("@username", SqlDbType.Char).Value = username;
                                cmd1.Parameters.Add("@filenamef", SqlDbType.NVarChar).Value = Path.GetFileNameWithoutExtension(fl);
                                cmd1.ExecuteNonQuery();
                            }
                        }
                        Connect2.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    foreach (string filePath in LinkDocument)
                    {
                        string fn = Path.GetFileName(filePath); //File name
                        string destFile = Path.Combine(@targetPath, fn);
                        File.Copy(filePath, destFile, true);
                    }
                    string query = "INSERT INTO Tailieu VALUES('" + username + "','" + ContainerPath + "','" + textBox1.Text + "');";
                    SqlCommand cmd = new SqlCommand(query, Connect);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Created and added documents successfully !");
                }
                catch
                {
                    MessageBox.Show("This name has existed !!!", "List Note");
                }
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            Documents dc = new Documents();
            dc.Username = this.Username;
            this.Close();
            dc.ShowDialog();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Close();
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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(rowIndex);
            }
        }
    }
}

