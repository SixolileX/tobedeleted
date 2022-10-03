using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Set Date")]
        public DateTime Date { get; set; }
        [DisplayName("Meeting Description")]
        public string Desc { get; set; }
        
    }
}
