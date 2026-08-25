using MySql.Data.MySqlClient;

namespace UAMS.Models
{
   public class Subject
    {
        private int SubjectID {get; set;}
        private string SubjectName {get; set;}
        private string CreditHours {get; set;}

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

        public string creditHours
        {
            get { return CreditHours; }
            set { CreditHours = value; }
        }
    }
}