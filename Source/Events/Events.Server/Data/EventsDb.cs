using Microsoft.EntityFrameworkCore;

namespace Events.Server.Data
{
    public class EventsDb: DbContext
    {

        public DbSet<Topic> Events { get; set; }

    }
}
