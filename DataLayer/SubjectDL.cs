using MySql.Data.MySqlClient;
using UAMS.Models;
using UAMS.UserInterface;
using UAMS.Utilities;

namespace UAMS.DataLayer
{
    public class SubjectDL
    {
        public static void SaveSubjectToDataBase(Subject s)
        {
            DotNetEnv.Env.Load();
            string ConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
            
            using (MySqlConnection Connection = new MySqlConnection(ConnectionString))
            {
                Connection.Open();
                string query = "INSERT INTO Degree(SubjectName, CreditHours) Values (@SubjectName, @CreditHours)";
                using (MySqlCommand command = new MySqlCommand(query, Connection))
                {
                    command.Parameters.AddWithValue("@SubjectName", s.subjectName);
                    command.Parameters.AddWithValue("@CreditHours", s.creditHours);

                    command.ExecuteNonQuery();
                }
            }

            Console.WriteLine("Subject Added Successfully");
        }

        public static Subject FindSubjectByID(int sID)
        {

            DotNetEnv.Env.Load();
            string ConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
            
            using (MySqlConnection Connection = new MySqlConnection(ConnectionString))
            {
                Connection.Open();
                string query = "Select SubjectID, SubjectName, CreditHours from Subject where SubjectID = @sID";
                using (MySqlCommand command = new MySqlCommand(query, Connection))
                {
                    command.Parameters.AddWithValue("@sID", sID);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            return new Subject
                            {
                                subjectID = reader.GetInt32("SubjectID"),
                                subjectName = reader.GetString("SubjectName"),
                                creditHours = reader.GetInt32("CreditHours")
                            };
                        }
                    }
                }
            }

            return null;
        }

        public static List<Subject> FindSubjectsByDegreeID(int dID)
        {
            List<Subject> subList = new List<Subject>();
            DotNetEnv.Env.Load();
            string ConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
            
            using (MySqlConnection Connection = new MySqlConnection(ConnectionString))
            {
                Connection.Open();
                string query = "select s.SubjectID, s.SubjectName, s.CreditHours  from Subjects s, Degrees d WHERE s.DegreeID = @dID;";
                using (MySqlCommand command = new MySqlCommand(query, Connection))
                {
                    command.Parameters.AddWithValue("@dID", dID);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Subject sub = new Subject
                            {
                                subjectID = reader.GetInt32("SubjectID"),
                                subjectName = reader.GetString("SubjectName"),
                                creditHours = reader.GetInt32("CreditHours")
                            };

                            subList.Add(sub);
                        }
                    }
                }
            }

            return subList;
        }
    }
}