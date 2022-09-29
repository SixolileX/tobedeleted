using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class Subject
    {
        public class Dropdownlist

        {

            public List<SubDep> subDeps { get; set; }

        }
        [Key]
        public int SubID { get; set; }
        //[Required]
        //[Display(Name = "Department ")]
        //public Department DepDesc { get; set; }
        [Required]
        public string SubDesc { get; set; }


    }
}  
