using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class DisplayTimetable
    {
        public Assignment assignment { get; set; }
        public Subject subject { get; set; }
        public Grade grade { get; set; }
        public Department department { get; set; }

    }
}
