using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class MeetingScheduler
    {
        [Key]
        public int MeetingID { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime Date { get; set; }
        public string Desc { get; set; }
        
    }
}
