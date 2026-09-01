using MySql.Data.MySqlClient;
using UAMS.Models;
using UAMS.UserInterface;
using UAMS.Utilities;


namespace UAMS.Models
{
    public class Degree
    {
        public static List<Degree> AllDegrees = new List<Degree>();
        private int DegreeID {get; set;}
        private string DegreeName {get; set;}
        private int MaxCreditHours {get; set;}
        private List<Subject> Subjects = new List<Subject>();

        public int degreeID
        {
            get { return degreeID; }
            set { degreeID = value; }
        }

        public string degreeName
        {
            get { return DegreeName; }
            set { DegreeName = value; }
        }

        public int maxCreditHours
        {
            get { return MaxCreditHours; }
            set { MaxCreditHours = value; }
        }

        public List<Subject> subjects
        {
            get { return Subjects; }
            set { Subjects = value; }
        }

        public Degree(string DegreeName, int MaxCreditHours, List<Subject> Subjects)
        {
            this.DegreeName = DegreeName;
            this.MaxCreditHours = MaxCreditHours;
            this.Subjects = Subjects;
        }

        public Degree()
        {
            
        }

    }
}