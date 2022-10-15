using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class Assignment
    {
        [Key]
        public int AssignmentID { get; set; }
        public string AssignmentTitle { get; set; }
        public string AssignmentType { get; set; }
        public string AssignmentInstructions { get; set; }
        public string AssignmentDueDate { get; set; }
    }
}
