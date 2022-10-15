using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tobedeleted.Data;
using tobedeleted.IService;
using tobedeleted.Models;

namespace tobedeleted.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationDbContext _context;

        public DepartmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Department SavedDepartment => _context.Departments.SingleOrDefault();

        public Department Save(Department oDepartment)
        {
            _context.Departments.Add(oDepartment);
            _context.SaveChanges();
            return oDepartment;
        }
    }
}
