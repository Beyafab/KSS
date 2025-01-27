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
    public partial class Aboutas : Form
    {
        public Aboutas()
        {
            InitializeComponent();
        }

        private void Aboutas_Load(object sender, EventArgs e)
        {
            string htmlContent = @"
    <!DOCTYPE html>
    <html>
    <head>
        <style>
            body {
                font-family: Arial, sans-serif;
                margin: 0;
                padding: 0;
                background-color: #1a1a1a; /* Light black background */
                color: #e0e0e0; /* Light gray text for contrast */
            }
            .profile {
                padding: 20px;
                margin: 20px;
                border-radius: 10px;
                box-shadow: 0 4px 8px rgba(0, 0, 0, 0.3);
                background: linear-gradient(135deg, #2c3e50, #34495e); /* Dark gradient for profiles */
                transition: transform 0.3s ease, box-shadow 0.3s ease;
            }
            .profile:hover {
                transform: translateY(-5px);
                box-shadow: 0 8px 16px rgba(0, 0, 0, 0.4);
            }
            h2 {
                margin-top: 0;
                color: #3498db; /* Blue accent for names */
            }
            p {
                font-size: 16px;
                line-height: 1.6;
            }
            .skills {
                font-style: italic;
                color: #bdc3c7; /* Light gray for skills */
            }
        </style>
    </head>
    <body>
        <div class='profile'>
            <h2>Enyew Yirga</h2>
            <p>Enyew Yirga is a passionate software developer and a dedicated student at Addis Ababa University. With a strong foundation in programming languages like Python, Java, and JavaScript, Enyew has contributed to several open-source projects and is known for his problem-solving skills. He is also an active member of the university's tech club, where he mentors junior developers.</p>
            <p class='skills'>Skills: Python, Java, JavaScript, Open-Source Development</p>
        </div>
        <div class='profile'>
            <h2>Mariamawit Getachew</h2>
            <p>Mariamawit Getachew is a talented full-stack developer and a top-performing student at Addis Ababa University. She specializes in building scalable web applications using technologies like React, Node.js, and MongoDB. Mariamawit is also a tech enthusiast who frequently participates in hackathons and has won several awards for her innovative projects.</p>
            <p class='skills'>Skills: React, Node.js, MongoDB, Full-Stack Development</p>
        </div>
        <div class='profile'>
            <h2>Setota Girma</h2>
            <p>Setota Girma is a creative UI/UX designer and a skilled front-end developer at Addis Ababa University. She has a keen eye for design and specializes in creating user-friendly interfaces using tools like Figma, Adobe XD, and CSS frameworks like Bootstrap. Setota is also a team player who collaborates effectively with developers to bring designs to life.</p>
            <p class='skills'>Skills: UI/UX Design, Figma, Adobe XD, Bootstrap</p>
        </div>
        <div class='profile'>
            <h2>Beyene Bekele</h2>
            <p>Beyene Bekele is a data science enthusiast and a dedicated student at Addis Ababa University. With expertise in machine learning, data analysis, and visualization tools like Python (Pandas, NumPy, Matplotlib), Beyene has worked on several data-driven projects that have had a significant impact. He is also a member of the university's data science club.</p>
            <p class='skills'>Skills: Machine Learning, Data Analysis, Python, Data Visualization</p>
        </div>
        <div class='profile'>
            <h2>Ezana Befekadu</h2>
            <p>Ezana Befekadu is a mobile app developer and a passionate student at Addis Ababa University. He specializes in building cross-platform mobile applications using Flutter and Dart. Ezana is also an active contributor to the developer community, sharing his knowledge through blogs and workshops. His apps have been praised for their performance and user experience.</p>
            <p class='skills'>Skills: Flutter, Dart, Mobile App Development, Cross-Platform Development</p>
        </div>
    </body>
    </html>";

            webBrowser1.DocumentText = htmlContent;
        }
    }
}
