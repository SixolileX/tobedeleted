using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class EnrollStudent
    {

        [Key]
        public int EnrollID { get; set; }
        public DateTime EnrollDate { get; set; }
        public string SubjectID { get; set; }
        public string StudentID { get; set; }

     



    }
}
