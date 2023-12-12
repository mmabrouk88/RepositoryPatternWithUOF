using RepositoryPatternWithUOF.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOF.Core.Interfaces
{
    public interface IBooksRepository : IBaseRepository<Book>
    {
        //we can list here all specific implementations of Books Repo
        void SpecialMethod();
    }
}
