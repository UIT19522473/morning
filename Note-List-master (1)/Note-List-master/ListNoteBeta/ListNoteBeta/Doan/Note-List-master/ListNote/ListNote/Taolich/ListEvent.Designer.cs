namespace ListNote
{
    partial class ListEvent
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
            this.pnShow = new System.Windows.Forms.Panel();
            this.dgvShow = new System.Windows.Forms.DataGridView();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Event = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNewEvent = new System.Windows.Forms.Button();
            this.lbTile = new System.Windows.Forms.Label();
            this.pnShow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShow)).BeginInit();
            this.SuspendLayout();
            // 
            // pnShow
            // 
            this.pnShow.Controls.Add(this.dgvShow);
            this.pnShow.Location = new System.Drawing.Point(0, 56);
            this.pnShow.Name = "pnShow";
            this.pnShow.Size = new System.Drawing.Size(384, 382);
            this.pnShow.TabIndex = 2;
            // 
            // dgvShow
            // 
            this.dgvShow.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Time,
            this.Event});
            this.dgvShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvShow.Location = new System.Drawing.Point(0, 0);
            this.dgvShow.Name = "dgvShow";
            this.dgvShow.RowHeadersWidth = 51;
            this.dgvShow.RowTemplate.Height = 24;
            this.dgvShow.Size = new System.Drawing.Size(384, 382);
            this.dgvShow.TabIndex = 0;
            this.dgvShow.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShow_CellClick);
            this.dgvShow.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Time
            // 
            this.Time.HeaderText = "Time";
            this.Time.MinimumWidth = 6;
            this.Time.Name = "Time";
            this.Time.Width = 125;
            // 
            // Event
            // 
            this.Event.HeaderText = "Event";
            this.Event.MinimumWidth = 6;
            this.Event.Name = "Event";
            this.Event.Width = 600;
            // 
            // btnNewEvent
            // 
            this.btnNewEvent.FlatAppearance.BorderSize = 0;
            this.btnNewEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewEvent.Font = new System.Drawing.Font("Nirmala UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewEvent.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnNewEvent.Location = new System.Drawing.Point(0, 444);
            this.btnNewEvent.Name = "btnNewEvent";
            this.btnNewEvent.Size = new System.Drawing.Size(214, 58);
            this.btnNewEvent.TabIndex = 3;
            this.btnNewEvent.Text = "+New event";
            this.btnNewEvent.UseVisualStyleBackColor = true;
            this.btnNewEvent.UseWaitCursor = true;
            this.btnNewEvent.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbTile
            // 
            this.lbTile.Font = new System.Drawing.Font("Nirmala UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTile.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbTile.Location = new System.Drawing.Point(0, 3);
            this.lbTile.Name = "lbTile";
            this.lbTile.Size = new System.Drawing.Size(384, 50);
            this.lbTile.TabIndex = 4;
            this.lbTile.Text = "Name y/m/d";
            // 
            // ListEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(387, 502);
            this.Controls.Add(this.lbTile);
            this.Controls.Add(this.btnNewEvent);
            this.Controls.Add(this.pnShow);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListEvent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ListEvent";
            this.Load += new System.EventHandler(this.ListEvent_Load);
            this.pnShow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnShow;
        private System.Windows.Forms.DataGridView dgvShow;
        private System.Windows.Forms.Button btnNewEvent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Event;
        private System.Windows.Forms.Label lbTile;
    }
}