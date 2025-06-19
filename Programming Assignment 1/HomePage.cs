using Microsoft.Data.SqlClient;
using Programming_Assignment_1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programming_Assignment__
{
    public partial class HomePage : Form
    {
        private string loggedInUsername;

        public static string CurrentLoggedInUser { get; set; }

        public HomePage(string username)
        {
            InitializeComponent();
            loggedInUsername = username;
            CurrentLoggedInUser = username;
            lblWelcome.Text = $"Welcome, {username}";
            LoadAthleteData();

        }


        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }
        public HomePage()
        {
            InitializeComponent();



            if (!string.IsNullOrEmpty(CurrentLoggedInUser))
            {
                loggedInUsername = CurrentLoggedInUser;

                lblWelcome.Text = $"Welcome, {CurrentLoggedInUser}";
                LoadAthleteData();
            }
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void LoadAthleteData()

        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-UJ535S4S\\SQLEXPRESS;Initial Catalog=KICK;Integrated Security=True;TrustServerCertificate=True");

            try
            {

                con.Open();
                string query = "SELECT FullName, Email, DateOfBirth, PhoneNumber, Weight, TrainingPlan, CompetitionWeightCategory, NoOfCompetitionsThisMonth FROM Athletes WHERE Username=@Username";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Username", loggedInUsername);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    lblFullName.Text = $"Full Name:  {reader["FullName"]}";
                    lblEmail.Text = $"Email:  {reader["Email"]}";
                    lblDateOfBirth.Text = $"Date Of Birth:  {reader["DateOfBirth"]}";
                    lblPhoneNumber.Text = $"Phone Number:  {reader["PhoneNumber"]}";
                    lblWeight.Text = $"Weight:  {reader["Weight"]}";
                    lblTrainingPlan.Text = $"Training Plan:  {reader["TrainingPlan"]}";
                    lblCompetitionWeightCategory.Text = $"Competition Weight Category:  {reader["CompetitionWeightCategory"]}";
                    lblNoOfCompetitions.Text = $"No Of Competitions entered this month:  {reader["NoOfCompetitionsThisMonth"]}";
                }

                reader.Close();
            }
            catch (Exception ex)

            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
            finally
            {

                con.Close();
            }
        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }

        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            CurrentLoggedInUser = null;

            LogInPage logInPage = new LogInPage();
            logInPage.Show();
            this.Hide();
        }



        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void guna2GradientTileButton6_Click(object sender, EventArgs e)
        {
            ChatForm chatForm = new ChatForm();
            chatForm.Show();
            this.Hide();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {
            PaymentDetails paymentDetails = new PaymentDetails();
            paymentDetails.Show();
            this.Hide();
        }
    }
}