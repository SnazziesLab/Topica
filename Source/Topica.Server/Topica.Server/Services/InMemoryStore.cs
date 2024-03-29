﻿using Events.Sdk.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;
using Topica.Server.Data;

namespace Events.Services
{
    public class InMemoryStore : IStore
    {
        ConcurrentDictionary<string, Topic> Events { get; set; } = [];

        public async Task<PaginatedResponse<TopicMeta>> GetTopicsAsync(int page, int pageSize, string? search = null)
        {

            var query = Events.Values;
            if (!string.IsNullOrEmpty(search))
                query = query.Where(e => e.Id.Contains(search)).ToArray();

            var data = query.OrderBy(e => e.CreatedOn).Skip(page * pageSize).Take(pageSize).ToArray();

            var total = Events.Count();
            return new(data: data, page: page, pageSize: pageSize, total: total);
        }
        public async Task<int> GetTopicsCountAsync()
        {
            return Events.Count;
        }

        public async Task<Topic?> GetTopicAsync(string topicId)
        {
            Events.TryGetValue(topicId, out var value);

            return value;
        }

        public async Task<bool> TryAddTopicAsync(Topic topic)
        {
            return Events.TryAdd(topic.Id, topic);
        }

        public async Task AddOrUpdateTopicAsync(Topic topic)
        {
            Events.AddOrUpdate(topic.Id, topic, (id, value) => value = topic);
        }

        public async Task DeleteTopicAsync(string topicName)
        {
            Events.TryRemove(topicName, out var _);
        }

        public async Task AddMessageAsync(Message message)
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

        public async Task DeleteEntryAsync(string topicName, Guid entryId)
        {
            if (Events.TryGetValue(topicName, out var @event))
            {
                @event.History.RemoveAll(e => e.EntryId == entryId);
            }
        }

    }
}
