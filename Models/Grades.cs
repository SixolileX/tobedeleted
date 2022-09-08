using System.ComponentModel.DataAnnotations;

namespace Inn_TuneProject.Models
{
    public class Grades
    {
        [Key]
        public int GrID { get; set; }
        [Required]
        public string Grade { get; set; }
    }
}