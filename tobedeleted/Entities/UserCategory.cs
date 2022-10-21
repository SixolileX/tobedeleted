using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Entities
{
    public class UserCategory
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int CategoryId { get; set; }
    }
}
