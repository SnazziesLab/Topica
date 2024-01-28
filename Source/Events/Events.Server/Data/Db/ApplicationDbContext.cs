using Microsoft.EntityFrameworkCore;

namespace Events.Server.Data.Db
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Topic> Topics { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
  : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
