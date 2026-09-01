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

        public static List<User> LoadAllUsersFromDataBase(User s)
        {
            List<User> userList = new List<User>();

            DotNetEnv.Env.Load();
            string ConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
            
            using (MySqlConnection Connection = new MySqlConnection(ConnectionString))
            {
                Connection.Open();
                string query = "Select * from Users";
                using (MySqlCommand command = new MySqlCommand(query, Connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            User user = new User
                            {
                                userID = reader.GetInt32("UserID"),
                                username = reader.GetString("Username"),
                                password = reader.GetString("Password"),
                                role = reader.GetString("Role"),
                            };

                            userList.Add(user);
                        }
                    }
                }
            }

            return userList;
        }

        public static User FindUserByID(int uID)
        {

            DotNetEnv.Env.Load();
            string ConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
            
            using (MySqlConnection Connection = new MySqlConnection(ConnectionString))
            {
                Connection.Open();
                string query = "Select * from Users where UserID = @uID";
                using (MySqlCommand command = new MySqlCommand(query, Connection))
                {
                    command.Parameters.AddWithValue("@uID", uID);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            return new User
                            {
                                userID = reader.GetInt32("UserID"),
                                username = reader.GetString("Username"),
                                password = reader.GetString("Password"),
                                role = reader.GetString("Role")
                            };
                        }
                    }
                }
            }

            return null;
        }
    }
}