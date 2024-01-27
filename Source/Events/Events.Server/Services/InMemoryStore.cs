using Events.Sdk.Data;
using System.Collections.Concurrent;

namespace Events.Services
{
    public class InMemoryStore: IStore
    {
        ConcurrentDictionary<string, Topic> Events { get; set; } = [];

        public ICollection<string> GetTopics()
        {
            return Events.Keys;
        }

        public bool TryGetTopic(string topicId, out Topic? topic)
        {
            var result =  Events.TryGetValue(topicId, out var value);

            topic = value;
            return result;
        }

        public void UpsertTopic(Topic topic)
        {
            Events.AddOrUpdate(topic.Id, topic, (id, value) => value = topic);
        }

        public void DeleteTopic(string topicName)
        {
            Events.TryRemove(topicName, out var _);
        }

        public void AddMessage(Message message)
        {
            var newEntry = new Entry(message.CreatedOn, message.Content);

            if (!Events.TryGetValue(message.TopicId, out var @event))
            {
                var newEvent = new Topic
                {
                    Id = message.TopicId,
                };

                newEvent.History.Add(newEntry);

                var addOk = Events.TryAdd(message.TopicId, newEvent);
                if (!addOk)
                    throw new Exception("Unable to add");
            }
            else
            {
                @event.History.Add(newEntry);
            }
        }

        public void DeleteEntry(string topicName, Guid entryId)
        {
            if (Events.TryGetValue(topicName, out var @event))
            {
                @event.History.RemoveAll(e => e.EntryId == entryId);
            }
        }

    }
}
