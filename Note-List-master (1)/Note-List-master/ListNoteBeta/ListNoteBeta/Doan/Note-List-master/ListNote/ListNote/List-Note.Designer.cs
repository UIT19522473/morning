namespace ListNote
{
    partial class ListNote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListNote));
            this.pnOption = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNote = new System.Windows.Forms.Button();
            this.bntDocument = new System.Windows.Forms.Button();
            this.pnUser = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pnShow = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDay = new System.Windows.Forms.Button();
            this.btnWeek = new System.Windows.Forms.Button();
            this.btnMonth = new System.Windows.Forms.Button();
            this.pnOption.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnOption
            // 
            this.pnOption.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnOption.BackgroundImage")));
            this.pnOption.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnOption.Controls.Add(this.panel2);
            this.pnOption.Controls.Add(this.pnUser);
            this.pnOption.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnOption.Location = new System.Drawing.Point(0, 0);
            this.pnOption.Name = "pnOption";
            this.pnOption.Size = new System.Drawing.Size(282, 1055);
            this.pnOption.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.btnNote);
            this.panel2.Controls.Add(this.bntDocument);
            this.panel2.Location = new System.Drawing.Point(1, 235);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(281, 820);
            this.panel2.TabIndex = 5;
            // 
            // btnNote
            // 
            this.btnNote.BackColor = System.Drawing.Color.Transparent;
            this.btnNote.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNote.FlatAppearance.BorderSize = 0;
            this.btnNote.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.btnNote.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btnNote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNote.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNote.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNote.Location = new System.Drawing.Point(0, 289);
            this.btnNote.Name = "btnNote";
            this.btnNote.Size = new System.Drawing.Size(281, 343);
            this.btnNote.TabIndex = 3;
            this.btnNote.Text = "Note";
            this.btnNote.UseVisualStyleBackColor = false;
            this.btnNote.Click += new System.EventHandler(this.btnNote_Click);
            // 
            // bntDocument
            // 
            this.bntDocument.BackColor = System.Drawing.Color.Transparent;
            this.bntDocument.Dock = System.Windows.Forms.DockStyle.Top;
            this.bntDocument.FlatAppearance.BorderSize = 0;
            this.bntDocument.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.bntDocument.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.bntDocument.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntDocument.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntDocument.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bntDocument.Location = new System.Drawing.Point(0, 0);
            this.bntDocument.Name = "bntDocument";
            this.bntDocument.Size = new System.Drawing.Size(281, 289);
            this.bntDocument.TabIndex = 2;
            this.bntDocument.Text = "My Documents";
            this.bntDocument.UseVisualStyleBackColor = false;
            this.bntDocument.Click += new System.EventHandler(this.bntDocument_Click);
            // 
            // pnUser
            // 
            this.pnUser.BackColor = System.Drawing.Color.Transparent;
            this.pnUser.Controls.Add(this.label1);
            this.pnUser.Controls.Add(this.pictureBox2);
            this.pnUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnUser.Location = new System.Drawing.Point(0, 0);
            this.pnUser.Name = "pnUser";
            this.pnUser.Size = new System.Drawing.Size(282, 234);
            this.pnUser.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(125)))));
            this.label1.Location = new System.Drawing.Point(75, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "User Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(37, 11);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(216, 178);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pnShow
            // 
            this.pnShow.AutoScroll = true;
            this.pnShow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnShow.Location = new System.Drawing.Point(283, 48);
            this.pnShow.Name = "pnShow";
            this.pnShow.Size = new System.Drawing.Size(1157, 995);
            this.pnShow.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDay);
            this.panel1.Controls.Add(this.btnWeek);
            this.panel1.Controls.Add(this.btnMonth);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(282, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1158, 46);
            this.panel1.TabIndex = 4;
            // 
            // btnDay
            // 
            this.btnDay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDay.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDay.FlatAppearance.BorderSize = 0;
            this.btnDay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDay.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDay.Image = ((System.Drawing.Image)(resources.GetObject("btnDay.Image")));
            this.btnDay.Location = new System.Drawing.Point(780, 0);
            this.btnDay.Name = "btnDay";
            this.btnDay.Size = new System.Drawing.Size(126, 46);
            this.btnDay.TabIndex = 7;
            this.btnDay.Text = "Day";
            this.btnDay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDay.UseVisualStyleBackColor = true;
            // 
            // btnWeek
            // 
            this.btnWeek.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnWeek.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnWeek.FlatAppearance.BorderSize = 0;
            this.btnWeek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWeek.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWeek.Image = ((System.Drawing.Image)(resources.GetObject("btnWeek.Image")));
            this.btnWeek.Location = new System.Drawing.Point(906, 0);
            this.btnWeek.Name = "btnWeek";
            this.btnWeek.Size = new System.Drawing.Size(126, 46);
            this.btnWeek.TabIndex = 6;
            this.btnWeek.Text = "Week";
            this.btnWeek.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnWeek.UseVisualStyleBackColor = true;
            this.btnWeek.Click += new System.EventHandler(this.btnWeek_Click);
            // 
            // btnMonth
            // 
            this.btnMonth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMonth.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMonth.FlatAppearance.BorderSize = 0;
            this.btnMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonth.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMonth.Image = ((System.Drawing.Image)(resources.GetObject("btnMonth.Image")));
            this.btnMonth.Location = new System.Drawing.Point(1032, 0);
            this.btnMonth.Name = "btnMonth";
            this.btnMonth.Size = new System.Drawing.Size(126, 46);
            this.btnMonth.TabIndex = 5;
            this.btnMonth.Text = "Month";
            this.btnMonth.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMonth.UseVisualStyleBackColor = true;
            this.btnMonth.Click += new System.EventHandler(this.btnMonth_Click);
            // 
            // ListNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1440, 1055);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnShow);
            this.Controls.Add(this.pnOption);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListNote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ListNote";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnOption.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pnUser.ResumeLayout(false);
            this.pnUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnOption;
        private System.Windows.Forms.Button bntDocument;
        private System.Windows.Forms.Panel pnShow;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMonth;
        private System.Windows.Forms.Button btnDay;
        private System.Windows.Forms.Button btnWeek;
        private System.Windows.Forms.Panel pnUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnNote;
    }
}

