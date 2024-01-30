using Events.Sdk.Data;
using Events.Services;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet(Name = nameof(GetTopicsAsync))]
        public async Task<ActionResult<Topic>> GetTopicsAsync()
        {
            return Ok(await Store.GetTopicsAsync());
        }

        [HttpGet("Count", Name = nameof(GetCountAsync))]
        public async Task<ActionResult<Topic>> GetCountAsync()
        {
            return Ok(await Store.GetTopicsCountAsync());
        }

        [HttpGet("{id}", Name = nameof(GetTopic))]
        public async Task<ActionResult<Topic>> GetTopic(string id)
        {
            var topic = await Store.GetTopicAsync(id);

            if (topic is null)
                return NotFound();

            return Ok(topic);
        }

        [Authorize(Roles = "write")]
        [HttpPost( Name = nameof(AddMessageAsync))]
        public async Task<ActionResult> AddMessageAsync(string? topicId, string message)
        {
            var id = topicId ?? Guid.NewGuid().ToString();
            var msg = new Message() { TopicId = id, Content = message };
            await Store.AddMessageAsync(msg);

            return Ok(id);
        }

        [Authorize(Roles = "write")]
        [HttpDelete("message", Name = nameof(DeleteMessageAsync))]
        public async Task<ActionResult<Topic>> DeleteMessageAsync(string topicId, Guid messageId)
        {
            await Store.DeleteEntryAsync(topicId, messageId);

            return Ok();
        }

        [Authorize(Roles = "write")]
        [HttpDelete(Name = nameof(DeleteTopicAsync))]
        public async Task<ActionResult<Topic>> DeleteTopicAsync(string topicName)
        {
            await Store.DeleteTopicAsync(topicName);

            return Ok();
        }
    }
}
