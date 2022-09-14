using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class Grade
    {
        [Key]
        public int GrID { get; set; }
        [Required]
        public string GrDesc { get; set; }
    }
}
