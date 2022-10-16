using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class UserHOD
    {
        //[Key]
        public int uHoDId { get; set; }
        //[Required]
        public string userID { get; set; }
        //[Required]
        public int depID { get; set; }
    }
}
