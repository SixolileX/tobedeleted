using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class MailMessage
    {
        [Key]
        public int EmailID { get; set; }
        [Required]
        public string To { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
