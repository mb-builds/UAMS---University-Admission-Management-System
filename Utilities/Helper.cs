using MySql.Data.MySqlClient;
using UAMS.Models;
using UAMS.UserInterface;
using UAMS.Utilities;


namespace UAMS.Utilities
{
    public class Helper
    {
        public static void EnterInfo(string text)
        {
            Console.Write($"Enter {text} : ");
        }

        public static int ReadInt()
        {
            int num = int.Parse(Console.ReadLine());
            return num;
        }
    }
}