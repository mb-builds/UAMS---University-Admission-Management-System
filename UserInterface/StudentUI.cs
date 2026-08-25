using MySql.Data.MySqlClient;
using UAMS.Models;

namespace UAMS.UserInterface
{
    public class StudentUI
    {
        public static Student TakeInputForStudent()
        {
            EnterInfo("Name");
            string StudentName = Console.ReadLine();
            EnterInfo("Father's name");
            string FatherName = Console.ReadLine();
            EnterInfo("CNIC");
            string CNIC = Console.ReadLine();
            EnterInfo("Matric Marks");
            int MatricMarks = ReadInt();
            EnterInfo("Fsc Marks");
            int FscMarks = ReadInt();
            EnterInfo("Test Marks");
            int TestMarks = ReadInt();

            return new Student(StudentName, FatherName, CNIC, MatricMarks, FscMarks, TestMarks);
            
        }
        public static void EnterInfo(string text)
        {
            Console.WriteLine($"Enter {text} : ");
        }

        public static int ReadInt()
        {
            int num = int.Parse(Console.ReadLine());
            return num;
        }

        public static void PrintStudent(Student s)
        {
            Console.WriteLine($"{s.studentID} {s.studentName} {s.fatherName} {s.cnic} {s.matricMarks} {s.fscMarks} {s.testMarks} {s.aggregate}");
        }

    }
}