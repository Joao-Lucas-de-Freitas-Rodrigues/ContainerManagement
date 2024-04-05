using ContainerManagement.Repository;
using ContainerManagement.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContainerManagement.Controllers
{
    [ApiController]
    [Route("api/containertype")]
    public class ContainerTypeController : Controller
    {
        private readonly IContainerTypeRepository _containerTypeRepository;

        public ContainerTypeController(IContainerTypeRepository containerTypeRepository)
        {
            _containerTypeRepository = containerTypeRepository ?? throw new ArgumentNullException("a", "Erro ao conectar");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var container = _containerTypeRepository.Get();

            return Ok(container);
        }
    }
}
