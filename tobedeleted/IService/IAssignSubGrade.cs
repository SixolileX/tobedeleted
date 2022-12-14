using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tobedeleted.Models;

namespace tobedeleted.IService
{
    public interface IAssignSubGrade
    {
        AssignSubjectGrade AssignSubjectGradeAsync(AssignSubjectGrade oSubGr, int grID, int subID, string teacherID);
        AssignSubjectGrade Save(AssignSubjectGrade oSubGr);
        AssignSubjectGrade Update(AssignSubjectGrade oSubGr);
        AssignSubjectGrade Delete(AssignSubjectGrade oSubGr);
        AssignSubjectGrade AssignedSubGrades { get; }

        
    }
}
