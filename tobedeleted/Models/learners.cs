using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class learners
    {
        [Key]
         public int LeanerId { get; set; }
        [Required] 
        public string UserlearnerId { get;set }
        [Required]
        public string SubjectName { get; set; }
    }
}
