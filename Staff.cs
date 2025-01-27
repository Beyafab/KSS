using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KSS
{
    public partial class Staff : Form
    {
        public Staff()
        {
            InitializeComponent();
        }

        private void Staff_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            MarriageReport idReport = new MarriageReport();
            Nav(idReport, Pcontent);

        }
        public void Nav(Form form, Panel panel)
        {
            form.TopLevel = false;
            panel.Controls.Clear();
            form.FormBorderStyle = FormBorderStyle.None; // Remove form borders for better fit
            form.Dock = DockStyle.Fill; // Dock the form to fill the entire panel
            panel.Controls.Add(form);
            form.Show();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void birthReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void deathReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void marriageReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nav(new MarriageReport(), Pcontent);
        }
    }
}
