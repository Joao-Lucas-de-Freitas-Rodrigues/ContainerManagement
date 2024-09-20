using ContainerManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContainerManagement.Controllers
{
    [ApiController]
    [Route("api/containerstatus")]
    public class ContainerStatusController : Controller
    {
        private readonly ContainerStatusFacade _containerStatusFacade;

        public ContainerStatusController()
        {
            _containerStatusFacade = new ContainerStatusFacade();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var containerStatuses = _containerStatusFacade.GetAllContainerStatuses();
            return Ok(containerStatuses);
        }
    }
}
