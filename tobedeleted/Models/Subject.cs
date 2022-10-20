using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class Subject
    {
        [Key]
        public int SubID { get; set; }
        //[Required]
        
        //public Department DepDesc { get; set; }
        [Required]
        public string SubDesc { get; set; }
        [Required]
        //[ForeignKey("Departments")]
        [Display(Name = "Department ")]
        public int DepID { get; set; }
        public byte[] SubImage { get; set; }
        //[Required]
        public string SubCode { get; set; }
        public int learnerId { get; set; }

        //public virtual Department Departments { get; set; }
    }
}
