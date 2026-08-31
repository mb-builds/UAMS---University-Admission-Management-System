using MySql.Data.MySqlClient;
using UAMS.Models;
using UAMS.UserInterface;
using UAMS.Utilities;

namespace UAMS.DataLayer
{
    public class UserDL
    {
        public static void SaveUserToDataBase(User u)
        {
            DotNetEnv.Env.Load();
            string ConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
            
            using (MySqlConnection Connection = new MySqlConnection(ConnectionString))
            {
                Connection.Open();
                string query = "INSERT INTO Users(Username, Password, Role) Values (@Username, @Password, @Role)";
                using (MySqlCommand command = new MySqlCommand(query, Connection))
                {
                    command.Parameters.AddWithValue("@Username", u.username);
                    command.Parameters.AddWithValue("@Password", u.password);
                    command.Parameters.AddWithValue("@Role", u.role);

                    command.ExecuteNonQuery();
                }
            }

            Console.WriteLine("User Added Successfully");
        }
    }
}