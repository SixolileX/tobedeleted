using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class UserActivity
    {
            public int ID { get; set; }
            public string Url { get; set; }
            public string Data { get; set; }
            public string UserName { get; set; }
            public string IpAddress { get; set; }
            public DateTime ActivityDate { get; set; } = DateTime.Now;
        
    }
}
