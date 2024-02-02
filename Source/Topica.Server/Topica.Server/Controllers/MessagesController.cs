using Events.Sdk.Data;
using Events.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Topica.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private IStore Store { get; set; }

        public MessagesController(IStore store)
        {
            Store = store;
        }
        /// <summary>
        /// Creates a message under topic id.
        /// </summary>
        /// <param name="topicId">If topicId is null, a new Topic will be generated with a random GUID</param>
        /// <param name="message"></param>
        /// <returns>Topic Id</returns>
        [ProducesResponseType<string>(StatusCodes.Status200OK)]
        [Authorize(Roles = "write")]
        [HttpPost(Name = nameof(AddMessage))]
        public async Task<ActionResult<string>> AddMessage(string? topicId, [FromBody] string message)
        {
            if (string.IsNullOrEmpty(message))
                return BadRequest($"{nameof(message)} cannot be null");
            if (string.IsNullOrEmpty(topicId))
                topicId = Guid.NewGuid().ToString();
            var msg = new Message() { TopicId = topicId, Content = message };
            await Store.AddMessageAsync(msg);

            return Ok(topicId);
        }
    }
}
