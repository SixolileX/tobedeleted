using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inn_TuneProject.Models
{
    public class HOD
    {
        [Key]
        public User HID { get; set; }
        [Required]
        public Subjects Subject { get; set; }
        [Required]
        public Grades Grade { get; set; }
        [Required]
        public UploadStaff Content { get; set; }
        [Required]
        public Reports Report { get; set; }
    }
}
