using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class Attendance
    {
        [Key]
        public int AttendanceID { get; set; }
        [Required]
        public string Desc { get; set; }
        public DateTime Date { get; set; }
    }
}
