namespace ListNote
{
    partial class DailyEvent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DailyEvent));
            this.txtlocation = new System.Windows.Forms.TextBox();
            this.txtEventName = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbDetails = new System.Windows.Forms.Label();
            this.cmbReminder = new System.Windows.Forms.ComboBox();
            this.lbReminder = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddDCM = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ckbAllD = new System.Windows.Forms.CheckBox();
            this.cmbTimeEnd = new System.Windows.Forms.ComboBox();
            this.cmbTimeStart = new System.Windows.Forms.ComboBox();
            this.txtEventDcrt = new System.Windows.Forms.TextBox();
            this.lbAllDay = new System.Windows.Forms.Label();
            this.lbEnd = new System.Windows.Forms.Label();
            this.txtEndEvent = new System.Windows.Forms.TextBox();
            this.dtpkEndEvent = new System.Windows.Forms.DateTimePicker();
            this.lbStart = new System.Windows.Forms.Label();
            this.txtStartEvent = new System.Windows.Forms.TextBox();
            this.dtpkStartEvent = new System.Windows.Forms.DateTimePicker();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtlocation
            // 
            this.txtlocation.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(110)))), ((int)(((byte)(190)))));
            this.txtlocation.Location = new System.Drawing.Point(3, 68);
            this.txtlocation.Multiline = true;
            this.txtlocation.Name = "txtlocation";
            this.txtlocation.Size = new System.Drawing.Size(850, 36);
            this.txtlocation.TabIndex = 1;
            this.txtlocation.Text = "Locations";
            // 
            // txtEventName
            // 
            this.txtEventName.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtEventName.Font = new System.Drawing.Font("Nirmala UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEventName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(110)))), ((int)(((byte)(190)))));
            this.txtEventName.Location = new System.Drawing.Point(0, 3);
            this.txtEventName.Multiline = true;
            this.txtEventName.Name = "txtEventName";
            this.txtEventName.Size = new System.Drawing.Size(850, 53);
            this.txtEventName.TabIndex = 7;
            this.txtEventName.Text = "Event Name";
            this.txtEventName.TextChanged += new System.EventHandler(this.txtEventName_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtEventName);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(853, 59);
            this.panel2.TabIndex = 0;
            // 
            // lbDetails
            // 
            this.lbDetails.AutoSize = true;
            this.lbDetails.Font = new System.Drawing.Font("Nirmala UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(110)))), ((int)(((byte)(190)))));
            this.lbDetails.Location = new System.Drawing.Point(1, 67);
            this.lbDetails.Name = "lbDetails";
            this.lbDetails.Size = new System.Drawing.Size(87, 32);
            this.lbDetails.TabIndex = 9;
            this.lbDetails.Text = "Details";
            // 
            // cmbReminder
            // 
            this.cmbReminder.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReminder.FormattingEnabled = true;
            this.cmbReminder.Items.AddRange(new object[] {
            "0 minutes",
            "5 minutes",
            "15 minutes",
            "30 minutes",
            "1 hours",
            "12 hours",
            "1 week"});
            this.cmbReminder.Location = new System.Drawing.Point(477, 8);
            this.cmbReminder.Name = "cmbReminder";
            this.cmbReminder.Size = new System.Drawing.Size(142, 36);
            this.cmbReminder.TabIndex = 3;
            this.cmbReminder.SelectedIndexChanged += new System.EventHandler(this.cmbReminder_SelectedIndexChanged);
            // 
            // lbReminder
            // 
            this.lbReminder.AutoSize = true;
            this.lbReminder.Font = new System.Drawing.Font("Nirmala UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReminder.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbReminder.Location = new System.Drawing.Point(354, 9);
            this.lbReminder.Name = "lbReminder";
            this.lbReminder.Size = new System.Drawing.Size(117, 32);
            this.lbReminder.TabIndex = 2;
            this.lbReminder.Text = "Reminder";
            this.lbReminder.Click += new System.EventHandler(this.lbReminder_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Nirmala UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(149, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(149, 48);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(116)))), ((int)(((byte)(187)))));
            this.panel1.Controls.Add(this.btnAddDCM);
            this.panel1.Controls.Add(this.cmbReminder);
            this.panel1.Controls.Add(this.lbReminder);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(856, 48);
            this.panel1.TabIndex = 8;
            // 
            // btnAddDCM
            // 
            this.btnAddDCM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(116)))), ((int)(((byte)(187)))));
            this.btnAddDCM.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAddDCM.FlatAppearance.BorderSize = 0;
            this.btnAddDCM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDCM.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDCM.Image = ((System.Drawing.Image)(resources.GetObject("btnAddDCM.Image")));
            this.btnAddDCM.Location = new System.Drawing.Point(641, 0);
            this.btnAddDCM.Name = "btnAddDCM";
            this.btnAddDCM.Size = new System.Drawing.Size(215, 48);
            this.btnAddDCM.TabIndex = 4;
            this.btnAddDCM.Text = "+ Add or Open Documents";
            this.btnAddDCM.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddDCM.UseVisualStyleBackColor = false;
            this.btnAddDCM.Click += new System.EventHandler(this.btnAddDCM_Click);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Nirmala UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(0, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(149, 48);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.txtlocation);
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1, 102);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(856, 650);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ckbAllD);
            this.panel3.Controls.Add(this.cmbTimeEnd);
            this.panel3.Controls.Add(this.cmbTimeStart);
            this.panel3.Controls.Add(this.txtEventDcrt);
            this.panel3.Controls.Add(this.lbAllDay);
            this.panel3.Controls.Add(this.lbEnd);
            this.panel3.Controls.Add(this.txtEndEvent);
            this.panel3.Controls.Add(this.dtpkEndEvent);
            this.panel3.Controls.Add(this.lbStart);
            this.panel3.Controls.Add(this.txtStartEvent);
            this.panel3.Controls.Add(this.dtpkStartEvent);
            this.panel3.Location = new System.Drawing.Point(3, 110);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(850, 573);
            this.panel3.TabIndex = 6;
            // 
            // ckbAllD
            // 
            this.ckbAllD.AutoSize = true;
            this.ckbAllD.Location = new System.Drawing.Point(731, 55);
            this.ckbAllD.Name = "ckbAllD";
            this.ckbAllD.Size = new System.Drawing.Size(18, 17);
            this.ckbAllD.TabIndex = 17;
            this.ckbAllD.UseVisualStyleBackColor = true;
            this.ckbAllD.CheckedChanged += new System.EventHandler(this.ckbAllD_CheckedChanged);
            // 
            // cmbTimeEnd
            // 
            this.cmbTimeEnd.Enabled = false;
            this.cmbTimeEnd.FormattingEnabled = true;
            this.cmbTimeEnd.Items.AddRange(new object[] {
            "12:00 AM",
            "12:30 AM",
            "1:00 AM",
            "1:30 AM",
            "2:00 AM",
            "2:30 AM",
            "3:00 AM",
            "3:30 AM",
            "4:00 AM",
            "4:30 AM",
            "5:00 AM",
            "5:30 AM",
            "6:00 AM",
            "6:30 AM",
            "7:00 AM",
            "7:30 AM",
            "8:00 AM",
            "8:30 AM",
            "9:00 AM",
            "9:30 AM",
            "10:00 AM",
            "10:30 AM",
            "11:00 AM",
            "11:30AM",
            "12:00 PM",
            "12:30 PM",
            "1:00 PM",
            "1:30 PM",
            "2:00 PM",
            "2:30 PM",
            "3:00 PM",
            "3:30 PM",
            "4:00 PM",
            "4:30 PM",
            "5:00 PM",
            "5:30 PM",
            "6:00 PM",
            "6:30 PM",
            "7:00 PM",
            "7:30 PM",
            "8:00 PM",
            "8:30 PM",
            "9:00 PM",
            "9:30 PM",
            "10:00 PM",
            "10:30 PM",
            "11:00 PM",
            "11:30 PM"});
            this.cmbTimeEnd.Location = new System.Drawing.Point(588, 185);
            this.cmbTimeEnd.Name = "cmbTimeEnd";
            this.cmbTimeEnd.Size = new System.Drawing.Size(111, 24);
            this.cmbTimeEnd.TabIndex = 16;
            this.cmbTimeEnd.Text = "12:00 PM";
            // 
            // cmbTimeStart
            // 
            this.cmbTimeStart.Enabled = false;
            this.cmbTimeStart.FormattingEnabled = true;
            this.cmbTimeStart.Items.AddRange(new object[] {
            "12:00 AM",
            "12:30 AM",
            "1:00 AM",
            "1:30 AM",
            "2:00 AM",
            "2:30 AM",
            "3:00 AM",
            "3:30 AM",
            "4:00 AM",
            "4:30 AM",
            "5:00 AM",
            "5:30 AM",
            "6:00 AM",
            "6:30 AM",
            "7:00 AM",
            "7:30 AM",
            "8:00 AM",
            "8:30 AM",
            "9:00 AM",
            "9:30 AM",
            "10:00 AM",
            "10:30 AM",
            "11:00 AM",
            "11:30AM",
            "12:00 PM",
            "12:30 PM",
            "1:00 PM",
            "1:30 PM",
            "2:00 PM",
            "2:30 PM",
            "3:00 PM",
            "3:30 PM",
            "4:00 PM",
            "4:30 PM",
            "5:00 PM",
            "5:30 PM",
            "6:00 PM",
            "6:30 PM",
            "7:00 PM",
            "7:30 PM",
            "8:00 PM",
            "8:30 PM",
            "9:00 PM",
            "9:30 PM",
            "10:00 PM",
            "10:30 PM",
            "11:00 PM",
            "11:30 PM"});
            this.cmbTimeStart.Location = new System.Drawing.Point(588, 50);
            this.cmbTimeStart.Name = "cmbTimeStart";
            this.cmbTimeStart.Size = new System.Drawing.Size(111, 24);
            this.cmbTimeStart.TabIndex = 15;
            this.cmbTimeStart.Text = "12:00 AM";
            // 
            // txtEventDcrt
            // 
            this.txtEventDcrt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtEventDcrt.Font = new System.Drawing.Font("Nirmala UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEventDcrt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(110)))), ((int)(((byte)(190)))));
            this.txtEventDcrt.Location = new System.Drawing.Point(0, 248);
            this.txtEventDcrt.Multiline = true;
            this.txtEventDcrt.Name = "txtEventDcrt";
            this.txtEventDcrt.Size = new System.Drawing.Size(850, 325);
            this.txtEventDcrt.TabIndex = 14;
            this.txtEventDcrt.Text = "Event description";
            // 
            // lbAllDay
            // 
            this.lbAllDay.AutoSize = true;
            this.lbAllDay.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAllDay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(110)))), ((int)(((byte)(190)))));
            this.lbAllDay.Location = new System.Drawing.Point(755, 48);
            this.lbAllDay.Name = "lbAllDay";
            this.lbAllDay.Size = new System.Drawing.Size(74, 28);
            this.lbAllDay.TabIndex = 13;
            this.lbAllDay.Text = "All Day";
            // 
            // lbEnd
            // 
            this.lbEnd.AutoSize = true;
            this.lbEnd.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEnd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(110)))), ((int)(((byte)(190)))));
            this.lbEnd.Location = new System.Drawing.Point(3, 185);
            this.lbEnd.Name = "lbEnd";
            this.lbEnd.Size = new System.Drawing.Size(45, 28);
            this.lbEnd.TabIndex = 9;
            this.lbEnd.Text = "End";
            // 
            // txtEndEvent
            // 
            this.txtEndEvent.Font = new System.Drawing.Font("Nirmala UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndEvent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(110)))), ((int)(((byte)(190)))));
            this.txtEndEvent.Location = new System.Drawing.Point(65, 185);
            this.txtEndEvent.Multiline = true;
            this.txtEndEvent.Name = "txtEndEvent";
            this.txtEndEvent.Size = new System.Drawing.Size(448, 35);
            this.txtEndEvent.TabIndex = 10;
            this.txtEndEvent.Text = "yy/mm/dd";
            // 
            // dtpkEndEvent
            // 
            this.dtpkEndEvent.Location = new System.Drawing.Point(528, 185);
            this.dtpkEndEvent.Name = "dtpkEndEvent";
            this.dtpkEndEvent.Size = new System.Drawing.Size(28, 22);
            this.dtpkEndEvent.TabIndex = 11;
            this.dtpkEndEvent.ValueChanged += new System.EventHandler(this.dtpkEndEvent_ValueChanged);
            // 
            // lbStart
            // 
            this.lbStart.AutoSize = true;
            this.lbStart.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(110)))), ((int)(((byte)(190)))));
            this.lbStart.Location = new System.Drawing.Point(3, 50);
            this.lbStart.Name = "lbStart";
            this.lbStart.Size = new System.Drawing.Size(54, 28);
            this.lbStart.TabIndex = 6;
            this.lbStart.Text = "Start";
            // 
            // txtStartEvent
            // 
            this.txtStartEvent.Font = new System.Drawing.Font("Nirmala UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartEvent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(110)))), ((int)(((byte)(190)))));
            this.txtStartEvent.Location = new System.Drawing.Point(64, 50);
            this.txtStartEvent.Multiline = true;
            this.txtStartEvent.Name = "txtStartEvent";
            this.txtStartEvent.Size = new System.Drawing.Size(449, 37);
            this.txtStartEvent.TabIndex = 7;
            this.txtStartEvent.Text = "yy/mm/dd";
            // 
            // dtpkStartEvent
            // 
            this.dtpkStartEvent.Location = new System.Drawing.Point(528, 50);
            this.dtpkStartEvent.Name = "dtpkStartEvent";
            this.dtpkStartEvent.Size = new System.Drawing.Size(28, 22);
            this.dtpkStartEvent.TabIndex = 8;
            this.dtpkStartEvent.ValueChanged += new System.EventHandler(this.dtpkStartEvent_ValueChanged);
            // 
            // DailyEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(858, 753);
            this.Controls.Add(this.lbDetails);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DailyEvent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DailyEvent";
            this.Load += new System.EventHandler(this.DailyEvent_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtlocation;
        private System.Windows.Forms.TextBox txtEventName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbDetails;
        private System.Windows.Forms.ComboBox cmbReminder;
        private System.Windows.Forms.Label lbReminder;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cmbTimeEnd;
        private System.Windows.Forms.ComboBox cmbTimeStart;
        private System.Windows.Forms.TextBox txtEventDcrt;
        private System.Windows.Forms.Label lbAllDay;
        private System.Windows.Forms.Label lbEnd;
        private System.Windows.Forms.TextBox txtEndEvent;
        private System.Windows.Forms.DateTimePicker dtpkEndEvent;
        private System.Windows.Forms.Label lbStart;
        private System.Windows.Forms.TextBox txtStartEvent;
        private System.Windows.Forms.DateTimePicker dtpkStartEvent;
        private System.Windows.Forms.CheckBox ckbAllD;
        private System.Windows.Forms.Button btnAddDCM;
    }
}