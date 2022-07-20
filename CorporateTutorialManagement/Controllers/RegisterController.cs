using CorporateTutorialManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace CorporateTutorialManagement.Controllers
{
    public class RegisterController : Controller
    {
        private readonly corporatetutorialmanagementContext _context;

        public RegisterController(corporatetutorialmanagementContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<User>> Register([FromBody] User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok("User Created Successfully");
        }

    }
}
