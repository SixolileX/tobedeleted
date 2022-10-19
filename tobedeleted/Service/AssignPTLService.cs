using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tobedeleted.Data;
using tobedeleted.IService;
using tobedeleted.Models;

namespace tobedeleted.Service
{
    public class AssignPTLService : IAssignPTL
    {
        private readonly ApplicationDbContext _context;

        public AssignPTLService(ApplicationDbContext context)
        {
            _context = context;
        }


        public AssignLearnerToParent AddToParentAsync(AssignLearnerToParent assign, string userParent, string userLearnerId)
        {
            assign = new AssignLearnerToParent();
            assign.userParent = userParent;
            assign.userLearnerId = userLearnerId;

            _context.AssignLearnerToParent.Add(assign);
            _context.SaveChangesAsync();
            return assign;
        }
        public AssignLearnerToParent savedParent => _context.AssignLearnerToParent.SingleOrDefault();

        public AssignLearnerToParent Save(AssignLearnerToParent assign)
        {
            _context.AssignLearnerToParent.Add(assign);
            _context.SaveChanges();
            return assign;
        }
    }
}
