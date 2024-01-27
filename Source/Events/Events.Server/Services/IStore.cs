using Events.Sdk.Data;

namespace Events.Services
{
    public interface IStore
    {
        void AddMessage(Message message);
        void DeleteEntry(string topicName, Guid entryId);
        void DeleteTopic(string topicName);
        bool TryGetTopic(string topicId, out Topic? topic);
        ICollection<string> GetTopics();
        void UpsertTopic(Topic topic);
    }
}