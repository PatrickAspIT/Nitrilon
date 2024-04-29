using Microsoft.AspNetCore.Mvc;
using Nitrilon.DataAccess;
using Nitrilon.Entities;

namespace Nitrilon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : Controller
    {
        [HttpGet]
        public ActionResult<IEnumerable<Member>> GetAll()
        {
            try
            {
                Repository repository = new();
                List<Member> members = repository.GetAllMembers();
                return members;
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult AddMember(Member member)
        {
            try
            {
                Repository repository = new();
                repository.AddMember(member);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

    }
}
