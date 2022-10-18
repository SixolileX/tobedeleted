using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace tobedeleted.Models
{
    public class Studentmaster
    {
        [Display(Name ="Exam")]
        public int ExamID { get; set; }
        [Display(Name = "Subject")]
        public int SubID { get; set; }
        public IEnumerable<SelectList> ListOfExams { get; set; }
        public IEnumerable<SelectList> ListOfSubjects { get; set; }
    }
}
