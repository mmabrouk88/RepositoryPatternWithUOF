using RepositoryPatternWithUOF.Core.Interfaces;
using RepositoryPatternWithUOF.Core.Models;
using RepositoryPatternWithUOF.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOF.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IBaseRepository<Author> Authors { get; private set; }
        //Now we can get rid of IBaseRepo<Book>
       // public IBaseRepository<Book> Books { get; private set; }

        public IBooksRepository Books { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Authors = new BaseRepository<Author>(_context);
            //Books = new BaseRepository<Book>(_context); 
            Books = new BooksRepository(_context); 

        }


        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
