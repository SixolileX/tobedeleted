using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class AssignMarks
    {
        public Subject subject { get; set; }

        public Marks marks { get; set; }
        public Learner learner { get; set; }
        public StuMark stuMark { get; set; }
    }
}
