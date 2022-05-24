using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace langApi
{
    public class LangDbContext:DbContext
    {
        public LangDbContext(DbContextOptions<LangDbContext> options) :base(options)
        {

        }
        public DbSet<Language> Languages { get; set; }
    }
}
