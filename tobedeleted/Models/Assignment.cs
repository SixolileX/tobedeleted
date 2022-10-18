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
        [Required]
        public int AssignmentID { get; set; }
        [Required]
        public string AssignmentTitle { get; set; }
        [Required]
        public string AssignmentType { get; set; }
        [Required]
        public string AssignmentInstructions { get; set; }
        //[Required]
        //public byte[] Attachment { get; set; }
        public DateTime AssignmentDueDate { get; set; }
    }
}
