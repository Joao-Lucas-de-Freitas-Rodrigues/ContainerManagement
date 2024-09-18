using ContainerManagement.Model;
using ContainerManagement.Repository;
using ContainerManagement.Services;
using ContainerManagement.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContainerManagement.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly UserFacade _userFacade;

        public UserController(UserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(UserViewModel userView)
        {
            var user = new User(userView.username, userView.password);

            _userFacade.AddUser(user);

            return Ok();
        }

        [HttpGet]
        public IActionResult Get(string username)
        {
            var user = _userFacade.GetUserByUsername(username);

            return Ok(user);
        }
    }
}
