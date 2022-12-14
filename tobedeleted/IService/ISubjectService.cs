using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tobedeleted.Models;

namespace tobedeleted.IService
{
    public interface ISubjectService
    {
        Subject Save(Subject oSubject);
        Subject Update(Subject oSubject);
        Subject Delete(Subject oSubject);
        Subject GetSavedSubject();
    }
}
