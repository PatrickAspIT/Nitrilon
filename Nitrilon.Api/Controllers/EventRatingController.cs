using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nitrilon.DataAccess;
using Nitrilon.Entities;

namespace Nitrilon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventRatingController : Controller
    {
        [HttpGet]
        public ActionResult<EventRatingData> GetEventRatingDataFor(int eventId)
        {
            Repository repository = new();
            EventRatingData eventRatingData = repository.GetEventRatingDataBy(eventId);
            return Ok(eventRatingData);
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
        public IActionResult AddEventRating(int eventId, int ratingId)
        {
            try
            {
                Repository repository = new();
                int createdId = repository.SaveEventRating(eventId, ratingId);
                return Ok(createdId);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
