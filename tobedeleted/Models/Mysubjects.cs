//using tobedeleted.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class Mysubjects
    {
        public int mysubId { get; set; }
        public EnrollStudent EnrollStu { get; set; }
        public Subject SubjectM { get; set; }
        
    }
}
