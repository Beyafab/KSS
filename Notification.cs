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

namespace KSS
{

    public partial class Notification : Form
    {
    private string connectionString = @"Data Source=DESKTOP-PSPAAG7\SQLEXPRESS;Initial Catalog=KSS_2;Integrated Security=True;TrustServerCertificate=True";
        public Notification()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string application = cbApp.Text;
            string firstName = tbFname.Text;
            string lastName = tbLname.Text;

            // Validate inputs
            if (string.IsNullOrEmpty(application))
            {
                MessageBox.Show("Please select an application type.");
                return;
            }

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                MessageBox.Show("Please provide both first and last names.");
                return;
            }

            // Define the base query for retrieving notifications
            string selectQuery = $"SELECT notification FROM {application} WHERE FName = @FirstName AND LName = @LastName";

            // Special case for marriageApplication: Assuming it uses FullNameSpouse1 and FullNameSpouse2
            if (application == "marriageApplication")
            {
                selectQuery = $"SELECT notification FROM {application} WHERE FullNameSpouse1 = @FirstName AND FullNameSpouse2 = @LName";
            }

            // Create a DataTable to hold the results
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Execute SELECT query to get the notification data
                    using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                    {
                        // Add parameters to prevent SQL injection
                        selectCommand.Parameters.AddWithValue("@FirstName", firstName);
                        selectCommand.Parameters.AddWithValue("@LastName", lastName);

                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            // Load data into DataTable
                            dataTable.Load(reader);
                        }
                    }

                    // Check if data is found and display it in the DataGridView
                    if (dataTable.Rows.Count > 0)
                    {
                        // Bind the DataTable to the DataGridView
                        dataGridView1.DataSource = dataTable;
                    }
                    else
                    {
                        MessageBox.Show("No notifications found for the provided name.");
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
