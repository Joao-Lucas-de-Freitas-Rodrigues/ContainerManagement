using ContainerManagement.Repository;
using ContainerManagement.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ContainerManagement.Services;

namespace ContainerManagement.Controllers
{
    [ApiController]
    [Route("api/containertype")]
    public class ContainerTypeController : Controller
    {
        private readonly ContainerTypeFacade _containerTypeFacade;

        public ContainerTypeController(ContainerTypeFacade containerTypeFacade)
        {
            _containerTypeFacade = containerTypeFacade;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var container = _containerTypeFacade.GetAllContainerTypes();

            return Ok(container);
        }
    }
}
