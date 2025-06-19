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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Programming_Assignment__
{
    public partial class FeeCalculator : Form
    {

        private string athleteUsername;

        public FeeCalculator(string username)
        {

            InitializeComponent();
            this.athleteUsername = username;
            LoadAthleteData();

            panel1.Visible = false;

        }


        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void LoadAthleteData()
        {
            string connectionString = "Data Source=LAPTOP-UJ535S4S\\SQLEXPRESS;Initial Catalog=KICK;Integrated Security=True;TrustServerCertificate=True";
            try
            {


                using (SqlConnection con = new SqlConnection(connectionString))
                {


                    con.Open();
                    string query = @"SELECT FullName, Weight, TrainingPlan, NoOfCompetitionsThisMonth, 
                            PrivateCoachingWeek1, PrivateCoachingWeek2, PrivateCoachingWeek3, PrivateCoachingWeek4 
                            FROM Athletes WHERE Username = @Username";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", athleteUsername);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblfullname1.Text = reader["FullName"].ToString();
                                lblweight1.Text = reader["Weight"].ToString();
                                lblplan1.Text = reader["TrainingPlan"].ToString();
                                lblcompetitions1.Text = reader["NoOfCompetitionsThisMonth"].ToString();
                                lblweek1.Text = reader["PrivateCoachingWeek1"].ToString();
                                lblweek2.Text = reader["PrivateCoachingWeek2"].ToString();
                                lblweek3.Text = reader["PrivateCoachingWeek3"].ToString();
                                lblweek4.Text = reader["PrivateCoachingWeek4"].ToString();
                            }
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading athlete data: " + ex.Message,
                               "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public FeeCalculator()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Hide();
        }


        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            try
            {
                panel1.Visible = true;

                lblFullname.Text = lblfullname1.Text;
                lblTrainingplan.Text = lblplan1.Text;
                lblCompetitions.Text = lblcompetitions1.Text;



                week1.Text = lblweek1.Text + " hrs";
                week2.Text = lblweek2.Text + " hrs";
                week3.Text = lblweek3.Text + " hrs";
                week4.Text = lblweek4.Text + " hrs";

                var feeBreakdown = CalculateDetailedCost();

                string trainingPlan = lblplan1.Text.Trim();
                decimal weeklyRate = GetWeeklyTrainingPlanRate(trainingPlan);


                lblTp.Text = "";

                label34.Text = $"Rs.{feeBreakdown.TrainingPlanFee:F2}";

                int competitions = int.TryParse(lblcompetitions1.Text, out int comp) ? comp : 0;

                if (competitions > 0 && feeBreakdown.CompetitionFee > 0)

                {
                   
                    lblCef.Text = $"{competitions} Competition(s) (Rs.220.00 each) = Rs.{feeBreakdown.CompetitionFee:F2}";
                    label35.Text = $"Rs.{feeBreakdown.CompetitionFee:F2}";
                }
                else

                {

                    lblCef.Text = "No Competitions Entered = Rs.0.00";
                    label35.Text = "Rs.0.00";
                }

                int totalCoachingHours = GetTotalPrivateCoachingHours();
                label25.Text = $"Total Coaching: {totalCoachingHours} hrs x Rs.90.50";

                label36.Text = $"Rs.{feeBreakdown.TotalPrivateCoachingFee:F2}";


                label37.Text = $"Rs.{feeBreakdown.TotalCost:F2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating fees: " + ex.Message,
                               "Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }



        private decimal GetWeeklyTrainingPlanRate(string trainingPlan)
        {
            switch (trainingPlan.Trim().ToLower())
            {
                case "beginner":
                    return 250.00m;
                case "intermediate":

                    return 300.00m;
                case "elite":
                    return 350.00m;
                default:
                    return 0;
            }


        }


        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {

        }

        private int GetTotalPrivateCoachingHours()
        {


            int week1 = int.TryParse(lblweek1.Text, out int w1) ? w1 : 0;
            int week2 = int.TryParse(lblweek2.Text, out int w2) ? w2 : 0;
            int week3 = int.TryParse(lblweek3.Text, out int w3) ? w3 : 0;
            int week4 = int.TryParse(lblweek4.Text, out int w4) ? w4 : 0;
            return week1 + week2 + week3 + week4;
        }



        private struct FeeBreakdown
        {


            public decimal TrainingPlanFee;
            public decimal CompetitionFee;
            public decimal Week1Cost;
            public decimal Week2Cost;
            public decimal Week3Cost;
            public decimal Week4Cost;
            public decimal TotalPrivateCoachingFee;
            public decimal TotalCost;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private FeeBreakdown CalculateDetailedCost()
        {
            
            FeeBreakdown breakdown = new FeeBreakdown();

            string trainingPlan = lblplan1.Text.Trim().ToLower();

            switch (trainingPlan)
            {

                case "beginner":
                    breakdown.TrainingPlanFee = 250.00m * 4;
                    break;
                case "intermediate":
                    breakdown.TrainingPlanFee = 300.00m * 4;
                    break;
                case "elite":
                    breakdown.TrainingPlanFee = 350.00m * 4;
                    break;
                default:
                    breakdown.TrainingPlanFee = 0;
                    break;
            }




            if (int.TryParse(lblcompetitions1.Text, out int competitions))
            {
                if (trainingPlan == "intermediate" || trainingPlan == "elite")
                {
                    breakdown.CompetitionFee = competitions * 220.00m;
                }
            }


            int week1Hours = 0, week2Hours = 0, week3Hours = 0, week4Hours = 0;

            if (int.TryParse(lblweek1.Text, out week1Hours))
            {
                breakdown.Week1Cost = week1Hours * 90.50m;
            }

            if (int.TryParse(lblweek2.Text, out week2Hours))
            {
                breakdown.Week2Cost = week2Hours * 90.50m;
            }

            if (int.TryParse(lblweek3.Text, out week3Hours))
            {
                breakdown.Week3Cost = week3Hours * 90.50m;
            }

            if (int.TryParse(lblweek4.Text, out week4Hours))
            {
                breakdown.Week4Cost = week4Hours * 90.50m;
            }

            breakdown.TotalPrivateCoachingFee = breakdown.Week1Cost + breakdown.Week2Cost +
                                               breakdown.Week3Cost + breakdown.Week4Cost;

            int totalWeeklyHours = (week1Hours + week2Hours + week3Hours + week4Hours);
            if (totalWeeklyHours > 20)
            {
                MessageBox.Show("Warning: Athletes can receive a maximum of 5 hours private coaching per week.",
                               "Private Coaching Limit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            breakdown.TotalCost = breakdown.TrainingPlanFee + breakdown.CompetitionFee + breakdown.TotalPrivateCoachingFee;

            return breakdown;
        }



        private decimal CalculateTotalCost()
        {
            return CalculateDetailedCost().TotalCost;
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!panel1.Visible)
                {
                    MessageBox.Show("Please calculate fees first before sending to athlete.",
                                   "Calculation Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var feeBreakdown = CalculateDetailedCost();

                SavePaymentDetails(feeBreakdown);

                MessageBox.Show("Payment details have been successfully sent to the athlete!",
                               "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending payment details: " + ex.Message,
                               "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SavePaymentDetails(FeeBreakdown feeBreakdown)
        {
            string connectionString = "Data Source=LAPTOP-UJ535S4S\\SQLEXPRESS;Initial Catalog=KICK;Integrated Security=True;TrustServerCertificate=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                int athleteID = 0;
                string getAthleteIDQuery = "SELECT AthleteID FROM Athletes WHERE Username = @Username";
                using (SqlCommand getIDCmd = new SqlCommand(getAthleteIDQuery, con))
                {
                    getIDCmd.Parameters.AddWithValue("@Username", athleteUsername);
                    object result = getIDCmd.ExecuteScalar();
                    if (result != null)
                    {
                        athleteID = Convert.ToInt32(result);
                    }
                }

                string insertQuery = @"INSERT INTO PaymentDetails 
                   (Username, FullName, TrainingPlan, NoOfCompetitions, 
                  PrivateCoachingWeek1, PrivateCoachingWeek2, PrivateCoachingWeek3, PrivateCoachingWeek4,
                  TrainingPlanFee, CompetitionFee, PrivateCoachingFee, TotalAmount, AthleteID)
                 VALUES 
                 (@Username, @FullName, @TrainingPlan, @NoOfCompetitions,
                 @PrivateCoachingWeek1, @PrivateCoachingWeek2, @PrivateCoachingWeek3, @PrivateCoachingWeek4,
                 @TrainingPlanFee, @CompetitionFee, @PrivateCoachingFee, @TotalAmount, @AthleteID)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@Username", athleteUsername);
                    cmd.Parameters.AddWithValue("@FullName", lblfullname1.Text);
                    cmd.Parameters.AddWithValue("@TrainingPlan", lblplan1.Text);
                    cmd.Parameters.AddWithValue("@NoOfCompetitions", int.Parse(lblcompetitions1.Text));

                    cmd.Parameters.AddWithValue("@PrivateCoachingWeek1", int.Parse(lblweek1.Text));
                    cmd.Parameters.AddWithValue("@PrivateCoachingWeek2", int.Parse(lblweek2.Text));
                    cmd.Parameters.AddWithValue("@PrivateCoachingWeek3", int.Parse(lblweek3.Text));
                    cmd.Parameters.AddWithValue("@PrivateCoachingWeek4", int.Parse(lblweek4.Text));

                    cmd.Parameters.AddWithValue("@TrainingPlanFee", feeBreakdown.TrainingPlanFee);
                    cmd.Parameters.AddWithValue("@CompetitionFee", feeBreakdown.CompetitionFee);
                    cmd.Parameters.AddWithValue("@PrivateCoachingFee", feeBreakdown.TotalPrivateCoachingFee);
                    cmd.Parameters.AddWithValue("@TotalAmount", feeBreakdown.TotalCost);

                    cmd.Parameters.AddWithValue("@AthleteID", athleteID);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}