using MySql.Data.MySqlClient;

namespace UAMS.Models
{
   public class Subject
    {
        private int SubjectID {get; set;}
        private string SubjectName {get; set;}
        private int CreditHours {get; set;}

        public int subjectID
        {
            get { return SubjectID; }
            set { SubjectID = value; }
        }

        public string subjectName
        {
            get { return SubjectName; }
            set { SubjectName = value; }
        }

        public int creditHours
        {
            get { return CreditHours; }
            set { CreditHours = value; }
        }

        public Subject(string SubjectName, int CreditHours)
        {
            this.SubjectName = SubjectName;
            this.CreditHours = CreditHours;
        }
    }
}