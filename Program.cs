using MySql.Data.MySqlClient;
using UAMS.Models;
using UAMS.UserInterface;
using UAMS.Utilities;


namespace UAMS
{
    class Program
    {
        static void Main(string[] args)
        {
            Degree d = DegreeUI.TakeInputForDegree();
            DegreeUI.PrintDegreeInfo(d);
        }
    }
}