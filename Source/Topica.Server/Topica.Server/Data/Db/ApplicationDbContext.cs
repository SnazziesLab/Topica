using Events.Sdk.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.Json;

namespace Events.Server.Data.Db
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Topic> Topics { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var options = new JsonSerializerOptions(JsonSerializerDefaults.General);

            modelBuilder
                .Entity<Topic>()
                .Property(x => x.History)
                .HasColumnType("BLOB") // sqlite BLOB type
                .HasConversion(
                    v => JsonSerializer.Serialize(v, options),
                    s => JsonSerializer.Deserialize<List<Entry>>(s, options)!,
                    ValueComparer.CreateDefault(typeof(List<Entry>), true)
                );
        }
    }
}
