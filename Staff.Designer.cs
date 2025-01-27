namespace KSS
{
    partial class Staff
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.marriageReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Pcontent = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Yu Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.marriageReportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1127, 50);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // marriageReportToolStripMenuItem
            // 
            this.marriageReportToolStripMenuItem.Name = "marriageReportToolStripMenuItem";
            this.marriageReportToolStripMenuItem.Size = new System.Drawing.Size(156, 29);
            this.marriageReportToolStripMenuItem.Text = "Marriage Report";
            this.marriageReportToolStripMenuItem.Click += new System.EventHandler(this.marriageReportToolStripMenuItem_Click);
            // 
            // Pcontent
            // 
            this.Pcontent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pcontent.Location = new System.Drawing.Point(0, 50);
            this.Pcontent.Name = "Pcontent";
            this.Pcontent.Size = new System.Drawing.Size(1127, 591);
            this.Pcontent.TabIndex = 1;
            // 
            // Staff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 641);
            this.Controls.Add(this.Pcontent);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Staff";
            this.Text = "Staff";
            this.Load += new System.EventHandler(this.Staff_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem marriageReportToolStripMenuItem;
        private System.Windows.Forms.Panel Pcontent;
    }
}