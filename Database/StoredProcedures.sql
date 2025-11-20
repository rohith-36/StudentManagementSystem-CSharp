-- ==================================================
-- Stored Procedures - Student Management System  
-- Run after CreateTables.sql
-- ==================================================

USE StudentManagementDB;
GO

-- SP: Add Student
CREATE PROCEDURE sp_AddStudent
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Email NVARCHAR(100),
    @PhoneNumber NVARCHAR(15),
    @DateOfBirth DATE,
    @Address NVARCHAR(200)
AS
BEGIN
    INSERT INTO Students (FirstName, LastName, Email, PhoneNumber, DateOfBirth, Address)
    VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @DateOfBirth, @Address);
    SELECT SCOPE_IDENTITY() AS NewStudentID;
END;
GO

-- SP: Calculate Final Grade
CREATE PROCEDURE sp_CalculateFinalGrade
    @EnrollmentID INT
AS
BEGIN
    DECLARE @AvgPercent DECIMAL(5,2);
    DECLARE @Grade NVARCHAR(5);
    
    SELECT @AvgPercent = AVG((MarksObtained / TotalMarks) * 100)
    FROM Grades WHERE EnrollmentID = @EnrollmentID;
    
    SET @Grade = CASE
        WHEN @AvgPercent >= 90 THEN 'A+'
        WHEN @AvgPercent >= 80 THEN 'A'
        WHEN @AvgPercent >= 70 THEN 'B'
        WHEN @AvgPercent >= 60 THEN 'C'
        WHEN @AvgPercent >= 50 THEN 'D'
        ELSE 'F'
    END;
    
    SELECT @Grade AS FinalGrade, @AvgPercent AS AveragePercentage;
END;
GO

PRINT 'Stored procedures created successfully!';
GO
