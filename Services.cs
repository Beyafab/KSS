using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KSS
{
    public partial class Services : Form
    {
        public Services()
        {
            InitializeComponent();
        }

        static void Nav(Form form, Panel panel)
        {
            form.TopLevel = false;
            panel.Controls.Clear();
            form.FormBorderStyle = FormBorderStyle.None; // Remove form borders for better fit
            form.Dock = DockStyle.Fill; // Dock the form to fill the entire panel
            panel.Controls.Add(form);
            form.Show();
        }
        private void btnId_Click(object sender, EventArgs e)
        {
            IDCertificate iDCertificate = new IDCertificate();
            Nav(iDCertificate, content);
        }

        private void btnMarrigage_Click(object sender, EventArgs e)
        {
            Marriage marriage = new Marriage();
            Nav(marriage, content);
        }

        private void btnDeath_Click(object sender, EventArgs e)
        {
            Death death = new Death();
            Nav(death, content);
        }

        private void btnBirth_Click(object sender, EventArgs e)
        {
            Birth birth = new Birth();
            Nav(birth, content);
        }

        private void Services_Load(object sender, EventArgs e)
        {
            // Clear the RichTextBox before adding new content
            services_description.Clear();

            // Set default font for the RichTextBox
            services_description.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            // Add formatted text to the RichTextBox
            AppendFormattedText("Welcome to KSS Services!\n", FontStyle.Bold, Color.DarkBlue, 12);
            AppendFormattedText("At the ", FontStyle.Regular, Color.Black, 10);
            AppendFormattedText("Kebele Schedule System (KSS)", FontStyle.Bold, Color.DarkBlue, 10);
            AppendFormattedText(", we are committed to providing you with fast, reliable, and hassle-free access to essential civil documentation services. Whether you need an ID certificate, birth certificate, death certificate, or marriage certificate, our platform is here to simplify the process for you. Below is a detailed overview of the services we offer:\n\n", FontStyle.Regular, Color.Black, 10);

            // Add separator line
            AppendFormattedText("----------------------------------------\n\n", FontStyle.Regular, Color.Gray, 10);

            // ID Certificate Service
            AppendFormattedText("1. ID Certificate Service\n", FontStyle.Bold, Color.DarkGreen, 12);
            AppendFormattedText("Your ", FontStyle.Regular, Color.Black, 10);
            AppendFormattedText("ID Certificate", FontStyle.Bold, Color.DarkGreen, 10);
            AppendFormattedText(" is your gateway to accessing a wide range of government and private services. Whether you're applying for a job, opening a bank account, or enrolling in school, a valid ID certificate is essential.\n", FontStyle.Regular, Color.Black, 10);
            AppendFormattedText("- Why Choose KSS?\n", FontStyle.Bold, Color.DarkGreen, 10);
            AppendFormattedText("  - Fast and secure application process.\n", FontStyle.Regular, Color.Black, 10);
            AppendFormattedText("  - Real-time tracking of your application status.\n", FontStyle.Regular, Color.Black, 10);
            AppendFormattedText("  - Receive reminders and updates via SMS or email.\n", FontStyle.Regular, Color.Black, 10);
            AppendFormattedText("- How to Apply:\n", FontStyle.Bold, Color.DarkGreen, 10);
            AppendFormattedText("  Simply book an appointment through our platform, bring the required documents, and let us handle the rest!\n\n", FontStyle.Regular, Color.Black, 10);

            // Add separator line
            AppendFormattedText("----------------------------------------\n\n", FontStyle.Regular, Color.Gray, 10);

            // Birth Certificate Service
            AppendFormattedText("2. Birth Certificate Service\n", FontStyle.Bold, Color.DarkOrange, 12);
            AppendFormattedText("A ", FontStyle.Regular, Color.Black, 10);
            AppendFormattedText("Birth Certificate", FontStyle.Bold, Color.DarkOrange, 10);
            AppendFormattedText(" is the first legal document that establishes your identity and citizenship. It is crucial for school enrollment, healthcare access, and other legal processes.\n", FontStyle.Regular, Color.Black, 10);
            AppendFormattedText("- Why Choose KSS?\n", FontStyle.Bold, Color.DarkOrange, 10);
            AppendFormattedText("  - Simplified registration process for newborns and late registrations.\n", FontStyle.Regular, Color.Black, 10);
            AppendFormattedText("  - Digital storage for easy retrieval and reissuance.\n", FontStyle.Regular, Color.Black, 10);
            AppendFormattedText("  - Friendly and professional staff to guide you every step of the way.\n", FontStyle.Regular, Color.Black, 10);
            AppendFormattedText("- How to Apply:\n", FontStyle.Bold, Color.DarkOrange, 10);
            AppendFormattedText("  Schedule an appointment online, provide the necessary details, and receive your birth certificate in no time!\n\n", FontStyle.Regular, Color.Black, 10);

            // Add separator line
            AppendFormattedText("----------------------------------------\n\n", FontStyle.Regular, Color.Gray, 10);

            // Death Certificate Service
            AppendFormattedText("3. Death Certificate Service\n", FontStyle.Bold, Color.DarkRed, 12);
            AppendFormattedText("A ", FontStyle.Regular, Color.Black, 10);
            AppendFormattedText("Death Certificate", FontStyle.Bold, Color.DarkRed, 10);
            AppendFormattedText(" is a vital document required for legal and administrative purposes, such as settling estates, claiming insurance, and closing accounts.\n", FontStyle.Regular, Color.Black, 10);
            AppendFormattedText("- Why Choose KSS?\n", FontStyle.Bold, Color.DarkRed, 10);
            AppendFormattedText("  - Compassionate and efficient service during difficult times.\n", FontStyle.Regular, Color.Black, 10);
            AppendFormattedText("  - Streamlined process to minimize delays.\n", FontStyle.Regular, Color.Black, 10);
            AppendFormattedText("  - Secure and confidential handling of sensitive information.\n", FontStyle.Regular, Color.Black, 10);
            AppendFormattedText("- How to Apply:\n", FontStyle.Bold, Color.DarkRed, 10);
            AppendFormattedText("  Book an appointment, submit the required documentation, and we will ensure the process is handled with care and respect.\n\n", FontStyle.Regular, Color.Black, 10);

            // Add separator line
            AppendFormattedText("----------------------------------------\n\n", FontStyle.Regular, Color.Gray, 10);

            // Marriage Certificate Service
            AppendFormattedText("4. Marriage Certificate Service\n", FontStyle.Bold, Color.Purple, 12);
            AppendFormattedText("Your ", FontStyle.Regular, Color.Black, 10);
            AppendFormattedText("Marriage Certificate", FontStyle.Bold, Color.Purple, 10);
            AppendFormattedText(" is an official record of your union and is required for legal, financial, and social purposes. Celebrate your love with a document that stands the test of time!\n", FontStyle.Regular, Color.Black, 10);
            AppendFormattedText("- Why Choose KSS?\n", FontStyle.Bold, Color.Purple, 10);
            AppendFormattedText("  - Easy and stress-free registration process.\n", FontStyle.Regular, Color.Black, 10);
            AppendFormattedText("  - Beautifully designed certificates to commemorate your special day.\n", FontStyle.Regular, Color.Black, 10);
            AppendFormattedText("  - Quick issuance and delivery options.\n", FontStyle.Regular, Color.Black, 10);
            AppendFormattedText("- How to Apply:\n", FontStyle.Bold, Color.Purple, 10);
            AppendFormattedText("  Schedule an appointment, bring the necessary documents, and let us take care of the rest while you focus on your happily ever after.\n\n", FontStyle.Regular, Color.Black, 10);

            // Add separator line
            AppendFormattedText("----------------------------------------\n\n", FontStyle.Regular, Color.Gray, 10);

            // Why Choose KSS?
            AppendFormattedText("Why Choose Kebele Schedule System (KSS)?\n", FontStyle.Bold, Color.DarkBlue, 12);
            AppendFormattedText("- Convenience: Book appointments online and avoid long queues.\n", FontStyle.Regular, Color.Black, 10);
            AppendFormattedText("- Transparency: Track your application status in real time.\n", FontStyle.Regular, Color.Black, 10);
            AppendFormattedText("- Efficiency: Receive your documents faster with our streamlined processes.\n", FontStyle.Regular, Color.Black, 10);
            AppendFormattedText("- Support: Our friendly team is always ready to assist you.\n\n", FontStyle.Regular, Color.Black, 10);

            // Add separator line
            AppendFormattedText("----------------------------------------\n\n", FontStyle.Regular, Color.Gray, 10);

            // Call to Action
            AppendFormattedText("Get Started Today!\n", FontStyle.Bold, Color.DarkBlue, 12);
            AppendFormattedText("Select a service from the menu above to begin your application process. At KSS, we are here to make your experience smooth, efficient, and stress-free. Welcome to the future of civil documentation services!\n", FontStyle.Regular, Color.Black, 10);
        }

        // Helper method to append formatted text to the RichTextBox
        private void AppendFormattedText(string text, FontStyle style, Color color, float fontSize)
        {
            services_description.SelectionStart = services_description.TextLength;
            services_description.SelectionLength = 0;
            services_description.SelectionFont = new Font(services_description.Font.FontFamily, fontSize, style);
            services_description.SelectionColor = color;
            services_description.AppendText(text);
            services_description.SelectionFont = services_description.Font; // Reset to default font
        }

        private void btnOther_Click(object sender, EventArgs e)
        {
            Nav(new Notification(), content);
        }
    }
}
