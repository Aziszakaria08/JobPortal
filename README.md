Job Portal Application
A comprehensive Job Portal Application built to connect job seekers with employers. This application includes features for both users and administrators to ensure seamless interaction, job postings, and management.

🌟 Features
User Features
Login & Register: Secure authentication for users.
User Profile: Manage personal information and resume.
Upload Resume: Upload your resume for easy application.
Find Jobs: Search and browse available jobs.
Filter Jobs: Narrow down jobs by country, job type, or other filters.
Job Details: View detailed job descriptions.
Contact: Communicate with employers directly.
Admin Features
Dashboard: View total users, total jobs, applied jobs, and contacted users at a glance.
Add Job: Post new job opportunities.
Job List: Manage all job listings.
User List: View and manage registered users.
View Resume: Access and download user resumes.
Contact List: Track contacted users.

 Technologies Used
Frontend:
HTML5, CSS3, JavaScript
ASP.NET Web Forms
Backend:
C# (.NET Framework)
SQL Server for database management
Tools & Libraries:
ADO.NET for database interaction
Visual Studio IDE
Deployment: IIS (Internet Information Services) or Azure (Optional)
🛠 Installation Guide
Prerequisites
Visual Studio (2019 or later)
SQL Server (Express or Standard)
IIS for local deployment (optional)
Steps to Install
Clone the repository:
bash
Copy code
git clone https://github.com/yourusername/job-portal.git
cd job-portal
Open the solution file (JobPortal.sln) in Visual Studio.
Update the database connection string in Web.config:
xml
Copy code
<connectionStrings>
    <add name="JobPortalDB" connectionString="your_connection_string_here" providerName="System.Data.SqlClient" />
</connectionStrings>
Run the SQL scripts in the /Database folder to create the database schema and seed data.
Build and run the application:
Press Ctrl + F5 to start the application in your default browser.
Deploy to IIS (Optional):
Publish the application from Visual Studio and configure the IIS settings.
