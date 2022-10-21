using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class StudentMasterView
    {
        [Display(Name ="Exam")]
        public int ExamId { get; set; }
        [Display(Name = "Subject")]
        public int SubID { get; set; }
        public IEnumerable<SelectListItem> ListOfExams { get; set; }
        public IEnumerable<SelectListItem> ListOfSubject { get; set; }
    }
}
