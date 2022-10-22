using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class Exams
    {
        [Key]
        public int calId { get; set; }
        [Required]
        public int Term1 { get; set; }
        [Required]
        public int Term2 { get; set; }
        [Required]
        public int Term3 { get; set; }
        [Required]
        public int Term4 { get; set; }
        [Required]
        public int Total { get; set; }
        public double avg { get; set; }
        public string Grade { get; set; }
    }
}
