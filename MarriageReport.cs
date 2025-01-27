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
    public partial class MarriageReport : Form
    {
        public MarriageReport()
        {
            InitializeComponent();
        }
        private string connectionString = @"Data Source=DESKTOP-PSPAAG7\SQLEXPRESS;Initial Catalog=KSS_2;Integrated Security=True;TrustServerCertificate=True";



        private void MarriageReport_Load(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        private void LoadDataIntoDataGridView()
        {
            try
            {
                // Create a connection to the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Define the SQL query to retrieve data from the marriageApplication table
                    string query = @"
                        SELECT 
                            ApplicationId, userId, serviceId, FullnameSpouse1, FullnameSpouse2, 
                            IdSpouse1, IdSpouse2, witnessAddress, phoneNo, Email, availableDates, 
                            amount, paymentMethod 
                        FROM marriageApplication";

                    // Create a SqlDataAdapter to execute the query and fill the DataTable
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();

                        // Fill the DataTable with the data from the database
                        adapter.Fill(dt);

                        // Bind the DataTable to the DataGridView
                        DG.DataSource = dt; // Ensure DG is the name of your DataGridView control
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSendNotification_Click(object sender, EventArgs e)
        {
            // Get selected application and date filter
            string application = cbApp.Text;
            string dateFilter = cbDate.Text;
            DateTime currentDate = DateTime.Now;

            // Validate inputs
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

            // Base query to select records
            string selectQuery = $"SELECT Fname, availableDates FROM {application}";
            string updateQuery = $"UPDATE {application} SET notification = @NotificationMessage WHERE Fname = @Fname";

            // Add date filter to the SELECT query
            if (dateFilter == "1") // Today
            {
                selectQuery += " WHERE CAST(availableDates AS DATE) = CAST(@CurrentDate AS DATE)";
            }
            else if (dateFilter == "2") // Dates before today
            {
                selectQuery += " WHERE availableDates < @CurrentDate";
            }
            else if (dateFilter == "3") // Dates after today
            {
                selectQuery += " WHERE availableDates > @CurrentDate";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Execute SELECT query to get the data
                    using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@CurrentDate", currentDate);

                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            // Prepare a list to store update commands
                            List<SqlCommand> updateCommands = new List<SqlCommand>();

                            while (reader.Read())
                            {
                                // Prepare notification message
                                DateTime availableDate = Convert.ToDateTime(reader["availableDates"]);
                                string notificationMessage = "Hi user, ";

                                if (dateFilter == "1") // Today
                                {
                                    notificationMessage += "your record is relevant for today.";
                                }
                                else if (dateFilter == "2") // Past dates
                                {
                                    notificationMessage += "this record is from a past date.";
                                }
                                else if (dateFilter == "3") // Future dates
                                {
                                    int daysUntilAppointment = (availableDate - currentDate).Days;
                                    notificationMessage += $"your schedule is {daysUntilAppointment} days from now.";
                                }

                                // Create the update command for each record
                                SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                                updateCommand.Parameters.AddWithValue("@NotificationMessage", notificationMessage);
                                updateCommand.Parameters.AddWithValue("@Fname", reader["Fname"]);
                                updateCommands.Add(updateCommand);
                            }

                            reader.Close();

                            // Execute all update commands
                            foreach (SqlCommand updateCommand in updateCommands)
                            {
                                updateCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    MessageBox.Show($"Notification messages updated successfully for {application}.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }

    }
}