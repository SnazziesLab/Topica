using Events.Sdk.Data;

namespace Events.Services
{
    public interface IStore
    {
        Task<ICollection<string>> GetTopicsAsync();
        Task<int> GetTopicsCountAsync();
        Task<Topic?> GetTopicAsync(string topicId);
        Task DeleteTopicAsync(string topicId);
        Task AddOrUpdateTopicAsync(Topic topic);
        Task DeleteEntryAsync(string topicName, Guid entryId);
        Task AddMessageAsync(Message message);
    }
}