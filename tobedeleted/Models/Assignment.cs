using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class Assignment
    {
        [Key]
        public int AssignID { get; set; }
        public string AssignTitle { get; set; }
        public string AssignType { get; set; }
        public string AssignInstructions { get; set; }
        public string DueDate { get; set; }
    }
}
