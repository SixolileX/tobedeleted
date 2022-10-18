using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class AssignSubjectGrade
    {
        [Key]
        public int SubGrID { get; set; }
        [Required]
        public int GrID { get; set; }
        [Required]
        public int SubId { get; set; }
        [Required]
        public string userTeacher { get; set; }
    }
}
