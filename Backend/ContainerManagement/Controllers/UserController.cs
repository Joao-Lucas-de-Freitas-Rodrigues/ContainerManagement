using ContainerManagement.Model;
using ContainerManagement.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContainerManagement.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException("a", "Erro ao conectar");
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(UserViewModel userView)
        {
            var user = new User(userView.username, userView.password);

            _userRepository.Add(user);

            return Ok();
        }

        [HttpGet]
        public IActionResult Get(string username)
        {
            var user = _userRepository.Get(username);

            return Ok(user);
        }
    }
}
