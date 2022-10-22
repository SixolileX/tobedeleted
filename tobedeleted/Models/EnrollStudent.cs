using Microsoft.AspNetCore.Mvc;
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
        [Required]
        public DateTime EnrollDate { get; set; }
        [Required]
        public int SubjectID { get; set; }
        [Required]
        public string StudentID { get; set; }
       

       


    }
}
