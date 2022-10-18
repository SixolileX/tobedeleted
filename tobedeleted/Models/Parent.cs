using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class Parent
    {
        [Key]
        public int Parentid { get; set; }
        [Required]
        public string userParentId { get; set; }
        [Required]
        public string userLearnerId { get; set; }




    }
}
