using Events.Sdk.Data;
using Events.Services;
using Microsoft.AspNetCore.Mvc;

namespace Events.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SinkController : ControllerBase
    {
        private readonly IQueueService inMemoryQueueService;

        public SinkController(IQueueService inMemoryQueueService)
        {
            this.inMemoryQueueService = inMemoryQueueService;

        }

        [HttpPost]
        public ActionResult Push(string? topicId, string content)
        {
            var id = topicId ?? Guid.NewGuid().ToString();
            var msg = new Message() { TopicId = id, Content = content };
            inMemoryQueueService.Push(msg);

            return Ok(id);
        }
    }
}
