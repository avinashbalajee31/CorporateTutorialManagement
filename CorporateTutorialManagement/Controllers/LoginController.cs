
using CorporateTutorialManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CorporateTutorialManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {

        private readonly corporatetutorialmanagementContext _context;

        public LoginController(corporatetutorialmanagementContext context)
        {
            _context = context;
        }


        [HttpPost]
        [Route("login")]
        public async Task <ActionResult<User>> login(Login user)
        {
            var users = await _context.Users.FirstOrDefaultAsync(e=>e.EmailId==user.EmailId);
            if (user != null)
            {
                return Ok(users);
            }
            else
            {
                return NotFound("user not found");
            }
            //var userData = new List<User>();
            //using (var context = new corporatetutorialmanagementContext())
            //{
            //    userData = await context.Users.FindAsync(user);
            //}
        }
    }
}
