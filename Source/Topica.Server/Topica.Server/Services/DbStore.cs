using Events.Sdk.Data;
using Events.Server.Data.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Collections.Concurrent;
using Topica.Server.Data;

namespace Events.Services
{
    public class DbStore : IStore
    {
        ApplicationDbContext ApplicationDbContext { get; }

        public DbStore(ApplicationDbContext applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }
        public async Task<PaginatedResponse<TopicMeta>> GetTopicsAsync(int page = 0, int pageSize = 25, string? search = null)
        {

            var query = ApplicationDbContext.Topics.AsQueryable();

            if (!string.IsNullOrEmpty(search))
                query = query.Where(e => e.Id.Contains(search));

            var total = query.CountAsync();
            var data = query.Skip(page * pageSize).Take(pageSize).ToArrayAsync();

            await Task.WhenAll(total, data);
            return new(data: data.Result, page: page, pageSize: pageSize, total: total.Result);
        }
        public async Task<int> GetTopicsCountAsync()
        {
            return await ApplicationDbContext.Topics.CountAsync();
        }

        public async Task<Topic?> GetTopicAsync(string topicId)
        {
            var result = await ApplicationDbContext.Topics.SingleOrDefaultAsync(e => e.Id == topicId);

            return result;
        }

        public async Task AddOrUpdateTopicAsync(Topic topic)
        {
            var found = await ApplicationDbContext.Topics.SingleOrDefaultAsync(e => e.Id == topic.Id);
            if (found != null)
            {
                found = topic;
            }
            else
            {
                await ApplicationDbContext.Topics.AddAsync(topic);
            }

            await ApplicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteTopicAsync(string topicId)
        {
            var topic = new Topic() { Id = topicId };

            ApplicationDbContext.Topics.Attach(topic);
            ApplicationDbContext.Topics.Remove(topic);

            await ApplicationDbContext.SaveChangesAsync();
        }

        public async Task AddMessageAsync(Message message)
        {
            var newEntry = new Entry(message.CreatedOn, message.Content);
            var topic = await ApplicationDbContext.Topics.SingleOrDefaultAsync(e => e.Id == message.TopicId);

            if (topic is null)
            {
                var newTopic = new Topic
                {
                    Id = message.TopicId,
                    History = [newEntry]
                };

                await ApplicationDbContext.Topics.AddAsync(newTopic);
            }
            else
            {
                topic.History.Add(newEntry);
            }

            await ApplicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteEntryAsync(string topicName, Guid entryId)
        {
            var topic = await ApplicationDbContext.Topics.SingleOrDefaultAsync(e => e.Id == topicName);
            if (topic is not null)
                topic.History.RemoveAll(e => e.EntryId == entryId);

            await ApplicationDbContext.SaveChangesAsync();
        }

    }
}
