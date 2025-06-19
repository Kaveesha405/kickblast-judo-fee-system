using Programming_Assignment_1;
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
    public partial class Admin : Form
    {

        private string loggedInUsername;


        public static string CurrentLoggedInUser { get; set; }

        public Admin(string username)
        {
            InitializeComponent();
            loggedInUsername = username;
            CurrentLoggedInUser = username;
            lblWelcome.Text = $"Welcome, {username}";
        }


        public Admin()
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(CurrentLoggedInUser))
            {
                loggedInUsername = CurrentLoggedInUser;
                lblWelcome.Text = $"Welcome, {CurrentLoggedInUser}";
            }
        }



        private void guna2GradientTileButton4_Click(object sender, EventArgs e)
        {
            EnterAthleteName1 enterAthleteName1 = new EnterAthleteName1();
            enterAthleteName1.Show();
            this.Hide();
        }


        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            LogInPage logInPage = new LogInPage();
            logInPage.Show();
            this.Hide();

        }

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {

        }



        private void guna2GradientTileButton3_Click(object sender, EventArgs e)
        {
            AddAthlete addAthlete = new AddAthlete();
            addAthlete.Show();
            this.Hide();
        }

        private void guna2GradientTileButton2_Click(object sender, EventArgs e)
        {
            EnterAthleteName2 enterAthleteName2 = new EnterAthleteName2();
            enterAthleteName2.Show();
            this.Hide();
        }



        private void Admin_Load(object sender, EventArgs e)
        {

        }
    }
}
