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

        //public Department Department { get; }

        //public Department SavedDepartment => _context.Departments.SingleOrDefault();

        //public Department Save(Department oDepartment)
        //{
        //    _context.Departments.Add(oDepartment);
        //    _context.SaveChanges();
        //    return oDepartment;
        //}

        public HOD AddToHodAsync(HOD HoD, int subID, int depID, string RoleName, string userId)
        {
            HoD = new HOD();
            HoD.SubID = subID;
            HoD.DepID = depID;
            HoD.RoleName = RoleName;
            HoD.UserId = userId;

            _context.HOD.Add(HoD);
            _context.SaveChangesAsync();
            return HoD;
        }
        

        //Task<Department> IAssignHOD.FindByIdAsync(int depId)
        //{
        //    HOD HoD = new HOD();
        //    HoD.DepID = depId;
        //    throw new NotImplementedException();
        //}

        public HOD SavedHOD => _context.HOD.SingleOrDefault();

        public HOD Save(HOD oHOD)
        {
            _context.HOD.Add(oHOD);
            _context.SaveChanges();
            return oHOD;
        }

    }
}
