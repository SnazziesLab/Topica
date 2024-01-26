
using Events.Services;
using Microsoft.AspNetCore.Mvc;

namespace Events.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {

        private readonly ILogger<EventsController> _logger;
        private readonly InMemoryStore inMemoryDb;

        public EventsController(ILogger<EventsController> logger, InMemoryStore inMemoryDb)
        {
            _logger = logger;
            this.inMemoryDb = inMemoryDb;
        }

        [HttpGet(Name = "GetAllTopics")]
        public ActionResult<Event> GetTopics()
        {
            return Ok(inMemoryDb.Events.Keys);
        }

        [HttpGet(Name = "GetEvents")]
        public ActionResult<Event> Get(string id)
        {
           var ok =  inMemoryDb.Events.TryGetValue(id, out var @event);

            if (!ok) 
                return NotFound();

            return Ok(@event);
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
