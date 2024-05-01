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
                MemberRepository repository = new();
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
                MemberRepository repository = new();
                repository.AddMember(member);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int memberId)
        {
            try
            {
                MemberRepository repository = new();
                repository.DeleteMember(memberId);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Member member)
        {
            try
            {
                MemberRepository repository = new();
                repository.UpdateMember(id, member);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

    }
}
