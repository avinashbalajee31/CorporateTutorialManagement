
using CorporateTutorialManagement.Models;
using CorporateTutorialManagement.TokenManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CorporateTutorialManagement.Controllers
{
   
    public class LoginController : Controller
    {


        private readonly corporatetutorialmanagementContext _context;
        private readonly IJWTTokenManager _configuration;

        public LoginController(corporatetutorialmanagementContext context, IJWTTokenManager configuration)
        {
            _context = context;
            _configuration = configuration;
        }

       
      

        [HttpPost]
        [Route("login")]
        public async Task <ActionResult<User>> login([FromBody]Login user)
        {
            var users = await _context.Users.FirstOrDefaultAsync(x => x.EmailId == user.EmailId && x.Password == user.Password);
            if (users != null)
            {
                var token = _configuration.Authenticate(user.EmailId);
                return Ok(token);
            }
            else
            {
                return BadRequest("user not found");
            }
            
        }

        [Authorize]
        [HttpGet]
        [Route("check")]
        public String Signout()
        {
            return "authenticated"; 
        }


    }
}
