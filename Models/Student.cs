using MySql.Data.MySqlClient;
using UAMS.Models;
using UAMS.UserInterface;
using UAMS.Utilities;

namespace UAMS.Models
{
    public class Student
    {
        public static List<Student> AllStudents = new List<Student>();
        private int StudentID { get; set; }
        private string StudentName { get; set; }
        private string FatherName { get; set; }
        private int MatricMarks { get; set; }
        private int FscMarks { get; set; }
        private int TestMarks {get; set;}
        private double Aggregate { get; set; }
        private string CNIC { get; set; }
        private Degree degree;
        private List<Degree> Preferences = new List<Degree>();

        public int studentID
        {
            get { return StudentID; }
            set { StudentID = value; }
        }

        public string studentName
        {
            get { return StudentName; }
            set { StudentName = value; }
        }

        public string fatherName
        {
            get { return FatherName; }
            set { FatherName = value; }
        }

        public string cnic
        {
            get { return CNIC; }
            set { CNIC = value; }
        }

        public int matricMarks
        {
            get { return MatricMarks; }
            set { MatricMarks = value; }
        }

        public int fscMarks
        {
            get { return FscMarks; }
            set { FscMarks = value; }
        }

        public int testMarks
        {
            get { return TestMarks; }
            set { TestMarks = value; }
        }

        public double aggregate
        {
            get { return Aggregate; }
            set { Aggregate = value; }
        }

        public Degree degreee
        {
            get { return degree; }
            set { degree = value; }
        }

        public List<Degree> preferences
        {
            get { return Preferences; }
            set { Preferences = value; }
        }

        public Student(string StudentName, string FatherName, string CNIC, int MatricMarks, int FscMarks, int TestMarks)
        {
            this.StudentName = StudentName;
            this.FatherName = FatherName;
            this.CNIC = CNIC;
            this.MatricMarks = MatricMarks;
            this.FscMarks = FscMarks;
            this.TestMarks = TestMarks;
            Aggregate = CalcAgg(MatricMarks, FscMarks, TestMarks);
        }
        public Student(string StudentName, string FatherName, string CNIC, int MatricMarks, int FscMarks, int TestMarks, Degree degree, List<Degree> Preferences)
        {
            this.StudentName = StudentName;
            this.FatherName = FatherName;
            this.CNIC = CNIC;
            this.MatricMarks = MatricMarks;
            this.FscMarks = FscMarks;
            this.TestMarks = TestMarks;
            Aggregate = CalcAgg(MatricMarks, FscMarks, TestMarks);
            this.degree = degree;
            this.Preferences = Preferences;

        }

        public static double CalcAgg(int Matric, int FSC, int Test)
        {
            double Aggregate = (0.17 * ((Matric/1100)* 100)) + (0.50 * ((FSC/1200)* 100)) + (0.33 * ((Test/400)* 100));
            return Aggregate;
        }
    }
}