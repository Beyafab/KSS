namespace KSS
{
    partial class MarriageReport
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DG = new System.Windows.Forms.DataGridView();
            this.btnSendNotification = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.cbDate = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbApp = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Highlight;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Yu Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1216, 89);
            this.label1.TabIndex = 0;
            this.label1.Text = "Marriage Report";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1216, 89);
            this.panel1.TabIndex = 1;
            // 
            // DG
            // 
            this.DG.AllowUserToAddRows = false;
            this.DG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DG.Location = new System.Drawing.Point(0, 537);
            this.DG.Name = "DG";
            this.DG.RowHeadersWidth = 62;
            this.DG.RowTemplate.Height = 28;
            this.DG.Size = new System.Drawing.Size(1216, 348);
            this.DG.TabIndex = 2;
            // 
            // btnSendNotification
            // 
            this.btnSendNotification.BackColor = System.Drawing.Color.DarkMagenta;
            this.btnSendNotification.FlatAppearance.BorderSize = 0;
            this.btnSendNotification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendNotification.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendNotification.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSendNotification.Location = new System.Drawing.Point(868, 175);
            this.btnSendNotification.Name = "btnSendNotification";
            this.btnSendNotification.Size = new System.Drawing.Size(255, 48);
            this.btnSendNotification.TabIndex = 4;
            this.btnSendNotification.Text = "Send Notification";
            this.btnSendNotification.UseVisualStyleBackColor = false;
            this.btnSendNotification.Click += new System.EventHandler(this.btnSendNotification_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 320);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(256, 116);
            this.label2.TabIndex = 5;
            this.label2.Text = "Choose \r\n1 to select this day\r\n2 for days before today\r\n3 for days after this day" +
    "\r\n";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DarkMagenta;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(12, 161);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(194, 48);
            this.button3.TabIndex = 6;
            this.button3.Text = "Search in";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // cbDate
            // 
            this.cbDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDate.FormattingEnabled = true;
            this.cbDate.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cbDate.Location = new System.Drawing.Point(16, 439);
            this.cbDate.Name = "cbDate";
            this.cbDate.Size = new System.Drawing.Size(252, 37);
            this.cbDate.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 268);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 37);
            this.label3.TabIndex = 8;
            this.label3.Text = "Pick a date\r\n";
            // 
            // cbApp
            // 
            this.cbApp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbApp.FormattingEnabled = true;
            this.cbApp.Items.AddRange(new object[] {
            "marriageApplication",
            "deathApplication",
            "IDApplication",
            "BirthApplication"});
            this.cbApp.Location = new System.Drawing.Point(248, 175);
            this.cbApp.Name = "cbApp";
            this.cbApp.Size = new System.Drawing.Size(265, 34);
            this.cbApp.TabIndex = 9;
            // 
            // MarriageReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 885);
            this.Controls.Add(this.cbApp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbDate);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSendNotification);
            this.Controls.Add(this.DG);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MarriageReport";
            this.Text = "MarriageReport";
            this.Load += new System.EventHandler(this.MarriageReport_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView DG;
        private System.Windows.Forms.Button btnSendNotification;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox cbDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbApp;
    }
}