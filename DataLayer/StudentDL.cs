using MySql.Data.MySqlClient;
using UAMS.Models;
using UAMS.UserInterface;
using UAMS.Utilities;

namespace UAMS.DataLayer
{
    public class StudentDL
    {
        public static void SaveStudentToDataBase(Student s)
        {
            DotNetEnv.Env.Load();
            string ConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
            
            using (MySqlConnection Connection = new MySqlConnection(ConnectionString))
            {
                Connection.Open();
                string query = "INSERT INTO Students(StudentName, FatherName, CNIC, MatricMarks, FscMarks, ATMarks, Aggregate) Values (@StudentName, @FatherName, @CNIC, @MatricMarks, @FscMarks, @ATMarks, @Aggregate)";
                using (MySqlCommand command = new MySqlCommand(query, Connection))
                {
                    command.Parameters.AddWithValue("@StudentName", s.studentName);
                    command.Parameters.AddWithValue("@FatherName", s.fatherName);
                    command.Parameters.AddWithValue("@CNIC", s.cnic);
                    command.Parameters.AddWithValue("@MatricMarks", s.matricMarks);
                    command.Parameters.AddWithValue("@FscMarks", s.fscMarks);
                    command.Parameters.AddWithValue("@ATMarks", s.testMarks);
                    command.Parameters.AddWithValue("@Aggregate", s.aggregate);

                    command.ExecuteNonQuery();
                }
            }

            Console.WriteLine("Student Added Successfully");
        }
    }
}