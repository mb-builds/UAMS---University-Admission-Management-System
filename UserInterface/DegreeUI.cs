using MySql.Data.MySqlClient;
using UAMS.Models;
using UAMS.UserInterface;
using UAMS.Utilities;


namespace UAMS.UserInterface
{
    public class DegreeUI
    {
        // Pending Validation
       public static Degree TakeInputForDegree()
       {
            Helper.EnterInfo("Degree Name");
            string DegreeName = Console.ReadLine();
            Helper.EnterInfo("Max Credit Hours");
            int MaxCreditHours = Helper.ReadInt();

            List<Subject> subList = new List<Subject>();
            int TotalCreditHours = 0;
            bool creditHoursCheck = TotalCreditHours < MaxCreditHours;

            Helper.EnterInfo("number of subjects you want to add");
            int numOfSubjects = Helper.ReadInt();

            for(int i=0; i<numOfSubjects; i++)
            {
                Subject sub = SubjectUI.TakeInputForSubjects();
                subList.Add(sub);
            }

            return new Degree(DegreeName, MaxCreditHours, subList);
       }

        public static void PrintDegreeInfo(Degree degree)
        {
            Console.Write($"{degree.degreeName} {degree.maxCreditHours}\nSubjects: ");
            SubjectUI.PrintAllSubjects(degree.subjects);
        }

        public static void PrintAllDegrees()
        {
            foreach(var deg in Degree.AllDegrees)
            {
                PrintDegreeInfo(deg);
            }
        }
    }
}