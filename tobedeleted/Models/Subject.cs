using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lies.Models
{
    public class Subject
    {
        [Key]
        public int SubID { get; set; }
        //[Required]
        //[Display(Name = "Department ")]
        //public Department DepDesc { get; set; }
        [Required]
        public string SubDesc { get; set; }

    }
}
