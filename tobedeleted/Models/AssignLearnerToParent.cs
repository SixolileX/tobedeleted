using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class AssignLearnerToParent
    {
        public int id { get; set; }
        public string userParent { get; set; }
        public string userLearnerId { get; set; }
    }
}
