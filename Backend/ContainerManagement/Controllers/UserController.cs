using ContainerManagement.Model;
using ContainerManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContainerManagement.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly UserFacade _userFacade;

        public UserController()
        {
            _userFacade = new UserFacade();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            _userFacade.AddUser(user);
            return CreatedAtAction(nameof(GetUserByUsername), new { username = user.username }, user);
        }

        [Authorize]
        [HttpGet("{username}")]
        public IActionResult GetUserByUsername(string username)
        {
            var user = _userFacade.GetUserByUsername(username);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
