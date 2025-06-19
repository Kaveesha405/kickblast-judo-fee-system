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
    public partial class Add_Delete : Form
    {

        private string connectionString = @"Data Source=LAPTOP-UJ535S4S\SQLEXPRESS;Initial Catalog=KICK;Integrated Security=True;TrustServerCertificate=True;";
        private string currentAthleteUsername;

        public Add_Delete()
        {
            
            InitializeComponent();
            PopulateComboBoxes();
        }

        public Add_Delete(string athleteUsername)
        {

            InitializeComponent();
            currentAthleteUsername = athleteUsername;
            PopulateComboBoxes();
            LoadAthleteData(athleteUsername);
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }


        private void PopulateComboBoxes()
        {

            try
            {
                TrainingPlanComboBox.Items.Clear();
                TrainingPlanComboBox.Items.AddRange(new string[] { "Beginner", "Intermediate", "Elite" });

                WeightCategoryComboBox.Items.Clear();
                WeightCategoryComboBox.Items.AddRange(new string[] {
                    "Fly weight", "Light weight", "Middle weight", "Heavy weight", "Light heavy"
                });

                string[] weekOptions = { "0", "1", "2", "3", "4", "5" };

                PrivateCoachingWeek1ComboBox.Items.Clear();
                PrivateCoachingWeek1ComboBox.Items.AddRange(weekOptions);


                PrivateCoachingWeek2ComboBox.Items.Clear();
                PrivateCoachingWeek2ComboBox.Items.AddRange(weekOptions);

                PrivateCoachingWeek3ComboBox.Items.Clear();
                PrivateCoachingWeek3ComboBox.Items.AddRange(weekOptions);


                PrivateCoachingWeek4ComboBox.Items.Clear();
                PrivateCoachingWeek4ComboBox.Items.AddRange(weekOptions);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error populating combo boxes: {ex.Message}",
                              "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
        private void LoadAthleteData(string athleteUsername)
        {
            if (string.IsNullOrEmpty(athleteUsername))
            {
                MessageBox.Show("No athlete username provided.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }


            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT Username, FullName, Email, PhoneNumber, DateOfBirth, Weight, 
                                   CompetitionWeightCategory, TrainingPlan, PrivateCoachingWeek1, PrivateCoachingWeek2, 
                                   PrivateCoachingWeek3, PrivateCoachingWeek4, NoOfCompetitionsThisMonth 
                                   FROM dbo.Athletes WHERE Username = @Username";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", athleteUsername);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                FullNameTextBox.Text = reader["FullName"]?.ToString() ?? "";
                                EmailTextBox.Text = reader["Email"]?.ToString() ?? "";
                                PhoneNumberTextBox.Text = reader["PhoneNumber"]?.ToString() ?? "";
                                WeightTextBox.Text = reader["Weight"]?.ToString() ?? "";
                                CompetitionsTextBox.Text = reader["NoOfCompetitionsThisMonth"]?.ToString() ?? "";

                                if (reader["DateOfBirth"] != DBNull.Value)
                                {
                                    DateOfBirthDateTimePicker.Value = Convert.ToDateTime(reader["DateOfBirth"]);
                                }


                                else
                                {
                                    DateOfBirthDateTimePicker.Value = DateTime.Now;
                                }

                                string trainingPlan = reader["TrainingPlan"]?.ToString();
                                if (!string.IsNullOrEmpty(trainingPlan) && TrainingPlanComboBox.Items.Contains(trainingPlan))
                                {

                                    TrainingPlanComboBox.SelectedItem = trainingPlan;
                                }
                                else
                                {
                                    TrainingPlanComboBox.SelectedIndex = -1;
                                }


                                string weightCategory = reader["CompetitionWeightCategory"]?.ToString();
                                if (!string.IsNullOrEmpty(weightCategory) && WeightCategoryComboBox.Items.Contains(weightCategory))
                                {
                                    WeightCategoryComboBox.SelectedItem = weightCategory;
                                }
                                else
                                {
                                    WeightCategoryComboBox.SelectedIndex = -1;
                                }

                                SetPrivateCoachingWeek(PrivateCoachingWeek1ComboBox, reader["PrivateCoachingWeek1"]);
                                SetPrivateCoachingWeek(PrivateCoachingWeek2ComboBox, reader["PrivateCoachingWeek2"]);
                                SetPrivateCoachingWeek(PrivateCoachingWeek3ComboBox, reader["PrivateCoachingWeek3"]);
                                SetPrivateCoachingWeek(PrivateCoachingWeek4ComboBox, reader["PrivateCoachingWeek4"]);
                            }


                            else
                            {
                                MessageBox.Show($"No athlete found with username: {athleteUsername}",
                                              "Athlete Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.Close();
                            }

                        }
                    }

                }
            }


            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database connection error: {sqlEx.Message}",
                              "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading athlete data: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void SetPrivateCoachingWeek(ComboBox comboBox, object value)
        {
            try
            {
                string weekValue = value?.ToString();
                if (!string.IsNullOrEmpty(weekValue) && comboBox.Items.Contains(weekValue))
                {
                    comboBox.SelectedItem = weekValue;
                }
                else
                {
                    comboBox.SelectedIndex = -1;
                }
            }

            catch (Exception ex)
            {
                comboBox.SelectedIndex = -1;
            }


        }

        private void Add_Delete_Load(object sender, EventArgs e)
        {
            this.Text = !string.IsNullOrEmpty(currentAthleteUsername)
                       ? $"Edit Athlete - {currentAthleteUsername}"
                       : "Add New Athlete";
        }



        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Admin admin = new Admin();
                admin.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error navigating to Admin form: {ex.Message}",
                              "Navigation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {

        }


        private void guna2GradientTileButton3_Click(object sender, EventArgs e)
        
        {
            try
            {
                Admin admin = new Admin();
                admin.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error navigating to Admin form: {ex.Message}",
                              "Navigation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {
            UpdateAthleteData();
        }

        private void UpdateAthleteData()
        {
            if (string.IsNullOrEmpty(currentAthleteUsername))
            {
                MessageBox.Show("No athlete selected for update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidateInputFields())
            {
                return;
            }





            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {


                    connection.Open();

                    string updateQuery = @"UPDATE dbo.Athletes SET 
                                         FullName = @FullName,
                                         Email = @Email,
                                         PhoneNumber = @PhoneNumber,
                                         DateOfBirth = @DateOfBirth,
                                         Weight = @Weight,
                                         CompetitionWeightCategory = @CompetitionWeightCategory,
                                         TrainingPlan = @TrainingPlan,
                                         PrivateCoachingWeek1 = @PrivateCoachingWeek1,
                                         PrivateCoachingWeek2 = @PrivateCoachingWeek2,
                                         PrivateCoachingWeek3 = @PrivateCoachingWeek3,
                                         PrivateCoachingWeek4 = @PrivateCoachingWeek4,
                                         NoOfCompetitionsThisMonth = @NoOfCompetitionsThisMonth
                                         WHERE Username = @Username";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Username", currentAthleteUsername);
                        command.Parameters.AddWithValue("@FullName", FullNameTextBox.Text.Trim());
                        command.Parameters.AddWithValue("@Email", EmailTextBox.Text.Trim());
                        command.Parameters.AddWithValue("@PhoneNumber", PhoneNumberTextBox.Text.Trim());
                        command.Parameters.AddWithValue("@DateOfBirth", DateOfBirthDateTimePicker.Value.Date);

                        if (decimal.TryParse(WeightTextBox.Text.Trim(), out decimal weight))
                        {

                            command.Parameters.AddWithValue("@Weight", weight);
                        }
                        else

                        {
                            command.Parameters.AddWithValue("@Weight", DBNull.Value);
                        }




                        command.Parameters.AddWithValue("@CompetitionWeightCategory",
                            WeightCategoryComboBox.SelectedItem?.ToString() ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@TrainingPlan",
                            TrainingPlanComboBox.SelectedItem?.ToString() ?? (object)DBNull.Value);

                        command.Parameters.AddWithValue("@PrivateCoachingWeek1",
                            PrivateCoachingWeek1ComboBox.SelectedItem?.ToString() ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@PrivateCoachingWeek2",
                            PrivateCoachingWeek2ComboBox.SelectedItem?.ToString() ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@PrivateCoachingWeek3",
                            PrivateCoachingWeek3ComboBox.SelectedItem?.ToString() ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@PrivateCoachingWeek4",
                            PrivateCoachingWeek4ComboBox.SelectedItem?.ToString() ?? (object)DBNull.Value);

                        if (int.TryParse(CompetitionsTextBox.Text.Trim(), out int competitions))
                        {
                            command.Parameters.AddWithValue("@NoOfCompetitionsThisMonth", competitions);
                        }

                        else
                        {
                            command.Parameters.AddWithValue("@NoOfCompetitionsThisMonth", DBNull.Value);
                        }



                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Athlete '{currentAthleteUsername}' has been successfully updated!",
                                          "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            RefreshAthleteData();
                        }
                        else
                        {

                            MessageBox.Show("No records were updated. Please check if the athlete exists.",
                                          "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                }

            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error during update: {sqlEx.Message}",
                              "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error updating athlete data: {ex.Message}",
                              "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {



        }


        private bool ValidateInputFields()
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrWhiteSpace(FullNameTextBox.Text))


                errors.Add("Full Name is required.");

            if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
                errors.Add("Email is required.");
            else if (!IsValidEmail(EmailTextBox.Text.Trim()))
                errors.Add("Please enter a valid email address.");




            if (string.IsNullOrWhiteSpace(PhoneNumberTextBox.Text))
                errors.Add("Phone Number is required.");

            if (!string.IsNullOrWhiteSpace(WeightTextBox.Text))
            {
                if (!decimal.TryParse(WeightTextBox.Text.Trim(), out decimal weight) || weight <= 0)
               
                    errors.Add("Weight must be a valid positive number.");
            }

            if (!string.IsNullOrWhiteSpace(CompetitionsTextBox.Text))
            {
                if (!int.TryParse(CompetitionsTextBox.Text.Trim(), out int competitions) || competitions < 0)
                    errors.Add("Number of Competitions must be a valid non-negative number.");
            }


            if (errors.Count > 0)


            {
                string errorMessage = "Please fix the following errors:\n\n" + string.Join("\n", errors);
                MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }


        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }




        public string GetCurrentAthleteUsername()
        {
            return currentAthleteUsername;
        }


        public void RefreshAthleteData()
        {
            if (!string.IsNullOrEmpty(currentAthleteUsername))
            {
                LoadAthleteData(currentAthleteUsername);
            }

        }


        private void DeleteAthleteData()
        {
            if (string.IsNullOrEmpty(currentAthleteUsername))
            {
                MessageBox.Show("No athlete selected for deletion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete athlete '{currentAthleteUsername}'?\n\nThis action cannot be undone.",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result != DialogResult.Yes)
            {
                return;
            }



            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string deleteQuery = "DELETE FROM dbo.Athletes WHERE Username = @Username";


                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Username", currentAthleteUsername);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Athlete '{currentAthleteUsername}' has been successfully deleted!",
                                          "Delete Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Admin admin = new Admin();
                            admin.Show();
                            this.Close();

                        }
                        else
                        {
                            MessageBox.Show("No records were deleted. Please check if the athlete exists.",
                                          "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }


                }
            }



            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error during deletion: {sqlEx.Message}",
                              "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting athlete data: {ex.Message}",
                              "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DeleteAthleteData();
        }



    }

}