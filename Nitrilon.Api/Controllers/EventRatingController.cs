using Microsoft.AspNetCore.Mvc;
using Nitrilon.DataAccess;
using Nitrilon.Entities;


namespace Nitrilon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventRatingController : Controller
    {
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Repository repository = new();
                repository.DeleteEventRating(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        public IActionResult Put(EventRating eventRatingToUpdate)
        {
            try
            {
                Repository repository = new();
                repository.UpdateEventRating(eventRatingToUpdate);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<EventRating>> GetAll()
        {
            try
            {
                Repository repository = new();
                List<EventRating> eventRatings = repository.GetAllEventRatings();
                return eventRatings;
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<EventRating> Get(int id)
        {
            try
            {
                Repository repository = new();
                EventRating eventRating = repository.GetOneEventRating(id);
                return eventRating;
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult Add(EventRating newEventRating)
        {
            try
            {
                Repository repository = new();
                int createdId = repository.SaveEventRating(newEventRating);
                return Ok(createdId);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
