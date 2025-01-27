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
    public partial class Manager : Form
    {
        public Manager()
        {
            InitializeComponent();
        }

        private void Manager_Load(object sender, EventArgs e)
        {
            // Set the form to be maximized when loaded
            this.WindowState = FormWindowState.Maximized;
            StaffEdite staffEdit = new StaffEdite();
            Nav(staffEdit, Pcontent);
        }

        private void staffsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StaffEdite staffEdit = new StaffEdite();
            Nav(staffEdit, Pcontent);
        }
        static void Nav(Form form, Panel panel)
        {
            form.TopLevel = false;
            panel.Controls.Clear();
            form.FormBorderStyle = FormBorderStyle.None; // Remove form borders for better fit
            form.Dock = DockStyle.Fill; // Dock the form to fill the entire panel
            panel.Controls.Add(form);
            form.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nav(new Users(), Pcontent);
        }
    }
}
