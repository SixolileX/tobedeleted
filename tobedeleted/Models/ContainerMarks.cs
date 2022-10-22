using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class ContainerMarks
    {
        public StuMark stuMark { get; set; }
        public AssignLearnerToParent assignLearner { get; set; }
        public Grade grade { get; set; }
        public ApplicationUser applicationUser { get; set; }
        public Subject subject { get; set; }
    }
}
