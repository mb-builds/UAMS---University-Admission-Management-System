using MySql.Data.MySqlClient;

namespace UAMS.Models
{
   public class Subject
    {
        private int SubjectID {get; set;}
        private string SubjectName {get; set;}
        private string CreditHours {get; set;}
    }
}