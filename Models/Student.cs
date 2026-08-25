using MySql.Data.MySqlClient;

namespace UAMS.Models
{
    public class Student
    {
        private int StudentID { get; set; }
        private string StudentName { get; set; }
        private string FatherName { get; set; }
        private int MatricMarks { get; set; }
        private int FscMarks { get; set; }
        private double Aggregate { get; set; }
        private string CNIC { get; set; }
        private Degree degree;
        private List<Degree> Preferences = new List<Degree>();
    }
}