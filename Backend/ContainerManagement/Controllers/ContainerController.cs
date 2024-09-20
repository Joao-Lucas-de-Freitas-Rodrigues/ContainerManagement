using ContainerManagement.Model;
using ContainerManagement.Services;
using ContainerManagement.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContainerManagement.Controllers
{
    [ApiController]
    [Route("api/container")]
    public class ContainerController : Controller
    {
        private readonly ContainerFacade _containerFacade;

        public ContainerController()
        {
            // Usando o Façade que já está configurado com o Singleton
            _containerFacade = new ContainerFacade();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddContainer([FromForm] ContainerViewModel containerView)
        {
            byte[] imageData = null;
            if (containerView.Image != null)
            {
                using (var ms = new MemoryStream())
                {
                    await containerView.Image.CopyToAsync(ms);
                    imageData = ms.ToArray();
                }
            }

            var container = new Container(
                containerView.container_description,
                containerView.container_name,
                containerView.container_type_id,
                containerView.container_status_id,
                imageData // Passando a imagem
            );

            _containerFacade.AddContainer(container);
            return CreatedAtAction(nameof(GetContainerById), new { id = container.id }, container);
        }

        [Authorize]
        [HttpGet("image/{id}")]
        public IActionResult GetContainerImage(int id)
        {
            var container = _containerFacade.GetBlobById(id);


            // Retorna a imagem como conteúdo binário
            return File(container, "image/jpeg"); // Ajuste o tipo MIME de acordo com o formato da imagem, por exemplo "image/png" se necessário.
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

            var container = new Container(
                containerView.container_description,
                containerView.container_name,
                containerView.container_type_id,
                containerView.container_status_id
            );

            _containerFacade.UpdateContainer(id, container);
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
