using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class TimetableDisplay
    {
        [Key]
        public int TtID { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        [DisplayName("Exam Date")]
        public DateTime ExamDate { get; set; }
        [DataType(DataType.Date)]
        [Required]
        [DisplayName("Set Date")]
        public DateTime Date { get; set; }
        [DisplayName("Assignment Instruction")]
        public string AssignmentInstructions { get; set; }
        [DisplayName("Department Name")]
        public string DepDesc { get; set; }
        [DisplayName("Subject Name")]
        public string SubDesc { get; set; }
        [DisplayName("Grade")]
        public string GrDesc { get; set; }
    }
}
