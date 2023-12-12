using RepositoryPatternWithUOF.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOF.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Author> Authors { get; }
      //  IBaseRepository<Book> Books { get; }
        IBooksRepository Books { get; }
        int Complete();//or Save Changes and it can be async as well
    }
}
