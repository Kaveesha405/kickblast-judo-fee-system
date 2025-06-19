using Microsoft.Data.SqlClient;
using Programming_Assignment_1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Programming_Assignment__
{
    public partial class AddAthlete : Form
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


        private void button1_Click(object sender, EventArgs e)
        {


        }

        public AddAthlete()
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


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {


            try
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
                    MessageBox.Show("Please enter a username.", "Username Required",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    UsernameTextBox.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(fullName))
                {
                    MessageBox.Show("Please enter your full name.", "Full Name Required",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FullNameTextBox.Focus();
                    return;
                }



                if (string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please enter a password.", "Password Required",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    PasswordTextBox.Focus();
                    return;
                }



                if (password != confirmPassword)

                {
                    MessageBox.Show("The passwords you entered do not match. Please try again.",
                                  "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ConfirmPasswordTextBox.Focus();
                    return;
                }




                if (string.IsNullOrEmpty(WeightTextBox.Text.Trim()))
                {
                    MessageBox.Show("Please enter your weight.", "Weight Required",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    WeightTextBox.Focus();
                    return;

                }

                if (!decimal.TryParse(WeightTextBox.Text.Trim(), out decimal weight) || weight <= 0)
                {
                    MessageBox.Show("Please enter a valid weight (numbers only, greater than 0).",
                                  "Invalid Weight", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    WeightTextBox.Focus();
                    return;

                }



                if (string.IsNullOrEmpty(CompetitionsTextBox.Text.Trim()))
                {
                    MessageBox.Show("Please enter the number of competitions.", "Competitions Required",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CompetitionsTextBox.Focus();
                    return;

                }



                if (!int.TryParse(CompetitionsTextBox.Text.Trim(), out int competitions) || competitions < 0)
                {
                    
                    
                    MessageBox.Show("Please enter a valid number of competitions (0 or more).",
                                  "Invalid Competitions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CompetitionsTextBox.Focus();
                    return;
                }



                if (TrainingPlanComboBox.SelectedIndex <= 0 || TrainingPlanComboBox.SelectedItem?.ToString() == "Select Training Plan")
                {
                    MessageBox.Show("Please select a valid training plan.", "Training Plan Required",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TrainingPlanComboBox.Focus();
                    return;
                }

                if (WeightCategoryComboBox.SelectedIndex <= 0)
                {
                    
                    

                    MessageBox.Show("Please select a valid weight category.", "Weight Category Required",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    WeightCategoryComboBox.Focus();
                    return;
                }

                string trainingPlan = TrainingPlanComboBox.SelectedItem?.ToString();
                string weightCategory = WeightCategoryComboBox.SelectedItem?.ToString();

                if (!IsWeightValidForCategory(weight, weightCategory))
                {
                    MessageBox.Show("Entered weight does not match the selected weight category.",
                                  "Invalid Weight Category", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }




                string privateCoachingWeek1 = PrivateCoachingWeek1ComboBox.SelectedItem?.ToString() ?? "0";
                string privateCoachingWeek2 = PrivateCoachingWeek2ComboBox.SelectedItem?.ToString() ?? "0";
                string privateCoachingWeek3 = PrivateCoachingWeek3ComboBox.SelectedItem?.ToString() ?? "0";
                string privateCoachingWeek4 = PrivateCoachingWeek4ComboBox.SelectedItem?.ToString() ?? "0";

                InsertUserData(username, fullName, email, phoneNumber, dateOfBirth, password,
                    confirmPassword, weight, weightCategory, competitions, trainingPlan,
                    privateCoachingWeek1, privateCoachingWeek2, privateCoachingWeek3, privateCoachingWeek4);



                MessageBox.Show("Athlete Successfully Added!", "Success",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);



                NavigateToAdmin();
            }

            catch (SqlException sqlEx)
           
            {
                MessageBox.Show($"Database error: {sqlEx.Message}", "Database Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}\n\nPlease check all fields and try again.",
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


           
        }


        private void guna2RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void InsertUserData(string username, string fullName, string email, string phoneNumber,
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
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void LoadWeightCategoriesFromDatabase()
        {
            string connectionString = "Data Source=LAPTOP-UJ535S4S\\SQLEXPRESS;Initial Catalog=KICK;Integrated Security=True;TrustServerCertificate=True";
            string query = "SELECT * FROM Weight_Categories ORDER BY upper_weight_limit_kg";

            
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
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

            }
        }



        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {

        }

        private void NavigateToAdmin()
        {
            Admin admin = new Admin();
            admin.Show();
            this.Hide();
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




        private void AddAthlete_Load(object sender, EventArgs e)
        {

        }

        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Hide();
        }



        private bool IsWeightValidForCategory(decimal weight, string category)
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

        private void AddAthlete_Load_1(object sender, EventArgs e)
        {

        }




    }

}