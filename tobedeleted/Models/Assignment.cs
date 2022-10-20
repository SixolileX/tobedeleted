using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Assignment Title ")]
        public string AssignmentTitle { get; set; }
        [Required]
        [DisplayName("Assignment Type ")]
        public string AssignmentType { get; set; }
        [Required]
        [DisplayName("Assignment Instructions ")]
        public string AssignmentInstructions { get; set; }
        //[Required]
        //public byte[] Attachment { get; set; }
        [DisplayName("Assignment Due Date ")]
        public DateTime AssignmentDueDate { get; set; }
    }
}
