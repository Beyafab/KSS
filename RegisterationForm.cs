using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace KSS
{
    public partial class RegisterationForm : Form
    {
        private string connectionString = @"Data Source=DESKTOP-PSPAAG7\SQLEXPRESS;Initial Catalog=KSS_2;Integrated Security=True;TrustServerCertificate=True";

        public RegisterationForm()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            // Validate input fields
            if (string.IsNullOrEmpty(tbUserName.Text) || string.IsNullOrEmpty(tbPassword.Text) ||
                string.IsNullOrEmpty(tbFname.Text) || string.IsNullOrEmpty(tbLname.Text) ||
                string.IsNullOrEmpty(tbEmail.Text) || string.IsNullOrEmpty(tbTelNo.Text)||string.IsNullOrEmpty(cbAge.Text))
            {
                ShowMessage("Please fill all blank fields", "Error Message", MessageBoxIcon.Error);
                return;
            }

            // Validate email format
            if (!IsValidEmail(tbEmail.Text))
            {
                ShowMessage("Please enter a valid email address.", "Error Message", MessageBoxIcon.Error);
                return;
            }

            // Validate phone number
            if (!IsValidPhoneNumber(tbTelNo.Text))
            {
                ShowMessage("Phone number must start with 07 or 09 and be exactly 10 digits long.", "Error Message", MessageBoxIcon.Error);
                return;
            }

            // Validate password strength
            if (!IsPasswordStrong(tbPassword.Text))
            {
                ShowMessage("Password must be at least 8 characters long and include at least one uppercase letter, one lowercase letter, one digit, and one special character.", "Error Message", MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                try
                {
                    connect.Open();

                    // Check if username already exists
                    string checkUsernameQuery = "SELECT COUNT(*) FROM users WHERE username = @username";
                    using (SqlCommand checkCmd = new SqlCommand(checkUsernameQuery, connect))
                    {
                        checkCmd.Parameters.AddWithValue("@username", tbUserName.Text.Trim());
                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            ShowMessage("Username already exists. Please choose a different username.", "Error Message", MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Check if email already exists
                    string checkEmailQuery = "SELECT COUNT(*) FROM users WHERE email = @email";
                    using (SqlCommand checkCmd = new SqlCommand(checkEmailQuery, connect))
                    {
                        checkCmd.Parameters.AddWithValue("@email", tbEmail.Text.Trim());
                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            ShowMessage("Email already exists. Please use a different email address.", "Error Message", MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Check if phone number already exists
                    string checkPhoneQuery = "SELECT COUNT(*) FROM users WHERE telephone = @phone";
                    using (SqlCommand checkCmd = new SqlCommand(checkPhoneQuery, connect))
                    {
                        checkCmd.Parameters.AddWithValue("@phone", tbTelNo.Text.Trim());
                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            ShowMessage("Phone number already exists. Please use a different phone number.", "Error Message", MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Hash the password
                    string hashedPassword = HashPassword(tbPassword.Text.Trim());

                    // Insert user data
                    InsertUser(connect, tbUserName.Text.Trim(), hashedPassword, tbFname.Text.Trim(), tbLname.Text.Trim(), tbTelNo.Text.Trim(), tbEmail.Text.Trim());

                    // Notify the user of success
                    ShowMessage("Registration Successful!", "Success Message", MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    ShowMessage($"Database error: {ex.Message}", "Error Message", MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    ShowMessage($"Error: {ex.Message}", "Error Message", MessageBoxIcon.Error);
                }
            }
        }

        private void InsertUser(SqlConnection connect, string username, string password, string firstName, string lastName, string phone, string email)
        {
            string insertData = "INSERT INTO users (username, password, firstName, lastName, telephone, email, RoleID,age) VALUES (@username, @password, @firstName, @lastName, @phone, @email, @RoleID,@age)";
            using (SqlCommand cmd = new SqlCommand(insertData, connect))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@RoleID", 2); // Assuming RoleID 2 is for regular users
                cmd.Parameters.AddWithValue("@age", cbAge.Text);
                cmd.ExecuteNonQuery();
            }
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt(12));
        }

        private bool IsPasswordStrong(string password)
        {
            // At least 8 characters, one uppercase, one lowercase, one digit, and one special character
            var regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$");
            return regex.IsMatch(password);
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

        private void ShowMessage(string message, string title, MessageBoxIcon icon)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
        }

        private void Chbshow_CheckedChanged_1(object sender, EventArgs e)
        {
            tbPassword.PasswordChar = Chbshow.Checked ? '\0' : '*';
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
