using Events.Sdk.Data;
using Events.Services;
using Microsoft.AspNetCore.Mvc;

namespace Events.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TopicsController : ControllerBase
    {
        private readonly IQueueService inMemoryQueueService;
        private readonly InMemoryStore inMemoryDb;

        public TopicsController(IQueueService inMemoryQueueService, InMemoryStore inMemoryDb)
        {
            this.inMemoryQueueService = inMemoryQueueService;
            this.inMemoryDb = inMemoryDb;
        }

        [HttpGet("[Action]")]
        public ActionResult<Topic> GetTopics()
        {
            return Ok(inMemoryDb.Events.Keys);
        }

        [HttpGet("[Action]/{id}")]
        public ActionResult<Topic> GetTopic(string id)
        {
            var ok = inMemoryDb.Events.TryGetValue(id, out var @event);

            if (!ok)
                return NotFound();

            return Ok(@event);
        }

        [HttpPost("[Action]")]
        public ActionResult PushMessage(string? topicName, string message)
        {
            var id = topicName ?? Guid.NewGuid().ToString();
            var msg = new Message() { TopicId = id, Content = message };
            inMemoryQueueService.Push(msg);

            return Ok(id);
        }




        [HttpDelete("[Action]")]
        public ActionResult<Topic> DeleteEntry(string topicName, Guid entryId)
        {
            if (inMemoryDb.Events.TryGetValue(topicName, out var @event))
            {
                @event.History.RemoveAll(e => e.EntryId == entryId);
            }

            return Ok();
        }

        [HttpDelete("[Action]")]
        public ActionResult<Topic> DeleteTopic(string topicName)
        {
            if (inMemoryDb.Events.TryRemove(topicName, out var _))
                return Ok();
            else
                return NotFound();
        }
    }
}
