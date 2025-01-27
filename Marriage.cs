using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KSS
{
    public partial class Marriage : Form
    {
        private string connectionString = @"Data Source=DESKTOP-PSPAAG7\SQLEXPRESS;Initial Catalog=KSS_2;Integrated Security=True;TrustServerCertificate=True";
        public Marriage()
        {
            InitializeComponent();
        }

        private string spouse1ImagePath = string.Empty; // Variable to store Spouse 1 image path
        private string spouse2ImagePath = string.Empty; // Variable to store Spouse 2 image path

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input fields
                var errors = ValidateInputFields();

                // Display errors if any
                if (errors.Length > 0)
                {
                    MessageBox.Show("Please fix the following errors:\n" + errors, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // If all validations pass, proceed with submission
                SaveDataToDatabase();
                MessageBox.Show("Submission successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Handle unexpected errors
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ValidateInputFields()
        {
            var errors = new StringBuilder();

            // Retrieve values from UI controls
            string spouseOne = tbSpouse1name.Text;
            string spouseTwo = tbSpouse2name.Text;
            string witnessAddress = tbWitnessAdd.Text;
            DateTime availableDate = dpAvbDate.Value;
            DateTime today = DateTime.Today;
            string emailAddress = tbEmailAdd.Text;
            string phoneNumber = tbPhoneNumber.Text.Trim(); // Trim leading/trailing spaces

            // Validate required fields
            if (string.IsNullOrEmpty(spouseOne))
                errors.AppendLine("Spouse 1's name is required.");
            if (string.IsNullOrEmpty(spouseTwo))
                errors.AppendLine("Spouse 2's name is required.");
            if (string.IsNullOrEmpty(witnessAddress))
                errors.AppendLine("Witness address is required.");
            if (availableDate <= today)
                errors.AppendLine("Available date must be after today.");
            if (string.IsNullOrEmpty(emailAddress))
                errors.AppendLine("Email address is required.");
            if (string.IsNullOrEmpty(phoneNumber))
                errors.AppendLine("Phone number is required.");

            // Validate phone number
            // Validate phone number
            

            if (!Regex.IsMatch(phoneNumber, @"^(09|07)\d{8}$"))
            {
                errors.AppendLine("Invalid phone number. Must start with 09 or 07 and be exactly 10 digits long.");
            }

            // Validate email
            try
            {
                var email = new System.Net.Mail.MailAddress(emailAddress);
            }
            catch
            {
                errors.AppendLine("Please enter a valid email address.");
            }

            // Validate images
            if (string.IsNullOrEmpty(spouse1ImagePath))
            {
                errors.AppendLine("Please upload Spouse 1's ID image.");
            }
            if (string.IsNullOrEmpty(spouse2ImagePath))
            {
                errors.AppendLine("Please upload Spouse 2's ID image.");
            }

            return errors.ToString();
        }

        private void SaveDataToDatabase()
        {
            // Retrieve values from UI controls
            string spouseOne = tbSpouse1name.Text;
            string spouseTwo = tbSpouse2name.Text;
            string witnessAddress = tbWitnessAdd.Text;
            DateTime availableDate = dpAvbDate.Value;
            string emailAddress = tbEmailAdd.Text;
            string phoneNumber = tbPhoneNumber.Text;
            int Amount = 200;


            // Save the data to a database
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();

                string query = @"
            INSERT INTO MarriageApplication (
                FullnameSpouse1, FullnameSpouse2, witnessAddress, availableDates, Email, phoneNo, amount, Spouse1Image, Spouse2Image
            )
            VALUES (
                @Spouse1Name, @Spouse2Name, @WitnessAddress, @AvailableDate, @Email, @PhoneNumber, @Amount, @Spouse1ImagePath, @Spouse2ImagePath
            )";

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    // Add parameters
                    cmd.Parameters.AddWithValue("@Spouse1Name", spouseOne);
                    cmd.Parameters.AddWithValue("@Spouse2Name", spouseTwo);
                    cmd.Parameters.AddWithValue("@WitnessAddress", witnessAddress);
                    cmd.Parameters.AddWithValue("@AvailableDate", availableDate);
                    cmd.Parameters.AddWithValue("@Email", emailAddress);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    cmd.Parameters.AddWithValue("@Amount", Amount);
                    cmd.Parameters.AddWithValue("@Spouse1ImagePath", spouse1ImagePath);
                    cmd.Parameters.AddWithValue("@Spouse2ImagePath", spouse2ImagePath);
                    cmd.Parameters.AddWithValue("@serviceId", 2); // Assuming service ID for Marriage certificate is 3
                    cmd.Parameters.AddWithValue("@paymentMethod", CbPaymentMethod.Text);

                    // Execute the query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void btnSpouse1id_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.jpg;*.jpeg;*.gif;*.bmp)|*.jpg;*.jpeg;*.gif;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Store the file path
                    spouse1ImagePath = openFileDialog.FileName;

                    // Load the image into the PictureBox
                    imgSp1.Image = Image.FromFile(spouse1ImagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSpouse2id_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.jpg;*.jpeg;*.gif;*.bmp)|*.jpg;*.jpeg;*.gif;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Store the file path
                    spouse2ImagePath = openFileDialog.FileName;

                    // Load the image into the PictureBox
                    imgSp2.Image = Image.FromFile(spouse2ImagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
