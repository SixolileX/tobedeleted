using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class Calculator
    {

        [Key]
        public int Term1 { get; set; }
        public int Term2 { get; set; }
        public int Term3 { get; set; }
        public int Term4 { get; set; }
        public int Total { get; set; }
        public int avg { get; set; }
        public string Grade { get; set; }

    }
}
