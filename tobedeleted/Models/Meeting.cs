using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class Meeting
    {
        [Key]
        public int MettingID { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime Date { get; set; }
    }
}
