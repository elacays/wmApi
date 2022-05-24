using Microsoft.EntityFrameworkCore;

namespace Word_Api
{
    public class WordDbContext : DbContext
    {
        public WordDbContext(DbContextOptions<WordDbContext> options) : base(options)
        {

        }
        public DbSet<Word> Words { get; set; }
    
    }
}