using MySql.Data.MySqlClient;
using UAMS.Models;
using UAMS.UserInterface;
using UAMS.Utilities;

namespace UAMS.Models
{
    public class User
    {
        private int UserID {get; set;}
        private string Username {get; set;}
        private string Password {get; set;}
        private string Role {get; set;}

        public int userID
        {
            get { return UserID; }
            set { UserID = value; }
        }

        public string username
        {
            get { return Username; }
            set { Username = value; }
        }

        public string password
        {
            get { return Password; }
            set { Password = value; }
        }

        public string role
        {
            get { return Role; }
            set { Role = value; }
        }

        public User(string Username, string Password, string Role) 
        {
            this.Username = Username;
            this.Password = Password;
            this.Role = Role;
        }

        public User()
        {
            
        }
    }
}