using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace KSS
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }
        private string connectionString = @"Data Source=DESKTOP-PSPAAG7\SQLEXPRESS;Initial Catalog=KSS_2;Integrated Security=True;TrustServerCertificate=True";
        private void btnReport_Click(object sender, EventArgs e)
        {
            // Get the selected values from dropdowns
            string application = cbApp.Text;
            string dateFilter = cbDate.Text;
            DateTime dateTime = DateTime.Now;

            if (string.IsNullOrEmpty(application))
            {
                MessageBox.Show("Please select an application type.");
                return;
            }

            if (string.IsNullOrEmpty(dateFilter))
            {
                MessageBox.Show("Please select a date filter.");
                return;
            }

            // SQL query to fetch data from the selected table
            string query = $"SELECT * FROM {application}";
            string filterCondition = "";

            // Apply date filter based on the selection
            if (dateFilter == "1") // Dates before now
            {
                filterCondition = $" WHERE availableDates < @CurrentDate";
            }
            else if (dateFilter == "2") // Dates after now
            {
                filterCondition = $" WHERE availableDates > @CurrentDate";
            }

            // Finalize the query
            query += filterCondition;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (!string.IsNullOrEmpty(filterCondition))
                        {
                            command.Parameters.AddWithValue("@CurrentDate", dateTime);
                        }

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Bind the data to GridView1
                        dataGridView1.DataSource = dataTable;

                        // Display the report message
                        int recordCount = dataTable.Rows.Count;
                        lbReport.Text = $"There are {recordCount} users in {application}.";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }
    }

}

