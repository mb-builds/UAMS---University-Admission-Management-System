using MySql.Data.MySqlClient;

namespace UAMS.Models
{
    public class Degree
    {
        private int DegreeID {get; set;}
        private string DegreeName {get; set;}
        private int MaxCreditHours {get; set;}
        private List<Subject> Subjects = new List<Subject>();

    }
}