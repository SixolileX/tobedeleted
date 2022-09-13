using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lies.Models
{
    public class Department
    {
        [Key]
        public int DepID { get; set; }
        [Required]
        public string DepDesc { get; set; }
        //public Subject Subject { get; set; }
    }
}
