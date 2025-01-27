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
    public partial class Birth : Form
    {
        private string connectionString = @"Data Source=DESKTOP-PSPAAG7\SQLEXPRESS;Initial Catalog=KSS_2;Integrated Security=True;TrustServerCertificate=True";
        public Birth()
        {
            InitializeComponent();
        }

        private string idPhoto = string.Empty; // Variable to store the ID photo file path

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
            string Name = tbName.Text;
            string Fname = tbFaName.Text;
            string Gname = tbGrName.Text;
            string sex = cbSex.Text;
            string placeOfBirth = tbPlaceOfBirth.Text;
            DateTime birthDate = dpBirthDate.Value;
            DateTime today = DateTime.Today;
            string region = tbRegion.Text;
            string zone = tbZone.Text;
            string woreda = tbWoreda.Text;
            string nationality = tbNationality.Text;
            string MotherName = tbMotherName.Text;
            string FatherName = tbFatherName.Text;
            string FatherNation = tbFatherNation.Text;
            string MotherNation = tbMotherNation.Text;
            string paymentMethod = cbPaymentMethod.Text;
            DateTime availableDate = dpAvDate.Value; // Assuming dpAvDate is a DateTimePicker control

            // Validate required fields
            if (string.IsNullOrEmpty(Name))
                errors.AppendLine("Name is required.");
            if (string.IsNullOrEmpty(Fname))
                errors.AppendLine("Father's name is required.");
            if (string.IsNullOrEmpty(Gname))
                errors.AppendLine("Grandfather's name is required.");
            if (string.IsNullOrEmpty(sex))
                errors.AppendLine("Sex is required.");
            if (string.IsNullOrEmpty(placeOfBirth))
                errors.AppendLine("Place of birth is required.");
            if (birthDate > today)
                errors.AppendLine("Birth date cannot be in the future.");
            if (string.IsNullOrEmpty(region))
                errors.AppendLine("Region is required.");
            if (string.IsNullOrEmpty(zone))
                errors.AppendLine("Zone is required.");
            if (string.IsNullOrEmpty(woreda))
                errors.AppendLine("Woreda is required.");
            if (string.IsNullOrEmpty(nationality))
                errors.AppendLine("Nationality is required.");
            if (string.IsNullOrEmpty(MotherName))
                errors.AppendLine("Mother's name is required.");
            if (string.IsNullOrEmpty(FatherName))
                errors.AppendLine("Father's name is required.");
            if (string.IsNullOrEmpty(FatherNation))
                errors.AppendLine("Father's nationality is required.");
            if (string.IsNullOrEmpty(MotherNation))
                errors.AppendLine("Mother's nationality is required.");
            if (string.IsNullOrEmpty(idPhoto))
                errors.AppendLine("ID photo is required.");
            if (string.IsNullOrEmpty(paymentMethod))
                errors.AppendLine("Payment method is required.");

            // Validate availableDate
            if (availableDate < today)
            {
                errors.AppendLine("Available date cannot be in the past.");
            }
            else if (availableDate > today.AddYears(1)) // Example: Restrict to within 1 year from today
            {
                errors.AppendLine("Available date cannot be more than 1 year in the future.");
            }

            return errors.ToString();
        
        }

        private void SaveDataToDatabase()
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();

                // Insert data into the database
                string query = @"
            INSERT INTO BirthApplication (
                Fname, Mname, Lname, Sex, Bplace, Bdate, subCity, region, zone, woreda, nationality,
                mothersFullname, mothersNationality, FathersFullname, fathersNationality, IDPhoto, amount, paymentMethod,serviceId,availableDates
            )
            VALUES (
                @Name, @Mname, @Lname, @Sex, @Bplace, @Bdate, @subCity, @region, @zone, @woreda, @nationality,
                @motherFullname, @mothersNationality, @FathersFullname, @fathersNationality, @IDPhoto, @amount,@paymentMethod,@serviceId,@availableDates
            )";

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    // Add parameters
                    cmd.Parameters.AddWithValue("@Name", tbName.Text);
                    cmd.Parameters.AddWithValue("@Mname", tbFaName.Text); // Assuming Mname is Father's Name
                    cmd.Parameters.AddWithValue("@Lname", tbGrName.Text); // Assuming Lname is Grandfather's Name
                    cmd.Parameters.AddWithValue("@Sex", cbSex.Text);
                    cmd.Parameters.AddWithValue("@Bplace", tbPlaceOfBirth.Text);
                    cmd.Parameters.AddWithValue("@Bdate", dpBirthDate.Value);
                    cmd.Parameters.AddWithValue("@subCity", tbRegion.Text); // Assuming subCity is Region
                    cmd.Parameters.AddWithValue("@region", tbZone.Text); // Assuming region is Zone
                    cmd.Parameters.AddWithValue("@zone", tbWoreda.Text); // Assuming zone is Woreda
                    cmd.Parameters.AddWithValue("@woreda", tbNationality.Text); // Assuming woreda is Nationality
                    cmd.Parameters.AddWithValue("@nationality", tbMotherName.Text); // Assuming nationality is Mother's Name
                    cmd.Parameters.AddWithValue("@motherFullname", tbFatherName.Text); // Assuming motherFullname is Father's Name
                    cmd.Parameters.AddWithValue("@mothersNationality", tbMotherNation.Text);
                    cmd.Parameters.AddWithValue("@FathersFullname", tbFatherName.Text);
                    cmd.Parameters.AddWithValue("@fathersNationality", tbFatherNation.Text);
                    cmd.Parameters.AddWithValue("@IDPhoto", idPhoto); // Ensure idPhoto is properly initialized
                    cmd.Parameters.AddWithValue("@amount", 200); // Hardcoded amount
                    cmd.Parameters.AddWithValue("@paymentMethod", cbPaymentMethod.Text);
                    cmd.Parameters.AddWithValue("@serviceId", 1); // Assuming serviceId is 1
                    cmd.Parameters.AddWithValue("@availableDates", dpAvDate.Value);
                    // Execute the query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files(*.jpg;*.jpeg;*.gif;*.bmp)|*.jpg;*.jpeg;*.gif;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Store the file path
                    idPhoto = openFileDialog.FileName;

                    // Load the image into the PictureBox
                    pb_Id.Image = Image.FromFile(idPhoto);

                    // Optionally, display the file path in a label or textbox
                    
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
