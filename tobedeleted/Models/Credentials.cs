using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class Credentials: IdentityUser
    {
#pragma warning disable CS0114 // Member hides inherited member; missing override keyword
        public string Email { get; set; }
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword
        public string Password { get; set; }
    }
}
