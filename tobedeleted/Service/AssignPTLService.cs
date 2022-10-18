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


        public Parent AddToParentAsync(Parent parent, string userParentId, string userLearnerId)
        {
            parent = new Parent();
            parent.userParentId = userParentId;
            parent.userLearnerId = userLearnerId;

            _context.Parent.Add(parent);
            _context.SaveChangesAsync();
            return parent;
        }
        //public Parent savedParent => _context.Parent.OrderBy(o => o.Parentid).LastOrDefault();
        public Parent savedParent => _context.Parent.SingleOrDefault();

        public Parent Save(Parent parent)
        {
            _context.Parent.Add(parent);
            _context.SaveChanges();
            return parent;
        }
    }
}
