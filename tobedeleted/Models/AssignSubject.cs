using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class AssignSubject
    {
        [Key]
        public int SubID { get; set; }
   
        public string SubDesc { get; set; }

        public string SubCode { get; set; }

    }
}
