using Programming_Assignment__;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programming_Assignment_1
{
    public partial class PaymentDetails : Form
    {
        private string loggedInUsername;

        public PaymentDetails()
        {

            InitializeComponent();
            loggedInUsername = HomePage.CurrentLoggedInUser;
            LoadPaymentDetails();
        }

        private void LoadPaymentDetails()
        {
            if (string.IsNullOrEmpty(loggedInUsername))
            {

                MessageBox.Show("No user logged in. Please login first.");
                return;
            }

            SqlConnection con = new SqlConnection("Data Source=LAPTOP-UJ535S4S\\SQLEXPRESS;Initial Catalog=KICK;Integrated Security=True;TrustServerCertificate=True");

            try
            {
                con.Open();

                string query = @"SELECT pd.PaymentID, pd.Username, pd.FullName, pd.TrainingPlan, 
                                pd.NoOfCompetitions, pd.PrivateCoachingWeek1, pd.PrivateCoachingWeek2, 
                                pd.PrivateCoachingWeek3, pd.PrivateCoachingWeek4, pd.TrainingPlanFee, 
                                pd.CompetitionFee, pd.PrivateCoachingFee, pd.TotalAmount, pd.AthleteID
                                FROM PaymentDetails pd 
                                WHERE pd.Username = @Username";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Username", loggedInUsername);



                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {



                    lblFullname.Text = reader["FullName"].ToString();
                    lblTrainingplan.Text = reader["TrainingPlan"].ToString();
                    lblCompetitions.Text = reader["NoOfCompetitions"].ToString();

                    lblTp.Text = $"Rs. {Convert.ToDecimal(reader["TrainingPlanFee"]):F2}";
                    lblCef.Text = $"Rs. {Convert.ToDecimal(reader["CompetitionFee"]):F2}";



                    week1.Text = $"Rs. {Convert.ToDecimal(reader["PrivateCoachingWeek1"]):F2}";
                    week2.Text = $"Rs. {Convert.ToDecimal(reader["PrivateCoachingWeek2"]):F2}";
                    week3.Text = $"Rs. {Convert.ToDecimal(reader["PrivateCoachingWeek3"]):F2}";
                    week4.Text = $"Rs. {Convert.ToDecimal(reader["PrivateCoachingWeek4"]):F2}";

                    decimal totalPrivateCoaching = Convert.ToDecimal(reader["PrivateCoachingFee"]);
                    decimal totalAmount = Convert.ToDecimal(reader["TotalAmount"]);

                    label25.Text = $"Rs. {totalPrivateCoaching:F2}";

                    label34.Text = $"Rs. {Convert.ToDecimal(reader["TrainingPlanFee"]):F2}";
                    label35.Text = $"Rs. {Convert.ToDecimal(reader["CompetitionFee"]):F2}";
                    label36.Text = $"Rs. {totalPrivateCoaching:F2}";
                    label37.Text = $"Rs. {totalAmount:F2}";
                }
                else

                {
                    MessageBox.Show("No payment details found for the current user.");
                   
                }

                reader.Close();
            }
            catch (Exception ex)
            {


                MessageBox.Show($"Error loading payment details: {ex.Message}");
            }
            finally
            {
                con.Close();
            }


        }

        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.Show();


            this.Hide();
        }
    }
}