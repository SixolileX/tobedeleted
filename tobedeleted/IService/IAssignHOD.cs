using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public interface IAssignHOD
    {
        //Task<Department> FindByIdAsync(int depId);
        //public static Department Success { get; }
        //
        // Summary:
        //     Flag indicating whether if the operation succeeded or not.
        //
        // Value:
        //     True if the operation succeeded, otherwise false.
        //public bool Succeeded { get; protected set; }

        ////
        //// Summary:
        ////     Converts the value of the current Microsoft.AspNetCore.Identity.IdentityResult
        ////     object to its equivalent string representation.
        ////
        //// Returns:
        ////     A string representation of the current Microsoft.AspNetCore.Identity.IdentityResult
        ////     object.
        ////
        //// Remarks:
        ////     If the operation was successful the ToString() will return "Succeeded" otherwise
        ////     it returned "Failed : " followed by a comma delimited list of error codes from
        ////     its Microsoft.AspNetCore.Identity.IdentityResult.Errors collection, if any.
        //string GetToString();
        HOD AddToHodAsync(HOD hod, int subID ,int depID, string RoleName, string userId );
        HOD Save(HOD oHOD);
        
        HOD SavedHOD { get; }
    }
}
