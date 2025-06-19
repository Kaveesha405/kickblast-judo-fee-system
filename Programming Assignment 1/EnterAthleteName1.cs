using Microsoft.Data.SqlClient;
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
    public partial class EnterAthleteName1 : Form
    {
        public EnterAthleteName1()
        {
            InitializeComponent();
        }



        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Hide();
        }

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {
            string athleteUsername = txtAthleteUsername.Text.Trim();

            if (string.IsNullOrEmpty(athleteUsername))
            {
                MessageBox.Show("Please enter an athlete username.", "Input Required",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAthleteUsername.Focus();
                return;
            }

            CheckAthleteExists(athleteUsername);
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {

        }

        private void CheckAthleteExists(string athleteUsername)
        {
            string connectionString = "Data Source=LAPTOP-UJ535S4S\\SQLEXPRESS;Initial Catalog=KICK;Integrated Security=True;TrustServerCertificate=True";
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM Athletes WHERE Username = @Username";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", athleteUsername);
                        int count = (int)cmd.ExecuteScalar();
                        if (count > 0)
                        {
                            FeeCalculator feeCalculator = new FeeCalculator(athleteUsername);
                            feeCalculator.Show();
                            this.Hide();
                        }


                        else
                        {
                            MessageBox.Show("The user '" + athleteUsername + "' does not exist.",
                                          "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtAthleteUsername.Clear();
                            txtAthleteUsername.Focus();
                        }


                    }
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show("Error checking athlete: " + ex.Message,
                               "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
