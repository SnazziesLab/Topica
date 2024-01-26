using System.Collections.Concurrent;

namespace Events.Services
{
    public class InMemoryStore
    {
        public ConcurrentDictionary<string, Event> Events { get; private set; } = [];

    }
}
