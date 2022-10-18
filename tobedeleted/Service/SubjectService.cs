using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tobedeleted.Data;
using tobedeleted.IService;
using tobedeleted.Models;

namespace tobedeleted.Service
{
    public class SubjectService : ISubjectService
    {
        private readonly ApplicationDbContext _context;
        public SubjectService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Subject GetSavedSubject()
        {
            return _context.Subjects.OrderBy(o => o.SubID).LastOrDefault();

        }

        public Subject Save(Subject oSubject)
        {
            _context.Subjects.Add(oSubject);
            _context.SaveChanges();
            return oSubject;
        }

        public Subject Update(Subject oSubject)
        {
            _context.Subjects.Update(oSubject);
            _context.SaveChanges();
            return oSubject;
        }
        public Subject Delete(Subject oSubject)
        {
            _context.Subjects.Remove(oSubject);
            _context.SaveChanges();
            return oSubject;
        }
    }
}
