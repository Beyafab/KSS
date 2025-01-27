using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace KSS
{
    public partial class LoginPage : Form
    {
        private string connectionString = @"Data Source=DESKTOP-PSPAAG7\SQLEXPRESS;Initial Catalog=KSS_2;Integrated Security=True;TrustServerCertificate=True";
        public LoginPage()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string username = tbUserName.Text.Trim();
            string password = tbPassword.Text.Trim();
            string role = cbRole.Text.Trim();

            // Validate input fields
            if (string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Please select a role.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Authenticate the user
            if (AuthenticateUser(username, password, role))
            {
                // If authentication is successful, show the appropriate form based on the role
                switch (role.ToLower()) // Convert role to lowercase for case-insensitive comparison
                {
                    case "manager":
                        Manager manager = new Manager();
                        this.Hide();
                        manager.ShowDialog();
                        this.Close();
                        break;

                    case "users":
                        Home home = new Home();
                        this.Hide();
                        home.ShowDialog();
                        this.Close();
                        break;

                    case "staff":
                        Staff staff = new Staff();
                        this.Hide();
                        staff.ShowDialog();
                        this.Close();
                        break;

                    default:
                        MessageBox.Show("Invalid role selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            else
            {
                // If authentication fails, show an error message
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool AuthenticateUser(string username, string password, string role)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                try
                {
                    connect.Open();

                    // Determine the table to query based on the selected role
                    string tableName;
                    switch (role.ToLower())
                    {
                        case "manager":
                            tableName = "manager";
                            break;
                        case "staff":
                            tableName = "staff";
                            break;
                        default:
                            tableName = "users"; // Default to "users" table for other roles
                            break;
                    }

                    // Query to retrieve the hashed password and role for the given username
                    string query = $@"
                SELECT password, RoleID 
                FROM {tableName} 
                WHERE username = @username";

                    using (SqlCommand cmd = new SqlCommand(query, connect))
                    {
                        cmd.Parameters.AddWithValue("@username", username);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedHash = reader["password"].ToString();
                                int userRoleId = Convert.ToInt32(reader["RoleID"]);

                                // Verify the password and role
                                return VerifyPassword(password, storedHash) && VerifyRole(userRoleId, role);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return false;
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        private bool VerifyRole(int userRoleId, string selectedRole)
        {
            // Map role names to RoleIDs (adjust based on your database schema)
            switch (selectedRole.ToLower()) // Convert role to lowercase for case-insensitive comparison
            {
                case "manager":
                    return userRoleId == 1; // Assuming RoleID 1 is for Manager
                case "users":
                    return userRoleId == 2; // Assuming RoleID 2 is for User
                case "staff":
                    return userRoleId == 3; // Assuming RoleID 3 is for Staff
                default:
                    return false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ChbShow_CheckedChanged(object sender, EventArgs e)
        {
            tbPassword.PasswordChar = ChbShow.Checked ? '\0' : '*';
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            RegisterationForm registerForm = new RegisterationForm();
            this.Hide();
            registerForm.ShowDialog();
            this.Close();
        }
    }
}
