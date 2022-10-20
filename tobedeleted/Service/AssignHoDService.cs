using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tobedeleted.Data;
using tobedeleted.IService;
using tobedeleted.Models;

namespace tobedeleted.Service
{
    public class AssignHoDService : IAssignHOD
    {
        private readonly ApplicationDbContext _context;

        public AssignHoDService(ApplicationDbContext context)
        {
            _context = context;
        }


        public HODs AddToHodAsync(HODs HoD, string userHoDId, int depID)
        {
            HoD = new HODs();
            HoD.userHoDId = userHoDId;
            HoD.DepID = depID;

            _context.HODs.Add(HoD);
            _context.SaveChangesAsync();
            return HoD;
        }
        
        public HODs SavedHOD => _context.HODs.OrderBy(o => o.HoDId).LastOrDefault();

        public HODs Save(HODs oHOD)
        {
            _context.HODs.Add(oHOD);
            _context.SaveChanges();
            return oHOD;
        }
        public HODs Update(HODs oHOD)
        {
            _context.HODs.Update(oHOD);
            _context.SaveChanges();
            return oHOD;
        }
        public HODs Delete(HODs oHOD)
        {
            _context.HODs.Remove(oHOD);
            _context.SaveChanges();
            return oHOD;
        }

    }
}
