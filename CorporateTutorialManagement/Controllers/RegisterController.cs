using CorporateTutorialManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var CheckUser = await _context.Users.FirstOrDefaultAsync(e => e.EmailId == user.EmailId);

            if (CheckUser == null)
            {

                if (user != null && user.Password.Length > 8 && user.EmailId.Contains("@gmail.com"))
                {
                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();
                    return Ok("User Created Successfully");
                }
                else
                {
                    return BadRequest("Incorrect input");
                }
            }
            else
            {
                return BadRequest("User already exist");
            }
        }

    }
}
