using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tobedeleted.Models;

namespace tobedeleted.IService
{
    public interface IAssignPTL
    {
        Parent AddToParentAsync(Parent parent, string userParentId, string userLearnerId);
        Parent Save(Parent parent);

        Parent savedParent { get; }
    }
}
