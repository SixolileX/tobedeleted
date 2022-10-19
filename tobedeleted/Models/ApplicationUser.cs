using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        //public string email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Boolean Gender { get; set; }
        public string Addressline1 { get; set; }
        public string Addressline2 { get; set; }
        public string contactNo { get; set; }

    }
}
