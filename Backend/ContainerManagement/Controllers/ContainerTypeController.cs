using ContainerManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContainerManagement.Controllers
{
    [ApiController]
    [Route("api/containertype")]
    public class ContainerTypeController : Controller
    {
        private readonly ContainerTypeFacade _containerTypeFacade;

        public ContainerTypeController()
        {
            _containerTypeFacade = new ContainerTypeFacade();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var containerTypes = _containerTypeFacade.GetAllContainerTypes();
            return Ok(containerTypes);
        }
    }
}
