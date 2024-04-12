using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nitrilon.DataAccess;
using Nitrilon.Entities;

namespace Nitrilon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Event eventToUpdatw)
        {
            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Event>> GetAll()
        {
            Repository repository = new();
            List<Event> events = repository.GetAllEvents();
            return events;
        }

        [HttpGet("{id}")]
        public ActionResult<Event> Get(int id)
        {
            Event e = null;
            if (id == 3)
            {
                e = new() { Id = 3 };
            }
            else
            {
                return NotFound($"The requested event with id {id} was not found");
            }

            return Ok(e);
        }

        [HttpPost]
        public IActionResult Add(Event newEvent)
        {
            try
            {
                Repository r = new();
                int createdId = r.Save(newEvent);
                return Ok();
            }
            catch(Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
