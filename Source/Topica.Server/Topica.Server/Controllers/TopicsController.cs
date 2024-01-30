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


        /// <summary>
        /// Gets all Topic Ids.
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType<string[]>(StatusCodes.Status200OK)]
        [HttpGet(Name = nameof(GetTopics))]
        public async Task<ActionResult<string[]>> GetTopics()
        {
            return Ok(await Store.GetTopicsAsync());
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType<int>(StatusCodes.Status200OK)]
        [HttpGet("Count", Name = nameof(GetCount))]
        public async Task<ActionResult<int>> GetCount()
        {
            return Ok(await Store.GetTopicsCountAsync());
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType<Topic>(StatusCodes.Status200OK)]
        [HttpGet("{topicId}", Name = nameof(GetTopic))]
        public async Task<ActionResult<Topic>> GetTopic(string topicId)
        {
            var topic = await Store.GetTopicAsync(topicId);

            if (topic is null)
                return NotFound();

            return Ok(topic);
        }

        /// <summary>
        /// Creates a message under topic id.
        /// </summary>
        /// <param name="topicId">If topicId is null, a GUID will be generated in place</param>
        /// <param name="message"></param>
        /// <returns>Topic Id</returns>
        [ProducesResponseType<string>(StatusCodes.Status200OK)]
        [Authorize(Roles = "write")]
        [HttpPost(Name = nameof(AddMessage))]
        public async Task<ActionResult<string>> AddMessage(string? topicId, string message)
        {
            if (string.IsNullOrEmpty(topicId))
                topicId = Guid.NewGuid().ToString();
            var msg = new Message() { TopicId = topicId, Content = message };
            await Store.AddMessageAsync(msg);

            return Ok(topicId);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "write")]
        [HttpDelete("{topicId}/messages/{messageId}", Name = nameof(DeleteMessage))]
        public async Task<ActionResult> DeleteMessage(string topicId, Guid messageId)
        {
            await Store.DeleteEntryAsync(topicId, messageId);

            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "write")]
        [HttpDelete("{topicId}", Name = nameof(DeleteTopic))]
        public async Task<ActionResult> DeleteTopic(string topicId)
        {
            await Store.DeleteTopicAsync(topicId);

            return Ok();
        }
    }
}
