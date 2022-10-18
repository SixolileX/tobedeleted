using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tobedeleted.Data;
using tobedeleted.IService;
using tobedeleted.Models;

namespace tobedeleted.Service
{
    public class AssignSubGrade : IAssignSubGrade
    {
        private readonly ApplicationDbContext _context;

        public AssignSubGrade(ApplicationDbContext context)
        {
            _context = context;
        }

        public AssignSubjectGrade AssignedSubGrades => _context.SubsToGrade.OrderBy(o => o.SubGrID).LastOrDefault();

        public AssignSubjectGrade AssignSubjectGradeAsync(AssignSubjectGrade oSubGr, int grID, int subID)
        {
            oSubGr = new AssignSubjectGrade();
            oSubGr.GrID = grID;
            oSubGr.SubId = subID;

            _context.SubsToGrade.Add(oSubGr);
            _context.SaveChangesAsync();
            return oSubGr;
        }

        public AssignSubjectGrade Save(AssignSubjectGrade oSubGr)
        {
            _context.SubsToGrade.Add(oSubGr);
            _context.SaveChanges();
            return oSubGr;
        }
        public AssignSubjectGrade Update(AssignSubjectGrade oSubGr)
        {
            _context.SubsToGrade.Update(oSubGr);
            _context.SaveChanges();
            return oSubGr;
        }
        public AssignSubjectGrade Delete(AssignSubjectGrade oSubGr)
        {
            _context.SubsToGrade.Remove(oSubGr);
            _context.SaveChanges();
            return oSubGr;
        }
    }
}
