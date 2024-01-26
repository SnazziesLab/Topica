using Microsoft.EntityFrameworkCore;

namespace Events.Server.Data
{
    public class EventsDb: DbContext
    {

        public DbSet<Event> Events { get; set; }

    }
}
