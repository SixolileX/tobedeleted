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
        [DataType(DataType.Date)]
        [Required]
        [DisplayName("Set Date")]
        public DateTime SetDate { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime MeetingDate { get; set; }
        [Required]
        [DisplayName("Meeting Description")]
        public string Desc { get; set; }
        public string userID { get; set; }
        
    }
}
