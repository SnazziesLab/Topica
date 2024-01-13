using System.Collections.Concurrent;

namespace Events.Services
{
    public class InMemoryDb
    {
        public ConcurrentDictionary<string, Event> Events { get; private set; } = [];
        public InMemoryDb()
        {

        }
    }
}
