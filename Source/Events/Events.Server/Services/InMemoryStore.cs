using System.Collections.Concurrent;

namespace Events.Services
{
    public class InMemoryStore
    {
        public ConcurrentDictionary<string, Topic> Events { get; private set; } = [];

    }
}
