using ContainerManagement.Model;
using ContainerManagement.Repository;
using ContainerManagement.Services;
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

        private readonly ContainerFacade _containerFacade;

        public ContainerController(ContainerFacade containerFacade)
        {
            _containerFacade = containerFacade;
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddContainer([FromBody] Container container)
        {
            if (container == null)
            {
                return BadRequest();
            }

            _containerFacade.AddContainer(container);
            return CreatedAtAction(nameof(GetContainerById), new { id = container.Id }, container);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var containers = _containerFacade.GetAllContainers();
            return Ok(containers);
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetContainerById(int id)
        {
            var container = _containerFacade.GetContainerById(id);
            if (container == null)
            {
                return NotFound();
            }
            return Ok(container);
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, ContainerViewModel containerView)
        {
            var existingContainer = _containerFacade.GetContainerById(id);
            if (existingContainer == null)
            {
                return NotFound();
            }

            var container = new Container(containerView.container_description, containerView.container_name, containerView.container_type_id, containerView.container_status_id);

            _containerFacade.UpdateContainer(id,container);
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteContainer(int id)
        {
            var container = _containerFacade.GetContainerById(id);
            if (container == null)
            {
                return NotFound();
            }

            _containerFacade.DeleteContainer(container);
            return NoContent();
        }
    }
}
