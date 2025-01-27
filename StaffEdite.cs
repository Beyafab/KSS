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
using System.Text.RegularExpressions;

namespace KSS
{
    public partial class StaffEdite : Form
    {
        public StaffEdite()
        {
            InitializeComponent();
        }
        private string connectionString = @"Data Source=DESKTOP-PSPAAG7\SQLEXPRESS;Initial Catalog=KSS_2;Integrated Security=True;TrustServerCertificate=True";
        private DataTable dt = new DataTable();

        private void StaffEdite_Load(object sender, EventArgs e)
        {

            // Set up the DataTable columns
            dt.Columns.Add("staffId", typeof(int));
            dt.Columns.Add("Fname", typeof(string));
            dt.Columns.Add("Lname", typeof(string));
            dt.Columns.Add("Telephone", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("RoleID", typeof(int)); // Ensure Role is of type int
            dt.Columns.Add("Username", typeof(string));
            dt.Columns.Add("Password", typeof(string));

            // Load data from the database into the DataTable
            LoadStaffData();

            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = dt;
        }

        private void LoadStaffData()
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                try
                {
                    connect.Open();

                    // Query to select all staff data
                    string query = "SELECT staffId, Fname, Lname, telephone, email, RoleID, username, password FROM staff";

                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Clear existing data in the DataTable
                            dt.Rows.Clear();

                            // Load data into the DataTable
                            while (reader.Read())
                            {
                                dt.Rows.Add(
                                    reader["staffId"],
                                    reader["Fname"],
                                    reader["Lname"],
                                    reader["telephone"],
                                    reader["email"],
                                    reader["RoleID"],
                                    reader["username"],
                                    reader["password"]
                                );
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading staff data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Validate input fields
            if (!ValidateInputs())
                return;

            // Check if the username already exists
            if (IsUsernameExists(tbUsername.Text))
            {
                MessageBox.Show("Username already exists. Please choose a different username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get the RoleID based on the selected role
            int roleId = GetRoleId(cbRole.Text);
            if (roleId == -1)
            {
                MessageBox.Show("Invalid role selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Add the new row to the DataTable
            dt.Rows.Add(null, tbFname.Text, tbLname.Text, tbPhone.Text, tbEmail.Text, roleId, tbUsername.Text, tbPassword.Text);

            // Save the new row to the database
            SaveStaffToDatabase(tbFname.Text, tbLname.Text, tbPhone.Text, tbEmail.Text, roleId, tbUsername.Text, tbPassword.Text);

            // Clear input fields
            ClearInputs();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear all input fields
            ClearInputs();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Validate input fields
            if (!ValidateInputs())
                return;

            // Get the selected row from the DataGridView
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Please select a row to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get the RoleID based on the selected role
            int roleId = GetRoleId(cbRole.Text);
            if (roleId == -1)
            {
                MessageBox.Show("Invalid role selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Update the selected row in the DataTable
            DataGridViewRow row = dataGridView1.CurrentRow;
            row.Cells["Fname"].Value = tbFname.Text;
            row.Cells["Lname"].Value = tbLname.Text;
            row.Cells["telephone"].Value = tbPhone.Text;
            row.Cells["email"].Value = tbEmail.Text;
            row.Cells["RoleID"].Value = roleId; // Use RoleID instead of Role
            row.Cells["username"].Value = tbUsername.Text;
            row.Cells["password"].Value = tbPassword.Text;

            // Update the row in the database
            UpdateStaffInDatabase(
                Convert.ToInt32(row.Cells["staffId"].Value),
                tbFname.Text, tbLname.Text, tbPhone.Text, tbEmail.Text, roleId, tbUsername.Text, tbPassword.Text
            );

            // Clear input fields
            ClearInputs();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Get the selected row from the DataGridView
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Please select a row to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Confirm deletion
            DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Delete the selected row from the DataTable
                DataGridViewRow row = dataGridView1.CurrentRow;
                int staffId = Convert.ToInt32(row.Cells["staffId"].Value);
                int roleId = Convert.ToInt32(row.Cells["RoleID"].Value); // Get the RoleID
                dt.Rows.RemoveAt(dataGridView1.CurrentRow.Index);

                // Delete the row from the database
                DeleteStaffFromDatabase(staffId, roleId);
            }
        }

        private bool ValidateInputs()
        {
            // Validate required fields
            if (string.IsNullOrEmpty(tbFname.Text) || string.IsNullOrEmpty(tbLname.Text) ||
                string.IsNullOrEmpty(tbPhone.Text) || string.IsNullOrEmpty(tbEmail.Text) ||
                string.IsNullOrEmpty(cbRole.Text) || string.IsNullOrEmpty(tbUsername.Text) ||
                string.IsNullOrEmpty(tbPassword.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validate email format
            if (!IsValidEmail(tbEmail.Text))
            {
                MessageBox.Show("Please enter a valid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validate phone number format
            if (!IsValidPhoneNumber(tbPhone.Text))
            {
                MessageBox.Show("Phone number must start with 07 or 09 and be exactly 10 digits long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new System.Net.Mail.MailAddress(email);
                return mailAddress.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Phone number must start with 07 or 09 and be exactly 10 digits long
            var regex = new Regex(@"^(07|09)\d{8}$");
            return regex.IsMatch(phoneNumber);
        }

        private bool IsUsernameExists(string username)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                try
                {
                    connect.Open();

                    // Query to check if the username already exists
                    string query = "SELECT COUNT(*) FROM staff WHERE username = @Username";

                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error checking username: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        private int GetRoleId(string selectedRole)
        {
            // Map role names to RoleIDs (adjust based on your database schema)
            switch (selectedRole.ToLower()) // Convert role to lowercase for case-insensitive comparison
            {
                case "manager":
                    return 1; // Assuming RoleID 1 is for Manager
                case "staff":
                    return 3; // Assuming RoleID 3 is for Staff
                default:
                    return -1; // Invalid role
            }
        }

        private void SaveStaffToDatabase(string fname, string lname, string telephone, string email, int roleId, string username, string password)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                try
                {
                    connect.Open();

                    // Hash the password before saving
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                    // Determine the table name based on RoleID
                    string tableName = (roleId == 1) ? "manager" : "staff";

                    // Query to insert a new record
                    string query = $@"
                    INSERT INTO {tableName} (Fname, Lname, telephone, email, RoleID, username, password)
                    VALUES (@Fname, @Lname, @Telephone, @Email, @RoleID, @Username, @Password)";

                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {
                        // Add parameters
                        cmd.Parameters.AddWithValue("@Fname", fname);
                        cmd.Parameters.AddWithValue("@Lname", lname);
                        cmd.Parameters.AddWithValue("@Telephone", telephone);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@RoleID", roleId); // Use RoleID instead of Role
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", hashedPassword); // Save the hashed password

                        // Execute the query
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Record added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateStaffInDatabase(int staffId, string fname, string lname, string telephone, string email, int roleId, string username, string password)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                try
                {
                    connect.Open();

                    // Hash the password before updating
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                    // Determine the table name based on RoleID
                    string tableName = (roleId == 1) ? "manager" : "staff";

                    // Query to update a record
                    string query = $@"
                    UPDATE {tableName} 
                    SET 
                        Fname = @Fname,
                        Lname = @Lname,
                        telephone = @Telephone,
                        email = @Email,
                        RoleID = @RoleID,
                        username = @Username,
                        password = @Password
                    WHERE staffId = @staffId";

                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {
                        // Add parameters
                        cmd.Parameters.AddWithValue("@Fname", fname);
                        cmd.Parameters.AddWithValue("@Lname", lname);
                        cmd.Parameters.AddWithValue("@Telephone", telephone);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@RoleID", roleId); // Use RoleID instead of Role
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", hashedPassword); // Save the hashed password
                        cmd.Parameters.AddWithValue("@staffId", staffId);

                        // Execute the query
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DeleteStaffFromDatabase(int staffId, int roleId)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                try
                {
                    connect.Open();

                    // Determine the table name based on RoleID
                    string tableName = (roleId == 1) ? "manager" : "staff";

                    // Query to delete a record
                    string query = $"DELETE FROM {tableName} WHERE staffId = @staffId";

                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {
                        cmd.Parameters.AddWithValue("@staffId", staffId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearInputs()
        {
            tbFname.Clear();
            tbLname.Clear();
            tbPhone.Clear();
            tbEmail.Clear();
            cbRole.SelectedIndex = -1;
            tbUsername.Clear();
            tbPassword.Clear();
        }
    }
}


