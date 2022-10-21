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
        public int ExamId { get; set; }
        public string ExamName { get; set; }
    }
}
