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

        public static List<Student> LoadAllStudentsFromDataBase(Student s)
        {
            List<Student> studentList = new List<Student>();

            DotNetEnv.Env.Load();
            string ConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
            
            using (MySqlConnection Connection = new MySqlConnection(ConnectionString))
            {
                Connection.Open();
                string query = "Select * from Students";
                using (MySqlCommand command = new MySqlCommand(query, Connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Student student = new Student
                            {
                                studentID = reader.GetInt32("StudentID"),
                                studentName = reader.GetString("StudentName"),
                                fatherName = reader.GetString("FatherName"),
                                cnic = reader.GetString("CNIC"),
                                matricMarks = reader.GetInt32("MatricMarks"),
                                fscMarks = reader.GetInt32("FscMarks"),
                                testMarks = reader.GetInt32("ATMarks"),
                                aggregate = reader.GetInt32("Aggregate")
                            };

                            studentList.Add(student);
                        }
                    }
                }
            }

            return studentList;
        }

        public static Student FindStudentByID(int sID)
        {

            DotNetEnv.Env.Load();
            string ConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
            
            using (MySqlConnection Connection = new MySqlConnection(ConnectionString))
            {
                Connection.Open();
                string query = "Select * from Students where StudentID = @sID";
                using (MySqlCommand command = new MySqlCommand(query, Connection))
                {
                    command.Parameters.AddWithValue("@sID", sID);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            return new Student
                            {
                                studentID = reader.GetInt32("StudentID"),
                                studentName = reader.GetString("StudentName"),
                                fatherName = reader.GetString("FatherName"),
                                cnic = reader.GetString("CNIC"),
                                matricMarks = reader.GetInt32("MatricMarks"),
                                fscMarks = reader.GetInt32("FscMarks"),
                                testMarks = reader.GetInt32("ATMarks"),
                                aggregate = reader.GetInt32("Aggregate")
                            };
                        }
                    }
                }
            }

            return null;
        }
    }
}