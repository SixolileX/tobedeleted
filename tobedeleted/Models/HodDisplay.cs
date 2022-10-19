using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class HodDisplay
    {
        public HOD HOD { get; set; }
        public Department Department {get;set;}
        public Subject Subject { get; set; }
        public Grade Grade { get; set; }
        public AssignTeachersToGradeSubDisplay assignTeachers { get; set; }
        public AssignSubjectGrade AssignSubjectGrade { get; set; }
        public ApplicationUser user { get; set; }
    }
}
