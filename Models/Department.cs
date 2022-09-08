using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inn_TuneProject.Models
{
    public class Departments
    {
        [Key]
        public int DepID { get; set; }
        [Required]
        public string Department { get; set; }
        public  Subjects Subject { get; set; }
    }
}
