# KickBlast Judo Fee Management System

A desktop application for managing athlete registrations, training fee calculations, competition enrollments, and payment records for the KickBlast Judo Club.

This project was developed as part of an HND Programming assignment covering the full software development lifecycle — from algorithm design to GUI implementation and database integration.

***

## Features

- Athlete sign up and login with input validation
- Monthly training fee calculation based on training plan and weight category
- Competition registration for athletes
- Payment history viewing and management
- Admin panel to add, update, and delete athlete records
- Receipt generation with duplicate detection
- In-app contact admin messaging

***

## Tech Stack

| Layer       | Technology                  |
|-------------|-----------------------------|
| Language    | C# (.NET)                   |
| IDE         | Microsoft Visual Studio     |
| UI          | Windows Forms (WinForms)    |
| Database    | Microsoft SQL Server        |
| DB Access   | ADO.NET                     |

***

## Database Tables

- `AdminUsers` — admin credentials and details
- `Athletes` — athlete profiles and personal information
- `TrainingPlans` — available plans and costs
- `WeightCategories` — weight class definitions
- `Competitions` — competition records
- `PaymentDetails` — monthly fee payment records

***

## Application Pages

1. Welcome Page
2. Sign Up Page
3. Log In Page
4. Home Page
5. Payment Details Page
6. Contact Admin Page
7. Register for Competitions Page
8. Admin Page
9. Add Athlete Page
10. Update / Delete Page
11. Fee Calculator Page

***

## Getting Started

### Prerequisites

- Visual Studio 2019 or later
- Microsoft SQL Server (Express or full)
- .NET Framework 4.7+

### Steps

1. Clone the repository
   ```bash
   git clone https://github.com/your-username/kickblast-judo-fee-system.git
   ```

2. Open SQL Server Management Studio and run `KICK_Database_Schema.sql` to set up the database.

3. Update the connection string in the project to match your SQL Server instance.

4. Open the `.sln` file in Visual Studio and press `F5` to run.

***

## Project Structure

```
kickblast-judo-fee-system/
├── Forms/
│   ├── WelcomePage.cs
│   ├── SignUpPage.cs
│   ├── LoginPage.cs
│   ├── HomePage.cs
│   ├── PaymentDetailsPage.cs
│   ├── ContactAdminPage.cs
│   ├── CompetitionRegistrationPage.cs
│   ├── AdminPage.cs
│   ├── AddAthletePage.cs
│   ├── UpdateDeletePage.cs
│   └── FeeCalculatorPage.cs
├── Database/
│   └── KICK_Database_Schema.sql
└── README.md
```

***

## Author

**Kaveesha Amiru** | Student ID: 00272845  
HND in Computing — Programming Module  
Lecturer: Ms. Layanga Kaushani

> This project was developed for academic purposes.
