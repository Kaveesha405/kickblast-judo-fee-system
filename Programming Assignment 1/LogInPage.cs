using Guna.UI2.WinForms;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Programming_Assignment__
{
    public partial class LogInPage : Form
    {

        public LogInPage()
        {
            InitializeComponent();

            pictureBox4.TabStop = false;
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUpPage signUpPage = new SignUpPage();
            signUpPage.Show();
            this.Hide();
        }



        private void LogInPage_Load(object sender, EventArgs e)
        {

        }
        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            WelcomePage welcome = new WelcomePage();
            welcome.Show();
            this.Hide();
        }


        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {

                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }


        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-UJ535S4S\\SQLEXPRESS;Initial Catalog=KICK;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            string userType = "";
            bool loginSuccess = false;


            string athleteQuery = "SELECT COUNT(*) FROM Athletes WHERE Username=@Username AND Password=@Password";
            SqlCommand athleteCmd = new SqlCommand(athleteQuery, con);
            athleteCmd.Parameters.AddWithValue("@Username", textBox1.Text);
            athleteCmd.Parameters.AddWithValue("@Password", textBox2.Text);
            int athleteCount = (int)athleteCmd.ExecuteScalar();

            if (athleteCount > 0)
            {


                loginSuccess = true;
                userType = "athlete";
            }
            else

            {
                string adminQuery = "SELECT COUNT(*) FROM AdminUsers WHERE Username=@Username AND Password=@Password";
                SqlCommand adminCmd = new SqlCommand(adminQuery, con);
                adminCmd.Parameters.AddWithValue("@Username", textBox1.Text);
                adminCmd.Parameters.AddWithValue("@Password", textBox2.Text);
                int adminCount = (int)adminCmd.ExecuteScalar();

                if (adminCount > 0)
                {
                    loginSuccess = true;
                    userType = "admin";

                }
            }

            con.Close();



            if (loginSuccess)
            {
                if (userType == "athlete")
                {
                    MessageBox.Show("Welcome Athlete!", "Login Successful",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ;

                    HomePage homePage = new HomePage(textBox1.Text);
                    homePage.Show();
                    this.Hide();
                }

                else if (userType == "admin")
                {

                    MessageBox.Show("Welcome Admin!", "Login Successful",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Admin admin = new Admin(textBox1.Text);
                    admin.Show();
                    this.Hide();
                }
            }
            else

            {
                MessageBox.Show("Invalid username or password!\nPlease check your credentials and try again.",
                               "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                textBox2.Clear();
                textBox1.Focus();

            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

    }
}
