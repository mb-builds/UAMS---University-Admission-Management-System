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
    }
}