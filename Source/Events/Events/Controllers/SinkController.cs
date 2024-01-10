using Microsoft.AspNetCore.Mvc;

namespace Events.Controllers
{
    [Route("[controller]")]
    public class SinkController: ControllerBase
    {

        [HttpPut]
        public ActionResult PushToFeed(string feedId, string content)
        {
            return Ok(new { feedId });
        }
    }
}
