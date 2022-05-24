using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordApi
{
    public class WordDbContext : DbContext
    {
        public WordDbContext(DbContextOptions<WordDbContext> options) : base(options)
        {

        }

        public DbSet<WordDefinition> WordDefinitions { get; set; }

        public DbSet<WordMeaning> WordMeanings { get; set; }
    }
}
