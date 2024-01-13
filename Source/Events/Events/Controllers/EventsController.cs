
using Microsoft.AspNetCore.Mvc;

namespace Events.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {

        private readonly ILogger<EventsController> _logger;

        public EventsController(ILogger<EventsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetEvents")]
        public ActionResult<Event> Get(string[] id)
        {
            return Ok();
        }

        [HttpPost(Name = "CreateEvent")]
        public ActionResult<Event> Create(string id, IEnumerable<Event> events)
        {
            return Ok();
        }
        [HttpPut(Name = "UpdateEvent")]
        public ActionResult<Event> Update(Event @event)
        {
            return Ok();
        }

        [HttpDelete(Name = "DeleteEvent")]
        public ActionResult<Event> Delete(string id, IEnumerable<Event> events)
        {
            return Ok();
        }
    }
}
