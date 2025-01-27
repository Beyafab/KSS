using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KSS
{
    public partial class Death : Form
    {
        private string idImagePath;
        private string confirmationLePath;
        private string connectionString = @"Data Source=DESKTOP-PSPAAG7\SQLEXPRESS;Initial Catalog=KSS_2;Integrated Security=True;TrustServerCertificate=True";

        public Death()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input fields
                string validationErrors = ValidateInputFields();

                if (!string.IsNullOrEmpty(validationErrors))
                {
                    MessageBox.Show("Please fix the following errors:\n" + validationErrors, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // If all validations pass, proceed with submission
                SaveDataToDatabase();

                // Notify the user of success
                MessageBox.Show("Data submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            string idImg = idImagePath;
            string conLetter = confirmationLePath;
            DateTime availableDate = dpAvDate.Value;
            DateTime today = DateTime.Today;
            string paymentMethod = cbPayment.Text;

            // Validate required fields
            if (string.IsNullOrEmpty(idImg) || !File.Exists(idImg))
                errors.AppendLine("ID image is required and must be a valid file.");
            if (string.IsNullOrEmpty(conLetter) || !File.Exists(conLetter))
                errors.AppendLine("Confirmation letter is required and must be a valid file.");
            if (availableDate <= today)
                errors.AppendLine("Available date must be after today.");
            if (string.IsNullOrEmpty(paymentMethod))
                errors.AppendLine("Payment method is required.");

            return errors.ToString();
        }

        private void SaveDataToDatabase()
        {
            // Retrieve values from UI controls
            string idImg = idImagePath;
            string conLetter = confirmationLePath;
            DateTime availableDate = dpAvDate.Value;
            string paymentMethod = cbPayment.Text;
            string FirstName = tbFname.Text;
            string MiddleName = tbMname.Text;
            string LastName = tbLname.Text;
            decimal amount = 100.00m; // Replace with actual amount

            // Save the data to a database
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();

                string query = @"
                INSERT INTO deathApplication (
                    serviceId,Fname, Mname, Lname, 
                    ConfirmationLetter, availableDates, paymentMethod, amount
                )
                VALUES (
                    @serviceId,@Fname, @Mname, @Lname, 
                    @ConfirmationLetter, @availableDates, @paymentMethod, @amount
                )";

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    // Add parameters
                    cmd.Parameters.AddWithValue("@serviceId", 3); // Replace with actual serviceId
                    cmd.Parameters.AddWithValue("@Fname", FirstName); // Replace with actual first name
                    cmd.Parameters.AddWithValue("@Mname", MiddleName); // Replace with actual middle name
                    cmd.Parameters.AddWithValue("@Lname", LastName); // Replace with actual last name
                    cmd.Parameters.AddWithValue("@ConfirmationLetter", conLetter);
                    cmd.Parameters.AddWithValue("@availableDates", availableDate);
                    cmd.Parameters.AddWithValue("@paymentMethod", paymentMethod);
                    cmd.Parameters.AddWithValue("@amount", amount);

                    // Execute the query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void btnScanID_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files(*.jpg;*.jpeg;*.gif;*.bmp)|*.jpg;*.jpeg;*.gif;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Store the file path
                    idImagePath = openFileDialog.FileName;

                    // Load the image into the PictureBox
                    pbId.Image = Image.FromFile(idImagePath);
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("The selected file was not found.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("The selected file is not a valid image.", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading the image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirmationLe_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files(*.jpg;*.jpeg;*.gif;*.bmp)|*.jpg;*.jpeg;*.gif;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Store the file path
                    confirmationLePath = openFileDialog.FileName;

                    // Load the image into the PictureBox
                    pbConLetter.Image = Image.FromFile(confirmationLePath);
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("The selected file was not found.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("The selected file is not a valid image.", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading the image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
