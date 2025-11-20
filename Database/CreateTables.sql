-- =============================================
-- Student Management System - Table Creation
-- Run this after CreateDatabase.sql
-- =============================================

USE StudentManagementDB;
GO

-- Students Table
CREATE TABLE Students (
    StudentID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    PhoneNumber NVARCHAR(15),
    DateOfBirth DATE,
    EnrollmentDate DATE DEFAULT GETDATE(),
    Address NVARCHAR(200)
);
GO

-- Courses Table
CREATE TABLE Courses (
    CourseID INT PRIMARY KEY IDENTITY(1,1),
    CourseName NVARCHAR(100) NOT NULL,
    CourseCode NVARCHAR(20) UNIQUE NOT NULL,
    Credits INT NOT NULL,
    Description NVARCHAR(500)
);
GO

-- Enrollments Table
CREATE TABLE Enrollments (
    EnrollmentID INT PRIMARY KEY IDENTITY(1,1),
    StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
    CourseID INT FOREIGN KEY REFERENCES Courses(CourseID),
    EnrollmentDate DATE DEFAULT GETDATE(),
    Semester NVARCHAR(20)
);
GO

-- Attendance Table
CREATE TABLE Attendance (
    AttendanceID INT PRIMARY KEY IDENTITY(1,1),
    EnrollmentID INT FOREIGN KEY REFERENCES Enrollments(EnrollmentID),
    AttendanceDate DATE NOT NULL,
    Status NVARCHAR(10) CHECK (Status IN ('Present', 'Absent', 'Late')),
    Remarks NVARCHAR(200)
);
GO

-- Grades Table
CREATE TABLE Grades (
    GradeID INT PRIMARY KEY IDENTITY(1,1),
    EnrollmentID INT FOREIGN KEY REFERENCES Enrollments(EnrollmentID),
    AssignmentName NVARCHAR(100),
    MarksObtained DECIMAL(5,2),
    TotalMarks DECIMAL(5,2),
    GradeDate DATE DEFAULT GETDATE(),
    FinalGrade NVARCHAR(5)
);
GO

PRINT 'All tables created successfully!';
GO
