using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tobedeleted.Models;

namespace tobedeleted.IService
{
    public interface IAssignPTL
    {
        AssignLearnerToParent AddToParentAsync(AssignLearnerToParent assign, string userParent, string userLearnerId);
        AssignLearnerToParent Save(AssignLearnerToParent assign);

        AssignLearnerToParent savedParent { get; }
    }
}
