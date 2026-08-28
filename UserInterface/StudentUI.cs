using MySql.Data.MySqlClient;
using UAMS.Models;
using UAMS.UserInterface;
using UAMS.Utilities;

namespace UAMS.UserInterface
{
    public class StudentUI
    {
        public static Student TakeInputForStudent()
        {
            Helper.EnterInfo("Name");
            string StudentName = Console.ReadLine();
            Helper.EnterInfo("Father's name");
            string FatherName = Console.ReadLine();
            Helper.EnterInfo("CNIC");
            string CNIC = Console.ReadLine();
            Helper.EnterInfo("Matric Marks");
            int MatricMarks = Helper.ReadInt();
            Helper.EnterInfo("Fsc Marks");
            int FscMarks = Helper.ReadInt();
            Helper.EnterInfo("Test Marks");
            int TestMarks = Helper.ReadInt();

            return new Student(StudentName, FatherName, CNIC, MatricMarks, FscMarks, TestMarks);
        }

        public static void PrintStudent(Student s)
        {
            Console.WriteLine($"{s.studentID} {s.studentName} {s.fatherName} {s.cnic} {s.matricMarks} {s.fscMarks} {s.testMarks} {s.aggregate}");
        }

        public static void PrintAllStudents()
        {
            foreach(var s in Student.AllStudents)
            {
                PrintStudent(s);
            }
        }

    }
}