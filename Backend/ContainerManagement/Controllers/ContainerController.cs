using ContainerManagement.Model;
using ContainerManagement.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ContainerManagement.Controllers
{
    [ApiController]
    [Route("api/container")]
    public class ContainerController : Controller
    {

        private readonly IContainerRepository _containerRepository;

        public ContainerController(IContainerRepository containerRepository)
        {
            _containerRepository = containerRepository ?? throw new ArgumentNullException();
        }

        [HttpPost]
        public IActionResult Add(ContainerViewModel containerView)    
        {
            var container = new Container(containerView.container_description, containerView.container_name, containerView.container_type_id, containerView.container_status_id);  

            _containerRepository.Add(container);

            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var container = _containerRepository.Get();

            return Ok(container);
        }
    }
}
