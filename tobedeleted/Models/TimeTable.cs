using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class TimeTable
    {
        [Key]
        public int TtID { get; set; }
        [Required]
        public DateTimeOffset ExamDate { get; set; }
        [Required]
        public int Exam {get;set;}
        [Required]
        public int DepID { get; set; }
        [Required]
        public int Subject { get; set; }
        [Required]
        public int GradeID { get; set; }

    }
}
