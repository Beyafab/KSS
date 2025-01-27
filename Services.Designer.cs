namespace KSS
{
    partial class Services
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
            this.label3 = new System.Windows.Forms.Label();
            this.btnOther = new System.Windows.Forms.Button();
            this.btnBirth = new System.Windows.Forms.Button();
            this.btnDeath = new System.Windows.Forms.Button();
            this.btnMarrigage = new System.Windows.Forms.Button();
            this.btnId = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.content = new System.Windows.Forms.Panel();
            this.services_description = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.content.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Matura MT Script Capitals", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1523, 92);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to our kebele sevices feel free to choose any of the service and based on" +
    "t the description below";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnOther);
            this.panel1.Controls.Add(this.btnBirth);
            this.panel1.Controls.Add(this.btnDeath);
            this.panel1.Controls.Add(this.btnMarrigage);
            this.panel1.Controls.Add(this.btnId);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(263, 744);
            this.panel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Matura MT Script Capitals", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(34, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 53);
            this.label3.TabIndex = 7;
            this.label3.Text = "Services";
            // 
            // btnOther
            // 
            this.btnOther.BackColor = System.Drawing.Color.Gold;
            this.btnOther.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOther.Location = new System.Drawing.Point(6, 648);
            this.btnOther.Name = "btnOther";
            this.btnOther.Size = new System.Drawing.Size(257, 73);
            this.btnOther.TabIndex = 6;
            this.btnOther.Text = "Notification";
            this.btnOther.UseVisualStyleBackColor = false;
            this.btnOther.Click += new System.EventHandler(this.btnOther_Click);
            // 
            // btnBirth
            // 
            this.btnBirth.BackColor = System.Drawing.Color.Gold;
            this.btnBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBirth.Location = new System.Drawing.Point(6, 528);
            this.btnBirth.Name = "btnBirth";
            this.btnBirth.Size = new System.Drawing.Size(257, 73);
            this.btnBirth.TabIndex = 5;
            this.btnBirth.Text = "Birth Certificate";
            this.btnBirth.UseVisualStyleBackColor = false;
            this.btnBirth.Click += new System.EventHandler(this.btnBirth_Click);
            // 
            // btnDeath
            // 
            this.btnDeath.BackColor = System.Drawing.Color.Gold;
            this.btnDeath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeath.Location = new System.Drawing.Point(3, 395);
            this.btnDeath.Name = "btnDeath";
            this.btnDeath.Size = new System.Drawing.Size(257, 73);
            this.btnDeath.TabIndex = 4;
            this.btnDeath.Text = "Death Certificate";
            this.btnDeath.UseVisualStyleBackColor = false;
            this.btnDeath.Click += new System.EventHandler(this.btnDeath_Click);
            // 
            // btnMarrigage
            // 
            this.btnMarrigage.BackColor = System.Drawing.Color.Gold;
            this.btnMarrigage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMarrigage.Location = new System.Drawing.Point(3, 257);
            this.btnMarrigage.Name = "btnMarrigage";
            this.btnMarrigage.Size = new System.Drawing.Size(257, 73);
            this.btnMarrigage.TabIndex = 3;
            this.btnMarrigage.Text = "Marriage Certificate";
            this.btnMarrigage.UseVisualStyleBackColor = false;
            this.btnMarrigage.Click += new System.EventHandler(this.btnMarrigage_Click);
            // 
            // btnId
            // 
            this.btnId.BackColor = System.Drawing.Color.Gold;
            this.btnId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnId.Location = new System.Drawing.Point(3, 142);
            this.btnId.Name = "btnId";
            this.btnId.Size = new System.Drawing.Size(257, 73);
            this.btnId.TabIndex = 2;
            this.btnId.Text = "Id Certificate ";
            this.btnId.UseVisualStyleBackColor = false;
            this.btnId.Click += new System.EventHandler(this.btnId_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Tan;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(263, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1523, 92);
            this.panel2.TabIndex = 2;
            // 
            // content
            // 
            this.content.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.content.Controls.Add(this.services_description);
            this.content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.content.Location = new System.Drawing.Point(263, 92);
            this.content.Name = "content";
            this.content.Size = new System.Drawing.Size(1523, 652);
            this.content.TabIndex = 3;
            // 
            // services_description
            // 
            this.services_description.BackColor = System.Drawing.SystemColors.Info;
            this.services_description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.services_description.Location = new System.Drawing.Point(0, 0);
            this.services_description.Name = "services_description";
            this.services_description.Size = new System.Drawing.Size(1523, 652);
            this.services_description.TabIndex = 1;
            this.services_description.Text = "";
            // 
            // Services
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1786, 744);
            this.Controls.Add(this.content);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Services";
            this.Text = "Services";
            this.Load += new System.EventHandler(this.Services_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.content.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOther;
        private System.Windows.Forms.Button btnBirth;
        private System.Windows.Forms.Button btnDeath;
        private System.Windows.Forms.Button btnMarrigage;
        private System.Windows.Forms.Button btnId;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel content;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox services_description;
    }
}