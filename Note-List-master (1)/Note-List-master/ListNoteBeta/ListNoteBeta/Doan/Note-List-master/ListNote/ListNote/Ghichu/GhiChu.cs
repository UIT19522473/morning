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
    public partial class GhiChu : Form
    {
        protected Account curAcc = new Account();

        public Account CurAcc { get => curAcc; set => curAcc = value; }

        public GhiChu()
        {
            InitializeComponent();
        }
        void LoadButton() // Hien cac nut chua ten Note len form
        {
            List<FlowLayoutPanel> PanelList = new List<FlowLayoutPanel> { fpnlNeed, fpnlDoing, fpnlDone };
            SqlConnection Connect = new SqlConnection(CurAcc.query);
            Connect.Open();
            string query = "SELECT Things,ThingType FROM Note WHERE Username = '" + curAcc.Username + "'";
            SqlCommand command = new SqlCommand(query, Connect);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.HasRows)
            {
                if (reader.Read() == false)
                    break;
                PanelList[reader.GetInt32(1)].Controls.Add(CreateButtonNote(reader.GetString(0)));
            }
        }
        private void SetUIForForm() // Desing cho form
        {
            List<Panel> PanelList = new List<Panel> { panel1, panel2, panel3 };
            List<Panel> PanelList1 = new List<Panel> { fpnlNeed, fpnlDoing, fpnlDone };
            List<Button> btnList = new List<Button> { button1, button2, button3 };
            List<PictureBox> picList = new List<PictureBox> { pictureBox1, pictureBox2, pictureBox3 };
            this.BackColor = Color.White;
            for(int i = 0;i < btnList.Count;i++)
            {
                btnList[i].Image = Image.FromFile(@"./Imag/addicon.png");
                btnList[i].TabStop = false;
                btnList[i].FlatStyle = FlatStyle.Flat;
                btnList[i].FlatAppearance.BorderSize = 0;
                picList[i].Image = Image.FromFile(@"./Imag/listicon.png");
            }
            PanelList[1].BackColor = Color.FromArgb(128, 204, 255);
            PanelList[0].BackColor = Color.FromArgb(180, 253, 187);
            PanelList[2].BackColor = Color.FromArgb(255, 153, 194);
            PanelList1[1].BackColor = Color.FromArgb(128, 204, 255);
            PanelList1[0].BackColor = Color.FromArgb(180, 253, 187);
            PanelList1[2].BackColor = Color.FromArgb(255, 153, 194);
        }

        private void GhiChu_Load(object sender, EventArgs e)
        {
            SetUIForForm();
            LoadButton();
        }
        private Button CreateButtonNote(string s) //Tạo nút để chứa nội dung Note
        {
            Button a = new Button();
            a.Margin = new Padding(20, a.Margin.Top, a.Margin.Right, a.Margin.Bottom);
            a.TabStop = false;
            a.FlatStyle = FlatStyle.Flat;
            a.Width = fpnlNeed.Size.Width - 40;
            a.Height = 30;

            //--
            a.FlatAppearance.BorderSize = 0;
            //--
            a.Text = s;
            a.BackColor = Color.FromArgb(244, 245, 247);
            a.TextAlign = ContentAlignment.TopLeft;
            a.Padding = new Padding(3, 3, 3, 3);
            a.Click += NoteButton_Click;
            return a;
        }
        private TextBox CreateTxtBox() // Tạo textbox để nhập nội dung note
        {
            TextBox a = new TextBox();
            a.Name = "underfine";
            a.Multiline = true;
            a.MinimumSize = new Size(fpnlNeed.Size.Width - 40, 90);
            a.Margin = new Padding(20, a.Margin.Top, a.Margin.Right, a.Margin.Bottom);
            return a;
        }
        private Button CreateButtonAdd() // tạo nút add xanh lá
        {
            Button a = new Button();
            a.TabStop = false;
            a.BackColor = Color.FromArgb(80, 166, 63);
            a.FlatAppearance.BorderSize = 0;
            a.ForeColor = Color.White;
            a.FlatStyle = FlatStyle.Flat;
            a.Width = fpnlNeed.Size.Width / 3;
            a.Height = 30;
            a.Text = "Add";
            a.Click += A_Click;
            a.Margin = new Padding(20, a.Margin.Top, a.Margin.Right, a.Margin.Bottom);
            return a;

        }
        private Button CreateButtonCancel() // taoj nut delete mau vang
        {
            Button a = new Button();
            a.Image = Image.FromFile(@"./Imag/xicon.png");
            a.FlatAppearance.BorderSize = 0;
            a.TabStop = false;
            a.FlatStyle = FlatStyle.Flat;
            a.Width = fpnlNeed.Size.Width / 5;
            a.Height = 30;
            a.Click += Cancel_Click;
            a.Margin = new Padding(20, a.Margin.Top, a.Margin.Right, a.Margin.Bottom);
            return a;
        }
        private void NoteButton_Click(object sender, EventArgs e) //click vao nut note
        {
            Button btnNote = sender as Button;
            List<FlowLayoutPanel> PanelList = new List<FlowLayoutPanel> { fpnlNeed, fpnlDoing, fpnlDone };
            for (int i = 0; i < PanelList.Count; i++)
            {
                if (PanelList[i].Contains(btnNote))
                {
                    SqlConnection Connect = new SqlConnection(curAcc.query);
                    Connect.Open();
                    string query = "SELECT Things,ThingType,fDescription FROM Note WHERE Username = '" + curAcc.Username + "' AND Things = '" + btnNote.Text + "' AND ThingType = '" + i + "'";
                    SqlCommand command = new SqlCommand(query, Connect);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.HasRows)
                    {
                        if (reader.Read() == false) break;
                        Description fDes = new Description();
                        if (i == 0)
                            fDes.BackColor = Color.FromArgb(180, 253, 187);
                        else if(i == 1)
                            fDes.BackColor = Color.FromArgb(128, 204, 255);
                        else if(i == 2)
                            fDes.BackColor = Color.FromArgb(255, 153, 194);
                        fDes.NameOfNote = reader.GetString(0);
                        fDes.CurAcc.Username = this.curAcc.Username;
                        fDes.TypeOfNote = reader.GetInt32(1);
                        fDes.Des = reader.GetString(2);
                        fDes.ShowDialog();
                        for (int j = 0; j < PanelList.Count; j++)
                        {
                            PanelList[j].Controls.Clear();
                        }
                        LoadButton();

                    }
                }
            }



        }
        private void Cancel_Click(object sender, EventArgs e) // click vao nut cancel mau vang
        {
            Button btnCancel = sender as Button;
            List<Button> BtnList = new List<Button> { button1, button2, button3 };
            List<FlowLayoutPanel> PanelList = new List<FlowLayoutPanel> { fpnlNeed, fpnlDoing, fpnlDone };
            for (int i = 0; i < PanelList.Count; i++)
            {
                PanelList[i].Controls.Clear();
                BtnList[i].Enabled = true;
            }
            LoadButton();

        }
        private void A_Click(object sender, EventArgs e) //click vao nut add xanh la
        {
            List<Button> BtnList = new List<Button> { button1, button2, button3 };
            Button btnAdd = sender as Button;
            List<FlowLayoutPanel> PanelList = new List<FlowLayoutPanel> { fpnlNeed, fpnlDoing, fpnlDone };
            for (int i = 0; i < PanelList.Count; i++)
            {
                if (PanelList[i].Contains(btnAdd))
                {
                    TextBox CurrentTextBox = PanelList[i].Controls.Find("underfine", true).FirstOrDefault() as TextBox;
                    if (CurrentTextBox.Text == "")
                    {
                        MessageBox.Show("Please enter all fields ! ", "List Note");
                    }
                    else
                    {
                        try
                        {
                            SqlConnection Connect = new SqlConnection(curAcc.query);
                            Connect.Open();
                            string query = "INSERT INTO Note VALUES('" + curAcc.Username + "','" + CurrentTextBox.Text + "'," + i + "," + "''" + ")";
                            SqlCommand cmd = new SqlCommand(query, Connect);
                            cmd.ExecuteNonQuery();
                            PanelList[i].Controls.Remove(btnAdd);
                            PanelList[i].Controls.Remove(CurrentTextBox);
                            Connect.Close();
                            for (int j = 0; j < 3; j++)
                            {
                                PanelList[j].Controls.Clear();
                                BtnList[j].Enabled = true;
                            }
                            LoadButton();
                        }
                        catch
                        {
                            MessageBox.Show("Name exists in this list", "List Note");
                        }
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)   // khi ấn nút add1
        {
            fpnlNeed.Controls.Add(CreateTxtBox());
            fpnlNeed.Controls.Add(CreateButtonAdd());
            fpnlNeed.Controls.Add(CreateButtonCancel());
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
        }
        private void button2_Click(object sender, EventArgs e)  //khi ấn nút add2
        {
            fpnlDoing.Controls.Add(CreateTxtBox());
            fpnlDoing.Controls.Add(CreateButtonAdd());
            fpnlDoing.Controls.Add(CreateButtonCancel());
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e) //khi ấn nút add3
        {
            fpnlDone.Controls.Add(CreateTxtBox());
            fpnlDone.Controls.Add(CreateButtonAdd());
            fpnlDone.Controls.Add(CreateButtonCancel());
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
        }
    }
}
