using System.Transactions;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.IsisMtt.X509;
using UAMS.Models;
using UAMS.UserInterface;
using UAMS.Utilities;
using UAMS.DataLayer;

namespace UAMS.UserInterface
{
    public class UserUI
    {
        public static User TakeInputForUser()
        {
            int choice = SignInChoice();
            Helper.EnterInfo("Username");
            string Username = Console.ReadLine();
            Helper.EnterInfo("Password");
            string Password = Console.ReadLine();

            string Role = "Student";

            if(choice == 1)
            {
                Role = "Admin";
                return new User(Username, Password, Role);
            }

            return new User(Username, Password, Role);
        }

        public static void UserLoginMenu()
        {
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. Student");
            Console.Write("Choose an option: ");
        }

        public static int SignInChoice()
        {
            int choice = 0;
            bool check = false;
            while(!check)
            {
                choice = Helper.ReadInt();
                if(choice == 1 || choice == 2)
                {
                    check = true;
                }
                else
                Console.WriteLine("Invalid choice");
            }

            return choice;
        }

        // Login Pending
        public static void SignIn()  // pending validation
        {
            UserLoginMenu();
            User u = TakeInputForUser();
            UserDL.SaveUserToDataBase(u);
        }
    }
}