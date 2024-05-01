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
            try
            {
                EventRepository repository = new();
                EventRatingData eventRatingData = repository.GetEventRatingDataBy(eventId);
                return Ok(eventRatingData);
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
                EventRepository repository = new();
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
                EventRepository repository = new();
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
