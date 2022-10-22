using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class DisplayMeeting
    {
        public ApplicationUser applicationUser { get; set; }
        public MeetingScheduler meetingScheduler { get; set; }
    }
}
