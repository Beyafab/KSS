namespace KSS
{
    partial class RegisterationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterationForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.Chbshow = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSignUp = new System.Windows.Forms.Button();
            this.tbFname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbLname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbAge = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbTelNo = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 451);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(208, 110);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(377, 26);
            this.tbUserName.TabIndex = 4;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(208, 458);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(377, 26);
            this.tbPassword.TabIndex = 5;
            // 
            // Chbshow
            // 
            this.Chbshow.AutoSize = true;
            this.Chbshow.Location = new System.Drawing.Point(472, 505);
            this.Chbshow.Name = "Chbshow";
            this.Chbshow.Size = new System.Drawing.Size(148, 24);
            this.Chbshow.TabIndex = 6;
            this.Chbshow.Text = " show password";
            this.Chbshow.UseVisualStyleBackColor = true;
            this.Chbshow.CheckedChanged += new System.EventHandler(this.Chbshow_CheckedChanged_1);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1031, 76);
            this.label4.TabIndex = 7;
            this.label4.Text = "Register Account";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSignUp
            // 
            this.btnSignUp.Font = new System.Drawing.Font("Matura MT Script Capitals", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignUp.Location = new System.Drawing.Point(700, 529);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(183, 49);
            this.btnSignUp.TabIndex = 8;
            this.btnSignUp.Text = "Sign UP";
            this.btnSignUp.UseVisualStyleBackColor = true;
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
            // 
            // tbFname
            // 
            this.tbFname.Location = new System.Drawing.Point(208, 164);
            this.tbFname.Name = "tbFname";
            this.tbFname.Size = new System.Drawing.Size(377, 26);
            this.tbFname.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 32);
            this.label3.TabIndex = 9;
            this.label3.Text = "First Name";
            // 
            // tbLname
            // 
            this.tbLname.Location = new System.Drawing.Point(208, 227);
            this.tbLname.Name = "tbLname";
            this.tbLname.Size = new System.Drawing.Size(377, 26);
            this.tbLname.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 32);
            this.label5.TabIndex = 11;
            this.label5.Text = "Last Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(22, 267);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 32);
            this.label6.TabIndex = 13;
            this.label6.Text = "Age";
            // 
            // cbAge
            // 
            this.cbAge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAge.FormattingEnabled = true;
            this.cbAge.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86",
            "87",
            "88",
            "89",
            "90",
            "91",
            "92",
            "93",
            "94",
            "95",
            "96",
            "97",
            "98",
            "99",
            "100",
            "101",
            "102",
            "103",
            "104",
            "105",
            "106",
            "107",
            "108",
            "109",
            "110"});
            this.cbAge.Location = new System.Drawing.Point(208, 270);
            this.cbAge.Name = "cbAge";
            this.cbAge.Size = new System.Drawing.Size(107, 28);
            this.cbAge.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(22, 325);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 32);
            this.label7.TabIndex = 15;
            this.label7.Text = "Email";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(22, 394);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 32);
            this.label8.TabIndex = 16;
            this.label8.Text = "Tel-No";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(208, 332);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(377, 26);
            this.tbEmail.TabIndex = 17;
            // 
            // tbTelNo
            // 
            this.tbTelNo.Location = new System.Drawing.Point(208, 400);
            this.tbTelNo.Name = "tbTelNo";
            this.tbTelNo.Size = new System.Drawing.Size(377, 26);
            this.tbTelNo.TabIndex = 18;
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(975, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(44, 41);
            this.btnClose.TabIndex = 19;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // RegisterationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(132)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(1031, 615);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tbTelNo);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbAge);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbLname);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbFname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSignUp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Chbshow);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegisterationForm";
            this.Text = "Registeration Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.CheckBox Chbshow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSignUp;
        private System.Windows.Forms.TextBox tbFname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbLname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbAge;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbTelNo;
        private System.Windows.Forms.Button btnClose;
    }
}