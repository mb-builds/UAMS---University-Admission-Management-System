using MySql.Data.MySqlClient;
using UAMS.Models;
using UAMS.UserInterface;
using UAMS.Utilities;

namespace UAMS.UserInterface
{
    public class SubjectUI
    {
        public static Subject TakeInputForSubjects()
        {
            while(true)
            {
                Helper.EnterInfo("Subject Name");
                string SubjectName = Console.ReadLine();
                Helper.EnterInfo("Credit Hours");
                int CreditHours = Helper.ReadInt();

                if(CreditHours > 3 )
                {
                    Console.WriteLine("Credit Hours can't be more than 3");
                    continue;
                }

                return new Subject(SubjectName, CreditHours);
            }
        }

        public static void PrintSubject(Subject subject)
        {
            Console.Write($"{subject.subjectName} {subject.creditHours} ");
        }

        public static void PrintAllSubjects(List<Subject> subList)
        {
            foreach(var sub in subList)
            {
                PrintSubject(sub);
            }
        }
    }
}