using System.ComponentModel.DataAnnotations;

namespace tobedeleted.Models
{
    public class Marks
    {
        [Key]
        public int MarksId { get; set; }
        public int learnerId { get; set; }
        public int AssignmentID { get;set;}
        public int SubID { get; set; }
        public string Term1 { get; set; }
        public string Term2 { get; set; }
        public string Term3 { get; set; }
        public string Term4 { get; set; }
    }
}
