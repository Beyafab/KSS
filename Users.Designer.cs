namespace KSS
{
    partial class Users
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbApp = new System.Windows.Forms.ComboBox();
            this.cbDate = new System.Windows.Forms.ComboBox();
            this.lbReport = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 388);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1075, 164);
            this.dataGridView1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1075, 100);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Highlight;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Yu Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1075, 100);
            this.label1.TabIndex = 0;
            this.label1.Text = "Get Report about Applicants";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.DarkMagenta;
            this.btnReport.FlatAppearance.BorderSize = 0;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReport.Location = new System.Drawing.Point(838, 224);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(187, 47);
            this.btnReport.TabIndex = 2;
            this.btnReport.Text = "Get Report";
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Choose Table";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(265, 116);
            this.label3.TabIndex = 4;
            this.label3.Text = "Choose\r\n0 to see all applicants\r\n1 for dates befor\r\n2 for dates after this day";
            // 
            // cbApp
            // 
            this.cbApp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbApp.FormattingEnabled = true;
            this.cbApp.Items.AddRange(new object[] {
            "marriageApplication",
            "deathApplication",
            "IDApplication",
            "BirthApplication"});
            this.cbApp.Location = new System.Drawing.Point(202, 121);
            this.cbApp.Name = "cbApp";
            this.cbApp.Size = new System.Drawing.Size(281, 28);
            this.cbApp.TabIndex = 5;
            // 
            // cbDate
            // 
            this.cbDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDate.FormattingEnabled = true;
            this.cbDate.Items.AddRange(new object[] {
            "0",
            "1",
            "2"});
            this.cbDate.Location = new System.Drawing.Point(318, 159);
            this.cbDate.Name = "cbDate";
            this.cbDate.Size = new System.Drawing.Size(281, 28);
            this.cbDate.TabIndex = 7;
            // 
            // lbReport
            // 
            this.lbReport.BackColor = System.Drawing.SystemColors.Info;
            this.lbReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReport.Location = new System.Drawing.Point(29, 271);
            this.lbReport.Name = "lbReport";
            this.lbReport.Size = new System.Drawing.Size(386, 36);
            this.lbReport.TabIndex = 8;
            // 
            // Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 552);
            this.Controls.Add(this.lbReport);
            this.Controls.Add(this.cbDate);
            this.Controls.Add(this.cbApp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Users";
            this.Text = "Users";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbApp;
        private System.Windows.Forms.ComboBox cbDate;
        private System.Windows.Forms.Label lbReport;
    }
}