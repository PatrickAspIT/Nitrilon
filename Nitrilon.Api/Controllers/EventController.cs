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
        [HttpGet]
        [Route("GetActiveorFutureEvents")]
        public IActionResult GetActiveorFutureEvents()
        {
            try
            {
                Repository repository = new();
                List<Event> events = repository.GetActiveOrFutureEvents();
                return Ok(events);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return NotFound(e);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Repository repository = new();
                repository.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }   
        }

        [HttpPut]
        public IActionResult Put(Event eventToUpdate)
        {
            try
            {
                Repository repository = new();
                repository.Update(eventToUpdate);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Event>> GetAll()
        {
            try
            {
                Repository repository = new();
                List<Event> events = repository.GetAllEvents();
                return events;
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Event> Get(int id)
        {
            try
            {
                Repository repository = new();
                Event events = repository.GetOne(id);
                return events;
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult Add(Event newEvent)
        {
            try
            {
                Repository repository = new();
                int createdId = repository.Save(newEvent);
                return Ok(createdId);
            }
            catch(Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
