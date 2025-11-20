using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.DAL
{
    public class DatabaseHelper : IDisposable
    {
        private SqlConnection connection;
        private string connectionString;

        public DatabaseHelper()
        {
            // Get connection string from Web.config
            connectionString = ConfigurationManager.ConnectionStrings["StudentManagementDB"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        // Open database connection
        private void OpenConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        // Close database connection
        private void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        // Get all students
        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            try
            {
                OpenConnection();
                string query = "SELECT * FROM Students ORDER BY LastName, FirstName";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    students.Add(new Student
                    {
                        StudentID = Convert.ToInt32(reader["StudentID"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        PhoneNumber = reader["PhoneNumber"] != DBNull.Value ? reader["PhoneNumber"].ToString() : null,
                        DateOfBirth = reader["DateOfBirth"] != DBNull.Value ? Convert.ToDateTime(reader["DateOfBirth"]) : (DateTime?)null,
                        Address = reader["Address"] != DBNull.Value ? reader["Address"].ToString() : null,
                        EnrollmentDate = Convert.ToDateTime(reader["EnrollmentDate"])
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving students: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return students;
        }

        // Get student by ID
        public Student GetStudentById(int studentId)
        {
            Student student = null;
            try
            {
                OpenConnection();
                string query = "SELECT * FROM Students WHERE StudentID = @StudentID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@StudentID", studentId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    student = new Student
                    {
                        StudentID = Convert.ToInt32(reader["StudentID"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        PhoneNumber = reader["PhoneNumber"] != DBNull.Value ? reader["PhoneNumber"].ToString() : null,
                        DateOfBirth = reader["DateOfBirth"] != DBNull.Value ? Convert.ToDateTime(reader["DateOfBirth"]) : (DateTime?)null,
                        Address = reader["Address"] != DBNull.Value ? reader["Address"].ToString() : null,
                        EnrollmentDate = Convert.ToDateTime(reader["EnrollmentDate"])
                    };
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving student: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return student;
        }

        // Add new student
        public void AddStudent(Student student)
        {
            try
            {
                OpenConnection();
                string query = @"INSERT INTO Students (FirstName, LastName, Email, PhoneNumber, DateOfBirth, Address, EnrollmentDate) 
                               VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @DateOfBirth, @Address, @EnrollmentDate)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                cmd.Parameters.AddWithValue("@LastName", student.LastName);
                cmd.Parameters.AddWithValue("@Email", student.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", (object)student.PhoneNumber ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DateOfBirth", (object)student.DateOfBirth ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Address", (object)student.Address ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@EnrollmentDate", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding student: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        // Update student
        public void UpdateStudent(Student student)
        {
            try
            {
                OpenConnection();
                string query = @"UPDATE Students SET FirstName = @FirstName, LastName = @LastName, Email = @Email, 
                               PhoneNumber = @PhoneNumber, DateOfBirth = @DateOfBirth, Address = @Address 
                               WHERE StudentID = @StudentID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@StudentID", student.StudentID);
                cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                cmd.Parameters.AddWithValue("@LastName", student.LastName);
                cmd.Parameters.AddWithValue("@Email", student.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", (object)student.PhoneNumber ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DateOfBirth", (object)student.DateOfBirth ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Address", (object)student.Address ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating student: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        // Delete student
        public void DeleteStudent(int studentId)
        {
            try
            {
                OpenConnection();
                string query = "DELETE FROM Students WHERE StudentID = @StudentID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@StudentID", studentId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting student: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        // Dispose method for cleanup
        public void Dispose()
        {
            if (connection != null)
            {
                CloseConnection();
                connection.Dispose();
            }
        }
    }
}
