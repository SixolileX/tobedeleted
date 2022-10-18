using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tobedeleted.Models;

namespace tobedeleted.IService
{
    public interface IDepartmentService
    {
        Department Save(Department oDepartment);
        Department Update(Department oDepartment);
        Department Delete(Department oDepartment);
        Department SavedDepartment { get; }

        
    }
}
