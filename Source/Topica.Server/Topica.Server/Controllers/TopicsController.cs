﻿using Events.Sdk.Data;
using Events.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Topica.Server.Data;

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

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType<PaginatedResponse<TopicMeta>>(StatusCodes.Status200OK)]
        [HttpGet(Name = nameof(GetTopics))]
        public async Task<ActionResult<PaginatedResponse<TopicMeta>>> GetTopics(int page = 0, int pageSize = 25, string? search = null)
        {
            return Ok(await Store.GetTopicsAsync(page, pageSize, search));
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType<int>(StatusCodes.Status200OK)]
        [HttpGet("Total", Name = nameof(GetTotal))]
        public async Task<ActionResult<int>> GetTotal()
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
