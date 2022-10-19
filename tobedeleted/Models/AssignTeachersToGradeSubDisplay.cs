using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class AssignTeachersToGradeSubDisplay
    {
        public AssignSubjectGrade AssignSubjectGrade { get; set; }
        public Subject Subject { get; set; }
        public Grade Grade { get; set; }
        public ApplicationUser applicationUser { get; set; }
    }
}
