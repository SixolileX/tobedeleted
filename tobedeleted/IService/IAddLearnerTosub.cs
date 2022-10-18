using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Models
{
    public interface IAddLearnerTosub
    {

        learners AddToLeanerAsync(learners Learn, string UserlearnerId, string SubjectName);
        learners SaveLearner(learners Learn);

        learners SavedLearner { get; }
    }
}
