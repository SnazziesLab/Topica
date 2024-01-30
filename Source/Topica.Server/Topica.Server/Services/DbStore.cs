using Events.Sdk.Data;
using Events.Server.Data.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Collections.Concurrent;

namespace Events.Services
{
    public class DbStore : IStore
    {
        ApplicationDbContext ApplicationDbContext { get; }

        public DbStore(ApplicationDbContext applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }
        public async Task<ICollection<string>> GetTopicsAsync()
        {
            return await ApplicationDbContext.Topics.Select(e => e.Id).ToArrayAsync();
        }
        public async Task<int> GetTopicsCountAsync()
        {
            return await ApplicationDbContext.Topics.CountAsync();
        }

        public async Task<Topic?> GetTopic(string topicId)
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
