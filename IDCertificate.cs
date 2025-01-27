using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KSS
{
    public partial class IDCertificate : Form
    {
        private string connectionString = @"Data Source=DESKTOP-PSPAAG7\SQLEXPRESS;Initial Catalog=KSS_2;Integrated Security=True;TrustServerCertificate=True";
        public IDCertificate()
        {
            InitializeComponent();
        }

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

                // If all validations pass, proceed with processing the data
                SaveDataToDatabase();

                // Notify the user of success
                MessageBox.Show("ID Certificate data submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            string FirstName = tbFname.Text;
            string MiddleName = tbMname.Text;
            string LastName = tbLname.Text;
            DateTime birthdate = dpBirthdate.Value;
            string gender = cbSex.Text;
            string address = tbAddress.Text;
            string HouseNo = tbHousNo.Text;
            DateTime AvailableDate = dpAvailableDate.Value;
            string paymentMethod = cbPayment.Text;
            string EmeName = tbEmerName.Text;
            string EmeNO = tbEmerNO.Text;


            // Validate required fields
            if (string.IsNullOrWhiteSpace(FirstName))
                errors.AppendLine("First name is required.");
            if (string.IsNullOrWhiteSpace(LastName))
                errors.AppendLine("Last name is required.");
            if (birthdate > DateTime.Today)
                errors.AppendLine("Birth date cannot be in the future.");
            if (string.IsNullOrWhiteSpace(gender))
                errors.AppendLine("Gender is required.");
            if (string.IsNullOrWhiteSpace(address))
                errors.AppendLine("Address is required.");
            if (string.IsNullOrWhiteSpace(HouseNo))
                errors.AppendLine("House number is required.");
            if (AvailableDate < DateTime.Today)
                errors.AppendLine("Available date cannot be in the past.");
            if (string.IsNullOrWhiteSpace(paymentMethod))
                errors.AppendLine("Payment method is required.");
            if (string.IsNullOrWhiteSpace(EmeName))
                errors.AppendLine("Emergency contact name is required.");
            if (string.IsNullOrWhiteSpace(EmeNO) || !Regex.IsMatch(EmeNO, @"^(09|07)\d{8}$"))
                errors.AppendLine("Emergency contact number must start with 09 or 07 and be exactly 10 digits long.");

            return errors.ToString();
        }

        private void SaveDataToDatabase()
        {
            // Retrieve values from UI controls
            string FirstName = tbFname.Text;
            string MiddleName = tbMname.Text;
            string LastName = tbLname.Text;
            DateTime birthdate = dpBirthdate.Value;
            string gender = cbSex.Text;
            string address = tbAddress.Text;
            string HouseNo = tbHousNo.Text;
            DateTime AvailableDate = dpAvailableDate.Value;
            string paymentMethod = cbPayment.Text;
            string EmeName = tbEmerName.Text;
            string EmeNO = tbEmerNO.Text;

            // Save the data to a database
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();

                string query = @"
            INSERT INTO IDApplication (
                Fname, Mname, Lname, Bdate, Sex, Address, HouseNo, availableDates, paymentMethod, EmergencyContactName, EmergencyContactNumber,amount,serviceId
            )
            VALUES (
                @FirstName, @MiddleName, @LastName, @Birthdate, @Gender, @Address, @HouseNo, @AvailableDate, @PaymentMethod, @EmergencyContactName, @EmergencyContactNumber,@amount,@serviceID
            )";

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    // Add parameters
                    cmd.Parameters.AddWithValue("@FirstName", FirstName);
                    cmd.Parameters.AddWithValue("@MiddleName", MiddleName);
                    cmd.Parameters.AddWithValue("@LastName", LastName);
                    cmd.Parameters.AddWithValue("@Birthdate", birthdate);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@HouseNo", HouseNo);
                    cmd.Parameters.AddWithValue("@AvailableDate", AvailableDate);
                    cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                    cmd.Parameters.AddWithValue("@EmergencyContactName", EmeName);
                    cmd.Parameters.AddWithValue("@EmergencyContactNumber", EmeNO);
                    cmd.Parameters.AddWithValue("@amount", 200); // Assuming the amount is fixed
                    cmd.Parameters.AddWithValue("@serviceID", 4); // Assuming service ID for ID certificate is 1

                    // Execute the query
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
