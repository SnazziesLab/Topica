using Events.Sdk.Data;
using Topica.Server.Data;

namespace Events.Services
{
    public interface IStore
    {
        Task<PaginatedResponse<TopicMeta>> GetTopicsAsync(int page = 0, int pageSize = 25, string? search = null);
        Task<int> GetTopicsCountAsync();
        Task<Topic?> GetTopicAsync(string topicId);
        Task DeleteTopicAsync(string topicId);
        Task AddOrUpdateTopicAsync(Topic topic);
        Task DeleteEntryAsync(string topicName, Guid entryId);
        Task AddMessageAsync(Message message);
        Task<bool> TryAddTopicAsync(Topic topic);
    }
}