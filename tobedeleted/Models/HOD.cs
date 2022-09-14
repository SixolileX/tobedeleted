using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class HOD
    {
        [Key]
        public int HID { get; set; }
        [Required]
        public Subject Subject { get; set; }
        [Required]
        public Grade Grade { get; set; }
        //[Required]
        //public UploadStaff Content { get; set; }
        //[Required]
        //public Reporrt Report { get; set; }
    }
}
