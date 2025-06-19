using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programming_Assignment__
{
    public partial class WelcomePage : Form
    {

        public WelcomePage()
        {

            InitializeComponent();

            pictureBox4.TabStop = false;
        }

        private void WelcomePage_Load(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click_1(object sender, EventArgs e)
        {
            LogInPage logInPage = new LogInPage();
            logInPage.Show();
            this.Hide();
        }

        private void guna2GradientButton2_Click_1(object sender, EventArgs e)
        {
            SignUpPage signup = new SignUpPage();
            signup.Show();
            this.Hide();
        }



        private void linkLabel3_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string locationUrl = "https://www.google.com/maps?q=KickBlast+Dojo+Negombo+Fitness+Gym";

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = locationUrl,
                UseShellExecute = true
            });
        }



        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string mailto = "mailto:KickBlastJudo@gmail.com";



            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = mailto,
                UseShellExecute = true
            });
        }
    }
}
