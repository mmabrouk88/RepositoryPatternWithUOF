﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepositoryPatternWithUOF.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOF.EF
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) 
        {
                
        }
        public   DbSet<Author> Authors { get; set; } 
        public   DbSet<Book> Books { get; set; }
    }
}
