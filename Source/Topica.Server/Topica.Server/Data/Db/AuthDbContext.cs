using Events.Server.Config;
using Microsoft.EntityFrameworkCore;

namespace Events.Server.Data.Db
{
    public class AuthDbContext : DbContext
    {

        public DbSet<UserConfig> Users { get; set; }
        public DbSet<ApiKeyConfig> ApiKeys { get; set; }

        public AuthDbContext(DbContextOptions<AuthDbContext> options)
        : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }

}
