using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class Department
    {
        [Key]
        public int DepID { get; set; }
        [Required]
        public string DepDesc { get; set; }
        //[Required]
        public byte[] DepPhoto { get; set; }
        //public Subject Subject { get; set; }
        public List<Subject> Subjects { get; set; } 

    }
}
