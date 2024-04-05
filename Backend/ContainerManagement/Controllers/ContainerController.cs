using ContainerManagement.Model;
using ContainerManagement.Repository;
using ContainerManagement.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContainerManagement.Controllers
{
    [ApiController]
    [Route("api/container")]
    public class ContainerController : Controller
    {

        private readonly IContainerRepository _containerRepository;

        public ContainerController(IContainerRepository containerRepository)
        {
            _containerRepository = containerRepository ?? throw new ArgumentNullException(nameof(userRepository), "Erro ao conectar");
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(ContainerViewModel containerView)
        {
            var container = new Container(containerView.container_description, containerView.container_name, containerView.container_type_id, containerView.container_status_id);

            _containerRepository.Add(container);

            return Ok();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var container = _containerRepository.Get();

            return Ok(container);
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var container = _containerRepository.GetById(id);

            return Ok(container);
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, ContainerViewModel containerView)
        {
            var container = new Container(containerView.container_description, containerView.container_name, containerView.container_type_id, containerView.container_status_id);

            _containerRepository.Put(id, container);

            return Ok();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var container = _containerRepository.GetById(id);

            _containerRepository.Delete(container);

            return Ok();
        }
    }
}
