using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class Questions
    {
        [Key]
        public int QuestionId { get; set; }
        public int CategoryId { get; set; }
        public string QuestionName { get; set; }
        public Boolean isMultiple { get; set; }
        public Boolean isActive { get; set; }
        
    }
}
