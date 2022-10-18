using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tobedeleted.Data;
using tobedeleted.IService;
using tobedeleted.Models;


namespace tobedeleted.Service
{
    public class AddLearnerTosub: IAddLearnerTosub
    {
       
            private readonly ApplicationDbContext _context;

            public AddLearnerTosub(ApplicationDbContext context)
            {
                _context = context;
            }


            public learners AddToLeaner(learners Learn, string UserlearnerId, string SubjectName)
            {
                Learn = new learners();
                Learn.UserlearnerId = UserlearnerId;
                Learn.SubjectName = SubjectName;

                _context.learners.Add(Learn);
                _context.SaveChangesAsync();
                return Learn;
            }

            public learners SavedLearner => _context.learners.SingleOrDefault();

            public HOD SaveLearner(HOD oHOD)
            {
                _context.HOD.Add(oHOD);
                _context.SaveChanges();
                return oHOD;
            }

        
    }
    }
