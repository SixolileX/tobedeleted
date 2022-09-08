using System.ComponentModel.DataAnnotations;

namespace Inn_TuneProject.Models
{
    public class Subjects
    {
        [Key]
        public int SubID { get; set; }
        [Required]
        [Display(Name =" Department ")]
        public Departments Department { get; set; }
        [Required]
        public string Subject { get; set; }

    }
}