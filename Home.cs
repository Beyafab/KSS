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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            
        }

        private void servicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Services services = new Services();
            Nav(services, content);
        }

        private void aboutAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Aboutas aboutas = new Aboutas();
            Nav(aboutas, content);
        }
        public void Nav(Form form, Panel panel)
        {
            form.TopLevel = false;
            panel.Controls.Clear();
            form.FormBorderStyle = FormBorderStyle.None; // Remove form borders for better fit
            form.Dock = DockStyle.Fill; // Dock the form to fill the entire panel
            panel.Controls.Add(form);
            form.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        { 
            // HTML content for the blog-like description
            string htmlContent = @"
        <html>
        <head>
            <style>
                body {
                    font-family: Arial, sans-serif;
                    line-height: 1.6;
                    margin: 20px;
                }
                h1 {
                    color: #2c3e50;
                    font-size: 28px;
                    margin-bottom: 20px;
                }
                h2 {
                    color: #34495e;
                    font-size: 24px;
                    margin-top: 30px;
                    margin-bottom: 15px;
                }
                p {
                    color: #333;
                    font-size: 16px;
                    margin-bottom: 15px;
                }
                ul {
                    margin-bottom: 20px;
                }
                li {
                    margin-bottom: 10px;
                }
                .highlight {
                    background-color: #f9f9f9;
                    padding: 10px;
                    border-left: 4px solid #3498db;
                    margin-bottom: 20px;
                }
            </style>
        </head>
        <body>
            <h1>Project Description: Kebele Schedule System</h1>
            <p>The <strong>Kebele Schedule System</strong> is an innovative digital platform designed to streamline and modernize the scheduling, management, and delivery of administrative services at the Kebele level in Ethiopia. Kebeles, the smallest administrative units in the country, play a critical role in providing essential services to citizens, including issuing identification documents, land certificates, and other community-based services. However, the current manual and paper-based systems often lead to inefficiencies, long wait times, and challenges in resource management.</p>
            <p>This project aims to address these issues by developing a centralized, user-friendly, and automated scheduling system that enhances service delivery, improves transparency, and ensures equitable access to Kebele services. The system will allow citizens to book appointments, track service progress, and receive notifications, while enabling Kebele staff to manage workloads, allocate resources, and generate reports efficiently.</p>

            <h2>Key Features of the Kebele Schedule System</h2>
            <ul>
                <li><strong>Online Appointment Booking</strong>: Citizens can schedule appointments for specific services (e.g., ID issuance, land certification) through a web or mobile interface, reducing long queues and wait times.</li>
                <li><strong>Real-Time Scheduling</strong>: Kebele staff can view and manage appointments in real time, ensuring optimal use of resources and minimizing service delays.</li>
                <li><strong>Automated Notifications</strong>: Users receive SMS or email reminders about their appointments, required documents, and service updates.</li>
                <li><strong>Service Tracking</strong>: Citizens can track the status of their requests or applications, enhancing transparency and trust in the system.</li>
                <li><strong>Resource Management</strong>: The system provides tools for Kebele administrators to allocate staff, manage workloads, and monitor service delivery performance.</li>
                <li><strong>Reporting and Analytics</strong>: Generate detailed reports on service delivery metrics, appointment trends, and resource utilization to support data-driven decision-making.</li>
                <li><strong>Accessibility and Inclusivity</strong>: The system is designed to be accessible to all citizens, including those with limited digital literacy or internet access, through user-friendly interfaces and support for multiple languages.</li>
                <li><strong>Integration with Existing Systems</strong>: The platform can integrate with other government databases and systems to ensure seamless data sharing and reduce redundancy.</li>
            </ul>

            <h2>Benefits of the Kebele Schedule System</h2>
            <div class='highlight'>
                <ul>
                    <li><strong>Improved Efficiency</strong>: Reduces administrative bottlenecks and speeds up service delivery.</li>
                    <li><strong>Enhanced Citizen Experience</strong>: Provides a more convenient and transparent process for accessing Kebele services.</li>
                    <li><strong>Resource Optimization</strong>: Helps Kebele staff manage their time and resources more effectively.</li>
                    <li><strong>Data-Driven Insights</strong>: Enables Kebele administrators to identify trends, address challenges, and improve service quality.</li>
                    <li><strong>Transparency and Accountability</strong>: Builds trust between citizens and local government by providing clear and accessible information.</li>
                </ul>
            </div>

            <h2>Target Users</h2>
            <ul>
                <li><strong>Citizens</strong>: Individuals seeking services from their local Kebele.</li>
                <li><strong>Kebele Staff</strong>: Administrative personnel responsible for managing and delivering services.</li>
                <li><strong>Local Government Authorities</strong>: Officials overseeing Kebele operations and service delivery.</li>
            </ul>

            <h2>Technology Stack</h2>
            <ul>
                <li><strong>Frontend</strong>: Responsive web and mobile interfaces using modern frameworks (e.g., React, Angular, or Flutter).</li>
                <li><strong>Backend</strong>: Scalable server-side architecture (e.g., Node.js, Django, or Spring Boot).</li>
                <li><strong>Database</strong>: Secure and reliable database system (e.g., PostgreSQL, MySQL, or MongoDB).</li>
                <li><strong>Integration</strong>: APIs for connecting with existing government systems and SMS/email notification services.</li>
                <li><strong>Security</strong>: Robust data encryption and user authentication mechanisms to protect sensitive information.</li>
            </ul>

            <p>The Kebele Schedule System is a transformative project that leverages technology to improve governance and service delivery at the grassroots level. By digitizing and automating scheduling processes, this system has the potential to significantly enhance the efficiency, transparency, and accessibility of Kebele services, ultimately benefiting millions of citizens across Ethiopia.</p>
        </body>
        </html>";

            // Display the HTML content in the WebBrowser control
            webBrowser1.DocumentText = htmlContent;

            // Maximize the form
            this.WindowState = FormWindowState.Maximized;
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HomeContent homeContent = new HomeContent();
            Nav(homeContent, content);


        }

        private void contactUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContactUs contactUs = new ContactUs();
            Nav(contactUs, content);
        }
    }
}
