using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public interface IAssignHOD
    {
        HOD AddToHodAsync(HOD hod, string userHoDId ,int depID);
        HOD Save(HOD oHOD);
        
        HOD SavedHOD { get; }
    }
}
