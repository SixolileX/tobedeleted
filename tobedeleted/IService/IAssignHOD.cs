using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public interface IAssignHOD
    {
        HODs AddToHodAsync(HODs hod, string userHoDId ,int depID);
        HODs Save(HODs oHOD);
        HODs Update(HODs oHOD);
        HODs Delete(HODs oHOD);
        HODs SavedHOD { get; }
    }
}
