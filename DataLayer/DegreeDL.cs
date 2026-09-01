using MySql.Data.MySqlClient;
using UAMS.Models;
using UAMS.UserInterface;
using UAMS.Utilities;

namespace UAMS.DataLayer
{
    public class DegreeDL
    {
        public static void SaveDegreeToDataBase(Degree d)
        {
            DotNetEnv.Env.Load();
            string ConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
            
            using (MySqlConnection Connection = new MySqlConnection(ConnectionString))
            {
                Connection.Open();
                string query = "INSERT INTO Degree(DegreeName, MaxCreditHours) Values (@DegreeName, @MaxCreditHours)";
                using (MySqlCommand command = new MySqlCommand(query, Connection))
                {
                    command.Parameters.AddWithValue("@DegreeName", d.degreeName);
                    command.Parameters.AddWithValue("@MaxCreditHours", d.maxCreditHours);

                    command.ExecuteNonQuery();
                }
            }

            Console.WriteLine("Degree Added Successfully");
        }

        public static List<Degree> LoadAllDegreesFromDataBase()
        {
            List<Degree> degList = new List<Degree>();
            DotNetEnv.Env.Load();
            string ConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
            
            using (MySqlConnection Connection = new MySqlConnection(ConnectionString))
            {
                Connection.Open();
                string query = "select * from Degrees";
                using (MySqlCommand command = new MySqlCommand(query, Connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Degree d = new Degree
                            {
                                degreeID = reader.GetInt32("DegreeID"),
                                degreeName = reader.GetString("DegreeName"),
                                maxCreditHours = reader.GetInt32("MaxCreditHours")
                            };

                            degList.Add(d);
                        }
                    }
                }
            }

            return degList;
        }

        public static Degree FindDegreeByID(int dID)
        {

            DotNetEnv.Env.Load();
            string ConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
            
            using (MySqlConnection Connection = new MySqlConnection(ConnectionString))
            {
                Connection.Open();
                string query = "Select * from Degrees where DegreeID = @dID";
                using (MySqlCommand command = new MySqlCommand(query, Connection))
                {
                    command.Parameters.AddWithValue("@dID", dID);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            return new Degree
                            {
                                degreeID = reader.GetInt32("DegreeID"),
                                degreeName = reader.GetString("DegreeName"),
                                maxCreditHours = reader.GetInt32("MaxCreditHours")
                            };
                        }
                    }
                }
            }

            return null;
        }
    }
}