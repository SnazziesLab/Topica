using Events.Sdk.Data;
using Events.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Events.Server.Controllers
{
    [Authorize(Roles = "read")]
    [ApiController]
    [Route("api/[controller]")]
    public class TopicsController : ControllerBase
    {


        private IStore Store { get; set; }

        public TopicsController(IStore store)
        {
            Store = store;
        }

        [HttpGet()]
        public ActionResult<Topic> GetTopics()
        {
            return Ok(Store.GetTopics());
        }

        [HttpGet("{id}")]
        public ActionResult<Topic> GetTopic(string id)
        {
            var ok = Store.TryGetTopic(id, out var @event);

            if (!ok)
                return NotFound();

            return Ok(@event);
        }

        [Authorize(Roles = "write")]
        [HttpPost("{topicName}", Name = nameof(AddMessage))]
        public ActionResult AddMessage(string? topicId, string message)
        {
            var id = topicId ?? Guid.NewGuid().ToString();
            var msg = new Message() { TopicId = id, Content = message };
            Store.AddMessage(msg);

            return Ok(id);
        }

        [Authorize(Roles = "write")]
        [HttpDelete("message",Name = nameof(DeleteMessage))]
        public ActionResult<Topic> DeleteMessage(string topicId, Guid messageId)
        {
            Store.DeleteEntry(topicId, messageId);

            return Ok();
        }

        [Authorize(Roles = "write")]
        [HttpDelete(Name = nameof(DeleteTopic))]
        public ActionResult<Topic> DeleteTopic(string topicName)
        {
            Store.DeleteTopic(topicName);

            return Ok();
        }
    }
}
