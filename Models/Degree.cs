using MySql.Data.MySqlClient;

namespace UAMS.Models
{
    public class Degree
    {
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

    }
}