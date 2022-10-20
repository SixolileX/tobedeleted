using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class HODs
    {
        [Key]
        public int HoDId { get; set; }
        [Required]
        public string userHoDId { get; set; }
        [Required]
        public int DepID { get; set; }
        //[Required]
        //public string RoleName { get; set; }
        //[Required]
        //public string UserId { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<Department> Departments { get; set; }

        //[Required]
        //public UploadStaff Content { get; set; }
        //[Required]
        //public Reporrt Report { get; set; }
    }
}
