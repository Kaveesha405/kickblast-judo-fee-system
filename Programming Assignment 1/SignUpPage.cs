using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace Programming_Assignment__
{
    public partial class SignUpPage : Form
    {

        private List<WeightCategory> weightCategories = new List<WeightCategory>();

        public class WeightCategory
        {

            public int CategoryId { get; set; }
            public string CategoryName { get; set; }
            public decimal UpperWeightLimitKg { get; set; }
            public bool IsUnlimited { get; set; }
            public string WeightDescription { get; set; }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
        }


        public SignUpPage()
        {
            InitializeComponent();
            LoadWeightCategoriesFromDatabase();
            InitializePrivateCoachingComboBoxes();

 
            TrainingPlanComboBox.Items.Add("Select Training Plan");
            TrainingPlanComboBox.Items.Add("Beginner");
            TrainingPlanComboBox.Items.Add("Intermediate");
            TrainingPlanComboBox.Items.Add("Elite");
            TrainingPlanComboBox.SelectedIndex = 0;
        }

        private void guna2CustomRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void InitializePrivateCoachingComboBoxes()
        {
            var coachingBoxes = new[] {
                PrivateCoachingWeek1ComboBox,
                PrivateCoachingWeek2ComboBox,
                PrivateCoachingWeek3ComboBox,
                PrivateCoachingWeek4ComboBox
            };

            foreach (var comboBox in coachingBoxes)
            {
                for (int i = 0; i <= 5; i++)
                {
                    comboBox.Items.Add(i.ToString());
                }
                comboBox.SelectedIndex = 0;
            }
        }

        private void LoadWeightCategoriesFromDatabase()
        {

            string connectionString = "Data Source=LAPTOP-UJ535S4S\\SQLEXPRESS;Initial Catalog=KICK;Integrated Security=True;TrustServerCertificate=True";
            string query = "SELECT * FROM Weight_Categories ORDER BY upper_weight_limit_kg";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            WeightCategoryComboBox.Items.Clear();
                            WeightCategoryComboBox.Items.Add("Select the weight category");
                            weightCategories.Clear();


                            while (reader.Read())
                            {
                                var category = new WeightCategory
                                {
                                    CategoryId = reader["category_id"] != DBNull.Value ? Convert.ToInt32(reader["category_id"]) : 0,
                                    CategoryName = reader["category_name"] != DBNull.Value ? reader["category_name"].ToString() : "Unknown",
                                    UpperWeightLimitKg = reader["upper_weight_limit_kg"] != DBNull.Value ? Convert.ToDecimal(reader["upper_weight_limit_kg"]) : 0,
                                    IsUnlimited = reader["is_unlimited"] != DBNull.Value ? Convert.ToBoolean(reader["is_unlimited"]) : false,
                                    WeightDescription = reader["weight_description"] != DBNull.Value ? reader["weight_description"].ToString() : "No description"
                                };


                                weightCategories.Add(category);
                                string displayText = $"{category.CategoryName} - {category.WeightDescription}";
                                WeightCategoryComboBox.Items.Add(displayText);
                            }
                        }

                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading weight categories: " + ex.Message);
                    }
                }


            }
        }

        private void guna2GradientCircleButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                WelcomePage welcomePage = new WelcomePage();
                welcomePage.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error going back: " + ex.Message);
            }
        }



        private void SignUpPage_Load(object sender, EventArgs e)
        {
            
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

            string username = UsernameTextBox.Text.Trim();
            string fullName = FullNameTextBox.Text.Trim();
            string phoneNumber = PhoneNumberTextBox.Text.Trim();
            DateTime dateOfBirth = DateOfBirthDateTimePicker.Value;
            string email = EmailTextBox.Text.Trim();
            string password = PasswordTextBox.Text;
            string confirmPassword = ConfirmPasswordTextBox.Text;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter a username.");
                return;
            }

            if (string.IsNullOrEmpty(fullName))
            {
                MessageBox.Show("Please enter your full name.");
                return;
            }


            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter a password.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords don't match!");
                return;
            }

       
            if (string.IsNullOrEmpty(WeightTextBox.Text.Trim()))
            {
                MessageBox.Show("Please enter your weight.");

                return;
            }

            decimal weight;
            if (!decimal.TryParse(WeightTextBox.Text.Trim(), out weight) || weight <= 0)
            {
                MessageBox.Show("Please enter a valid weight.");

                return;
            }

           
            if (string.IsNullOrEmpty(CompetitionsTextBox.Text.Trim()))
            {
                MessageBox.Show("Please enter number of competitions.");
                return;
            }

            int competitions;
            if (!int.TryParse(CompetitionsTextBox.Text.Trim(), out competitions) || competitions < 0)
            {
                MessageBox.Show("Please enter a valid number of competitions.");
                return;
            }

         
            if (TrainingPlanComboBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select a training plan.");

                return;
            }

          
            if (WeightCategoryComboBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select a weight category.");
                return;
            }



            string trainingPlan = TrainingPlanComboBox.SelectedItem.ToString();
            string weightCategory = WeightCategoryComboBox.SelectedItem.ToString();

           
            if (!CheckWeightCategory(weight, weightCategory))
            {
                MessageBox.Show("Weight doesn't match the selected category!");
                return;

            }

           
            string privateCoachingWeek1 = PrivateCoachingWeek1ComboBox.SelectedItem?.ToString() ?? "0";
            string privateCoachingWeek2 = PrivateCoachingWeek2ComboBox.SelectedItem?.ToString() ?? "0";
            string privateCoachingWeek3 = PrivateCoachingWeek3ComboBox.SelectedItem?.ToString() ?? "0";
            string privateCoachingWeek4 = PrivateCoachingWeek4ComboBox.SelectedItem?.ToString() ?? "0";

            try
            {
                
                SaveUserToDatabase(username, fullName, email, phoneNumber, dateOfBirth, password,
                    confirmPassword, weight, weightCategory, competitions, trainingPlan,
                    privateCoachingWeek1, privateCoachingWeek2, privateCoachingWeek3, privateCoachingWeek4);

                MessageBox.Show("Registration successful!");
                GoToLoginPage();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during registration: " + ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void SaveUserToDatabase(string username, string fullName, string email, string phoneNumber,
                           DateTime dateOfBirth, string password, string confirmPassword,
                           decimal weight, string competitionWeightCategory, int noOfCompetitionsThisMonth,
                           string trainingPlan, string privateCoachingWeek1,
                           string privateCoachingWeek2, string privateCoachingWeek3,
                           string privateCoachingWeek4)
        {
            string connectionString = "Data Source=LAPTOP-UJ535S4S\\SQLEXPRESS;Initial Catalog=KICK;Integrated Security=True;TrustServerCertificate=True";

            string query = @"INSERT INTO Athletes (Username, FullName, Email, PhoneNumber, DateOfBirth, 
                     Password, ConfirmPassword, Weight, CompetitionWeightCategory, 
                     NoOfCompetitionsThisMonth, TrainingPlan, PrivateCoachingWeek1, 
                     PrivateCoachingWeek2, PrivateCoachingWeek3, PrivateCoachingWeek4) 
                     VALUES (@Username, @FullName, @Email, @PhoneNumber, @DateOfBirth, 
                     @Password, @ConfirmPassword, @Weight, @CompetitionWeightCategory, 
                     @NoOfCompetitionsThisMonth, @TrainingPlan, @PrivateCoachingWeek1, 
                     @PrivateCoachingWeek2, @PrivateCoachingWeek3, @PrivateCoachingWeek4)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                   
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@FullName", fullName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PhoneNumber", phoneNumber ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@ConfirmPassword", confirmPassword);
                    command.Parameters.AddWithValue("@Weight", weight);
                    command.Parameters.AddWithValue("@CompetitionWeightCategory", competitionWeightCategory ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@NoOfCompetitionsThisMonth", noOfCompetitionsThisMonth);
                    command.Parameters.AddWithValue("@TrainingPlan", trainingPlan ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PrivateCoachingWeek1", privateCoachingWeek1 ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PrivateCoachingWeek2", privateCoachingWeek2 ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PrivateCoachingWeek3", privateCoachingWeek3 ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PrivateCoachingWeek4", privateCoachingWeek4 ?? (object)DBNull.Value);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

        }



        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void GoToLoginPage()
        {
            try
            {
                LogInPage loginForm = new LogInPage();
                loginForm.Show();
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error opening login page: " + ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                ConfirmPasswordTextBox.PasswordChar = '\0';
                PasswordTextBox.PasswordChar = '\0';
            }

            else
            {
                ConfirmPasswordTextBox.PasswordChar = '*';
                PasswordTextBox.PasswordChar = '*';
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
 
            UsernameTextBox.Clear();
            FullNameTextBox.Clear();
            PhoneNumberTextBox.Clear();
            EmailTextBox.Clear();
            PasswordTextBox.Clear();
            ConfirmPasswordTextBox.Clear();
            WeightTextBox.Clear();
            CompetitionsTextBox.Clear();
            DateOfBirthDateTimePicker.Value = DateTime.Now;


            TrainingPlanComboBox.SelectedIndex = 0;
            PrivateCoachingWeek1ComboBox.SelectedIndex = 0;
            PrivateCoachingWeek2ComboBox.SelectedIndex = 0;
            PrivateCoachingWeek3ComboBox.SelectedIndex = 0;
            PrivateCoachingWeek4ComboBox.SelectedIndex = 0;
            WeightCategoryComboBox.SelectedIndex = 0;
        }



        private bool CheckWeightCategory(decimal weight, string category)
        {
            if (WeightCategoryComboBox.SelectedIndex == 0) return false;

            int categoryIndex = WeightCategoryComboBox.SelectedIndex - 1;

            if (categoryIndex >= 0 && categoryIndex < weightCategories.Count)
            {
                var selectedCategory = weightCategories[categoryIndex];

                if (selectedCategory.IsUnlimited)
                {
                    return weight > 0;
                }
                else
                {
                    return weight > 0 && weight <= selectedCategory.UpperWeightLimitKg;
                }
            }

            return false;
        }

    }
}