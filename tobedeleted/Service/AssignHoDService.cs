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


        public HOD AddToHodAsync(HOD HoD, string userHoDId, int depID)
        {
            HoD = new HOD();
            HoD.userHoDId = userHoDId;
            HoD.DepID = depID;

            _context.HOD.Add(HoD);
            _context.SaveChangesAsync();
            return HoD;
        }
        
        public HOD SavedHOD => _context.HOD.SingleOrDefault();

        public HOD Save(HOD oHOD)
        {
            _context.HOD.Add(oHOD);
            _context.SaveChanges();
            return oHOD;
        }

    }
}
