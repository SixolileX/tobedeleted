using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class studentMeeting
    {
        [Key]
        public int LearnerMeetingID { get; set; }
        [Required]
        [DisplayName("Set Date")]
        public DateTime setdate { get; set; }
        [Required]
        [DisplayName("Meeting Description")]
        public string Meetingdesc { get; set; }
    }
}
