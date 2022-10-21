using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public class MyHODReport
    {
        public DepartmentHOD DepartmentHOD { get; set; }
        public AssignSubjectGrade AssignSubjectGrade { get; set; }
        public Department Department { get; set; }
        public HODs HODs { get; set; }
        public HodDisplay HodDisplay { get; set; }
        public AssignTeachersToGradeSubDisplay assignTeachers { get; set; }
        public ApplicationUser User { get; set; }
        public AssignMarks AssignMarks { get; set; }
        public Marks Marks { get; set; }
        public Subject Subject { get; set; }
        public Grade Grade { get; set; }
    }
}
