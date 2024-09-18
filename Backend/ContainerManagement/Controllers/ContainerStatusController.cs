using ContainerManagement.Repository;
using ContainerManagement.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ContainerManagement.Services;

namespace ContainerManagement.Controllers
{
    [ApiController]
    [Route("api/containerstatus")]
    public class ContainerStatusController : Controller
    {
        private readonly ContainerStatusFacade _containerStatusFacade;

        public ContainerStatusController(ContainerStatusFacade containerStatusFacade)
        {
            _containerStatusFacade = containerStatusFacade;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var container = _containerStatusFacade.GetAllContainerStatuses();

            return Ok(container);
        }
    }
}
