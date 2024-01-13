using Events.Sdk.Data;
using Events.Services;
using Microsoft.AspNetCore.Mvc;

namespace Events.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SinkController : ControllerBase
    {
        private readonly InMemoryQueueService inMemoryQueueService;

        public SinkController(InMemoryQueueService inMemoryQueueService)
        {
            this.inMemoryQueueService = inMemoryQueueService;

        }

        [HttpPut]
        public ActionResult Push(string? Uid, string content)
        {
            var id = Uid ?? Guid.NewGuid().ToString();
            var msg = new Message() { EventUid = id, Content = content };
            inMemoryQueueService.Push(msg);

            if (Uid is null)
                return Ok(id);

            return Ok();
        }
    }
}
