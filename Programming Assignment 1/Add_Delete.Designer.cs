using System.Drawing;
using System.Windows.Forms;

namespace Programming_Assignment__
{
    partial class Add_Delete
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add_Delete));
            this.guna2GradientCircleButton1 = new Guna.UI2.WinForms.Guna2GradientCircleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.FullNameTextBox = new System.Windows.Forms.TextBox();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.PhoneNumberTextBox = new System.Windows.Forms.TextBox();
            this.WeightTextBox = new System.Windows.Forms.TextBox();
            this.CompetitionsTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DeleteButton = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this.guna2GradientTileButton1 = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this.guna2GradientTileButton3 = new Guna.UI2.WinForms.Guna2GradientTileButton();
            this.DateOfBirthDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.PrivateCoachingWeek2ComboBox = new System.Windows.Forms.ComboBox();
            this.PrivateCoachingWeek4ComboBox = new System.Windows.Forms.ComboBox();
            this.PrivateCoachingWeek3ComboBox = new System.Windows.Forms.ComboBox();
            this.PrivateCoachingWeek1ComboBox = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.TrainingPlanComboBox = new System.Windows.Forms.ComboBox();
            this.WeightCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // guna2GradientCircleButton1
            // 
            this.guna2GradientCircleButton1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientCircleButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientCircleButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientCircleButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientCircleButton1.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientCircleButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientCircleButton1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GradientCircleButton1.ForeColor = System.Drawing.Color.White;
            this.guna2GradientCircleButton1.Location = new System.Drawing.Point(53, 40);
            this.guna2GradientCircleButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2GradientCircleButton1.Name = "guna2GradientCircleButton1";
            this.guna2GradientCircleButton1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2GradientCircleButton1.Size = new System.Drawing.Size(54, 52);
            this.guna2GradientCircleButton1.TabIndex = 59;
            this.guna2GradientCircleButton1.Text = "🡠";
            this.guna2GradientCircleButton1.Click += new System.EventHandler(this.guna2GradientCircleButton1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(196, 400);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 21);
            this.label2.TabIndex = 51;
            this.label2.Text = "Weight";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(199, 475);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 21);
            this.label8.TabIndex = 52;
            this.label8.Text = "Training Plan";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(193, 330);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 21);
            this.label3.TabIndex = 50;
            this.label3.Text = "Phone Number";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(199, 545);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(263, 21);
            this.label9.TabIndex = 53;
            this.label9.Text = "Competition Weight Category";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(193, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 21);
            this.label4.TabIndex = 46;
            this.label4.Text = "Date Of Birth:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(193, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 21);
            this.label7.TabIndex = 49;
            this.label7.Text = "Email";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(199, 608);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(353, 21);
            this.label1.TabIndex = 54;
            this.label1.Text = "No Of Competitions entered this month:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(193, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 21);
            this.label6.TabIndex = 48;
            this.label6.Text = "Full Name:";
            // 
            // FullNameTextBox
            // 
            this.FullNameTextBox.Location = new System.Drawing.Point(193, 152);
            this.FullNameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FullNameTextBox.Name = "FullNameTextBox";
            this.FullNameTextBox.Size = new System.Drawing.Size(376, 27);
            this.FullNameTextBox.TabIndex = 55;
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Location = new System.Drawing.Point(193, 220);
            this.EmailTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(376, 27);
            this.EmailTextBox.TabIndex = 60;
            // 
            // PhoneNumberTextBox
            // 
            this.PhoneNumberTextBox.Location = new System.Drawing.Point(193, 354);
            this.PhoneNumberTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PhoneNumberTextBox.Name = "PhoneNumberTextBox";
            this.PhoneNumberTextBox.Size = new System.Drawing.Size(379, 27);
            this.PhoneNumberTextBox.TabIndex = 62;
            // 
            // WeightTextBox
            // 
            this.WeightTextBox.Location = new System.Drawing.Point(193, 424);
            this.WeightTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WeightTextBox.Name = "WeightTextBox";
            this.WeightTextBox.Size = new System.Drawing.Size(379, 27);
            this.WeightTextBox.TabIndex = 63;
            // 
            // CompetitionsTextBox
            // 
            this.CompetitionsTextBox.Location = new System.Drawing.Point(193, 632);
            this.CompetitionsTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CompetitionsTextBox.Name = "CompetitionsTextBox";
            this.CompetitionsTextBox.Size = new System.Drawing.Size(379, 27);
            this.CompetitionsTextBox.TabIndex = 66;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(170, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(265, 40);
            this.label5.TabIndex = 67;
            this.label5.Text = "Update/Delete";
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.Transparent;
            this.DeleteButton.BorderRadius = 20;
            this.DeleteButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.DeleteButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.DeleteButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.DeleteButton.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.DeleteButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.DeleteButton.FillColor = System.Drawing.Color.Red;
            this.DeleteButton.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.DeleteButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.ForeColor = System.Drawing.Color.White;
            this.DeleteButton.Location = new System.Drawing.Point(777, 440);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(187, 59);
            this.DeleteButton.TabIndex = 68;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // guna2GradientTileButton1
            // 
            this.guna2GradientTileButton1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientTileButton1.BorderRadius = 20;
            this.guna2GradientTileButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientTileButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientTileButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientTileButton1.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientTileButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientTileButton1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GradientTileButton1.ForeColor = System.Drawing.Color.White;
            this.guna2GradientTileButton1.Location = new System.Drawing.Point(777, 354);
            this.guna2GradientTileButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2GradientTileButton1.Name = "guna2GradientTileButton1";
            this.guna2GradientTileButton1.Size = new System.Drawing.Size(187, 59);
            this.guna2GradientTileButton1.TabIndex = 69;
            this.guna2GradientTileButton1.Text = "Update";
            this.guna2GradientTileButton1.Click += new System.EventHandler(this.guna2GradientTileButton1_Click);
            // 
            // guna2GradientTileButton3
            // 
            this.guna2GradientTileButton3.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientTileButton3.BorderRadius = 20;
            this.guna2GradientTileButton3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientTileButton3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientTileButton3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientTileButton3.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientTileButton3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientTileButton3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GradientTileButton3.ForeColor = System.Drawing.Color.White;
            this.guna2GradientTileButton3.Location = new System.Drawing.Point(777, 538);
            this.guna2GradientTileButton3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2GradientTileButton3.Name = "guna2GradientTileButton3";
            this.guna2GradientTileButton3.Size = new System.Drawing.Size(187, 59);
            this.guna2GradientTileButton3.TabIndex = 70;
            this.guna2GradientTileButton3.Text = "Confirm";
            this.guna2GradientTileButton3.Click += new System.EventHandler(this.guna2GradientTileButton3_Click);
            // 
            // DateOfBirthDateTimePicker
            // 
            this.DateOfBirthDateTimePicker.Location = new System.Drawing.Point(193, 286);
            this.DateOfBirthDateTimePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DateOfBirthDateTimePicker.Name = "DateOfBirthDateTimePicker";
            this.DateOfBirthDateTimePicker.Size = new System.Drawing.Size(382, 27);
            this.DateOfBirthDateTimePicker.TabIndex = 71;
            // 
            // PrivateCoachingWeek2ComboBox
            // 
            this.PrivateCoachingWeek2ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PrivateCoachingWeek2ComboBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrivateCoachingWeek2ComboBox.FormattingEnabled = true;
            this.PrivateCoachingWeek2ComboBox.Location = new System.Drawing.Point(902, 170);
            this.PrivateCoachingWeek2ComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PrivateCoachingWeek2ComboBox.MaxDropDownItems = 31;
            this.PrivateCoachingWeek2ComboBox.MaxLength = 100;
            this.PrivateCoachingWeek2ComboBox.Name = "PrivateCoachingWeek2ComboBox";
            this.PrivateCoachingWeek2ComboBox.Size = new System.Drawing.Size(76, 26);
            this.PrivateCoachingWeek2ComboBox.TabIndex = 114;
            // 
            // PrivateCoachingWeek4ComboBox
            // 
            this.PrivateCoachingWeek4ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PrivateCoachingWeek4ComboBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrivateCoachingWeek4ComboBox.FormattingEnabled = true;
            this.PrivateCoachingWeek4ComboBox.Location = new System.Drawing.Point(902, 216);
            this.PrivateCoachingWeek4ComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PrivateCoachingWeek4ComboBox.MaxDropDownItems = 31;
            this.PrivateCoachingWeek4ComboBox.MaxLength = 100;
            this.PrivateCoachingWeek4ComboBox.Name = "PrivateCoachingWeek4ComboBox";
            this.PrivateCoachingWeek4ComboBox.Size = new System.Drawing.Size(76, 26);
            this.PrivateCoachingWeek4ComboBox.TabIndex = 113;
            // 
            // PrivateCoachingWeek3ComboBox
            // 
            this.PrivateCoachingWeek3ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PrivateCoachingWeek3ComboBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrivateCoachingWeek3ComboBox.FormattingEnabled = true;
            this.PrivateCoachingWeek3ComboBox.Location = new System.Drawing.Point(730, 216);
            this.PrivateCoachingWeek3ComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PrivateCoachingWeek3ComboBox.MaxDropDownItems = 31;
            this.PrivateCoachingWeek3ComboBox.MaxLength = 100;
            this.PrivateCoachingWeek3ComboBox.Name = "PrivateCoachingWeek3ComboBox";
            this.PrivateCoachingWeek3ComboBox.Size = new System.Drawing.Size(76, 26);
            this.PrivateCoachingWeek3ComboBox.TabIndex = 112;
            // 
            // PrivateCoachingWeek1ComboBox
            // 
            this.PrivateCoachingWeek1ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PrivateCoachingWeek1ComboBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrivateCoachingWeek1ComboBox.FormattingEnabled = true;
            this.PrivateCoachingWeek1ComboBox.Location = new System.Drawing.Point(730, 170);
            this.PrivateCoachingWeek1ComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PrivateCoachingWeek1ComboBox.MaxDropDownItems = 31;
            this.PrivateCoachingWeek1ComboBox.MaxLength = 100;
            this.PrivateCoachingWeek1ComboBox.Name = "PrivateCoachingWeek1ComboBox";
            this.PrivateCoachingWeek1ComboBox.Size = new System.Drawing.Size(76, 26);
            this.PrivateCoachingWeek1ComboBox.TabIndex = 111;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(827, 169);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(69, 22);
            this.label16.TabIndex = 110;
            this.label16.Text = "Week 2";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(666, 220);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(69, 22);
            this.label15.TabIndex = 109;
            this.label15.Text = "Week 3";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(827, 220);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 22);
            this.label14.TabIndex = 108;
            this.label14.Text = "Week 4";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(666, 169);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 22);
            this.label13.TabIndex = 107;
            this.label13.Text = "Week 1";
            // 
            // TrainingPlanComboBox
            // 
            this.TrainingPlanComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TrainingPlanComboBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrainingPlanComboBox.FormattingEnabled = true;
            this.TrainingPlanComboBox.Location = new System.Drawing.Point(193, 499);
            this.TrainingPlanComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TrainingPlanComboBox.MaxDropDownItems = 31;
            this.TrainingPlanComboBox.MaxLength = 100;
            this.TrainingPlanComboBox.Name = "TrainingPlanComboBox";
            this.TrainingPlanComboBox.Size = new System.Drawing.Size(382, 26);
            this.TrainingPlanComboBox.TabIndex = 115;
            // 
            // WeightCategoryComboBox
            // 
            this.WeightCategoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WeightCategoryComboBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WeightCategoryComboBox.FormattingEnabled = true;
            this.WeightCategoryComboBox.Location = new System.Drawing.Point(193, 569);
            this.WeightCategoryComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WeightCategoryComboBox.MaxDropDownItems = 31;
            this.WeightCategoryComboBox.MaxLength = 100;
            this.WeightCategoryComboBox.Name = "WeightCategoryComboBox";
            this.WeightCategoryComboBox.Size = new System.Drawing.Size(429, 26);
            this.WeightCategoryComboBox.TabIndex = 116;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(666, 128);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(154, 21);
            this.label10.TabIndex = 117;
            this.label10.Text = "Private Coaching";
            // 
            // Add_Delete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1253, 738);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.WeightCategoryComboBox);
            this.Controls.Add(this.TrainingPlanComboBox);
            this.Controls.Add(this.PrivateCoachingWeek2ComboBox);
            this.Controls.Add(this.PrivateCoachingWeek4ComboBox);
            this.Controls.Add(this.PrivateCoachingWeek3ComboBox);
            this.Controls.Add(this.PrivateCoachingWeek1ComboBox);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.DateOfBirthDateTimePicker);
            this.Controls.Add(this.guna2GradientTileButton3);
            this.Controls.Add(this.guna2GradientTileButton1);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CompetitionsTextBox);
            this.Controls.Add(this.WeightTextBox);
            this.Controls.Add(this.PhoneNumberTextBox);
            this.Controls.Add(this.EmailTextBox);
            this.Controls.Add(this.FullNameTextBox);
            this.Controls.Add(this.guna2GradientCircleButton1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Add_Delete";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update/Delete";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2GradientCircleButton guna2GradientCircleButton1;
        private Label label2;
        private Label label8;
        private Label label3;
        private Label label9;
        private Label label4;
        private Label label7;
        private Label label1;
        private Label label6;
        private TextBox FullNameTextBox;
        private TextBox EmailTextBox;
        private TextBox PhoneNumberTextBox;
        private TextBox WeightTextBox;
        private TextBox CompetitionsTextBox;
        private Label label5;
        private Guna.UI2.WinForms.Guna2GradientTileButton DeleteButton;
        private Guna.UI2.WinForms.Guna2GradientTileButton guna2GradientTileButton1;
        private Guna.UI2.WinForms.Guna2GradientTileButton guna2GradientTileButton3;
        private DateTimePicker DateOfBirthDateTimePicker;
        private ComboBox PrivateCoachingWeek2ComboBox;
        private ComboBox PrivateCoachingWeek4ComboBox;
        private ComboBox PrivateCoachingWeek3ComboBox;
        private ComboBox PrivateCoachingWeek1ComboBox;
        private Label label16;
        private Label label15;
        private Label label14;
        private Label label13;
        private ComboBox TrainingPlanComboBox;
        private ComboBox WeightCategoryComboBox;
        private Label label10;
    }
}