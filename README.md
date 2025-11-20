# Student Management System - C# & ASP.NET MVC

## 📋 Project Overview
A comprehensive web-based Student Management System built with C#, ASP.NET MVC, and SQL Server. This application enables administrators to efficiently manage student records, enrollment, attendance tracking, and grade management.

## 🚀 Features
- **CRUD Operations**: Create, Read, Update, and Delete student records
- **Attendance Tracking**: Track student attendance with status (Present, Absent, Late)
- **Grade Management**: Manage student grades with automatic grade calculation
- **Course Enrollment**: Enroll students in multiple courses
- **Reporting**: Generate attendance and performance reports
- **Responsive UI**: Clean and user-friendly interface with HTML, CSS, and JavaScript
- **Database Triggers**: Automatic grade updates using SQL triggers
- **Stored Procedures**: Optimized database operations

## 🛠️ Technologies Used
- **Backend**: C#, ASP.NET MVC (.NET Framework)
- **Frontend**: HTML5, CSS3, JavaScript
- **Database**: SQL Server (with T-SQL)
- **IDE**: Visual Studio 2019/2022
- **Version Control**: Git & GitHub

## 📁 Project Structure
```
StudentManagementSystem/
├── Controllers/
│   ├── StudentsController.cs
│   ├── CoursesController.cs
│   └── AttendanceController.cs
├── Models/
│   ├── Student.cs
│   ├── Course.cs
│   ├── Enrollment.cs
│   ├── Attendance.cs
│   └── Grade.cs
├── Views/
│   ├── Students/
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   │   └── Details.cshtml
│   └── Shared/
│       └── _Layout.cshtml
├── DAL/
│   └── DatabaseHelper.cs
├── Database/
│   ├── CreateDatabase.sql
│   ├── CreateTables.sql
│   ├── StoredProcedures.sql
│   └── Triggers.sql
└── Web.config
```

## 💾 Database Schema
The system uses a normalized database with the following tables:
- **Students**: Student information
- **Courses**: Course details
- **Enrollments**: Student-Course relationships
- **Attendance**: Daily attendance records
- **Grades**: Assessment and grade information

## ⚙️ Prerequisites
Before running this project, ensure you have:
- Visual Studio 2019/2022 (Community Edition or higher)
- SQL Server 2016 or later (Express Edition works)
- SQL Server Management Studio (SSMS)
- .NET Framework 4.7.2 or higher
- Basic knowledge of C#, ASP.NET MVC, and SQL Server

## 📥 Installation & Setup

### Step 1: Clone the Repository
```bash
git clone https://github.com/rohith-36/StudentManagementSystem-CSharp.git
cd StudentManagementSystem-CSharp
```

### Step 2: Database Setup
1. Open SQL Server Management Studio (SSMS)
2. Connect to your SQL Server instance
3. Run the SQL scripts in the following order:
   - `Database/CreateDatabase.sql`
   - `Database/CreateTables.sql`
   - `Database/StoredProcedures.sql`
   - `Database/Triggers.sql`

### Step 3: Configure Connection String
1. Open `Web.config` in the project root
2. Update the connection string with your SQL Server details:
```xml
<connectionStrings>
  <add name="StudentManagementDB" 
       connectionString="Data Source=YOUR_SERVER;Initial Catalog=StudentManagementDB;Integrated Security=True" 
       providerName="System.Data.SqlClient"/>
</connectionStrings>
```

### Step 4: Build and Run
1. Open the solution in Visual Studio
2. Restore NuGet packages (Right-click solution → Restore NuGet Packages)
3. Build the solution (Ctrl+Shift+B)
4. Run the project (F5)

## 🎯 Usage

### Managing Students
1. Navigate to the Students page
2. Click "Add New Student" to create a student record
3. Fill in student details (Name, Email, Phone, Date of Birth, Address)
4. Click "Save" to add the student
5. Use "Edit" to modify student information
6. Use "Delete" to remove a student record

### Managing Courses
1. Navigate to Courses section
2. Add new courses with course code, name, credits
3. Assign students to courses through enrollment

### Tracking Attendance
1. Select a course and date
2. Mark attendance status for each student
3. View attendance reports and statistics

### Managing Grades
1. Enter assignment/exam marks
2. System automatically calculates final grades
3. Generate grade reports

## 🗄️ Database Features

### Stored Procedures
- `sp_AddStudent`: Add new student records
- `sp_CalculateFinalGrade`: Calculate final grades based on performance
- `sp_GetAttendanceReport`: Generate attendance statistics

### Triggers
- Auto-update final grades when new marks are added
- Maintain data integrity across related tables

### Sample Data
The database includes sample data insertion scripts for testing:
- 2 sample students
- 3 sample courses
- Enrollment records
- Sample attendance and grade data

## 🎨 Key Features Demonstrated

### C# & OOP Concepts
- Classes and Objects
- Encapsulation with Properties
- Data Validation with Attributes
- Inheritance and Interfaces

### ASP.NET MVC Architecture
- Model-View-Controller pattern
- Routing configuration
- Form validation
- Anti-forgery tokens for security

### Database Operations
- ADO.NET for data access
- Parameterized queries (SQL injection prevention)
- Stored procedures for complex operations
- Database triggers for automation

### Frontend Development
- Responsive HTML5 forms
- CSS3 styling
- JavaScript form validation
- User-friendly UI/UX

## 📊 Sample Screenshots
_(To be added: Screenshots of main pages)_

## 🔒 Security Features
- SQL Injection prevention using parameterized queries
- Anti-forgery tokens on forms
- Input validation (client-side and server-side)
- Secure connection strings

## 🚧 Future Enhancements
- [ ] User authentication and authorization (Admin/Teacher/Student roles)
- [ ] Export reports to PDF/Excel
- [ ] Email notifications for attendance and grades
- [ ] Dashboard with charts and statistics
- [ ] Mobile responsive design improvements
- [ ] REST API for mobile app integration

## 🤝 Contributing
Contributions are welcome! Please feel free to submit a Pull Request.

## 📝 License
This project is open source and available for educational purposes.

## 👨‍💻 Author
**Rohith**
- GitHub: [@rohith-36](https://github.com/rohith-36)
- Project Link: [StudentManagementSystem-CSharp](https://github.com/rohith-36/StudentManagementSystem-CSharp)

## 📞 Contact
For questions or suggestions, please open an issue in the GitHub repository.

## 🙏 Acknowledgments
- Microsoft Documentation for ASP.NET MVC
- Stack Overflow community
- FreeCodeCamp and tutorial resources

---

⭐ If you find this project helpful, please consider giving it a star on GitHub!
