using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class Announcements
    {
        [Key]
        public int AnnounceID { get; set; }
        [Required]
        [DisplayName("Announcement Name")]
        public string AnnouncementName { get; set; }
        [Required]
        [DisplayName("Announcement Description")]
        public string AnnouncementDescr { get; set; }
        [Required]
        [DisplayName("Announcement Date")]
        public DateTime AnnounceDate { get; set; }
    }
}
