﻿using ContainerManagement.Repository;
using ContainerManagement.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContainerManagement.Controllers
{
    [ApiController]
    [Route("api/containerstatus")]
    public class ContainerStatusController : Controller
    {
        private readonly IContainerStatusRepository _containerStatusRepository;

        public ContainerStatusController(IContainerStatusRepository containerStatusRepository)
        {
            _containerStatusRepository = containerStatusRepository ?? throw new ArgumentNullException(nameof(containerStatusRepository), "Erro ao conectar");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var container = _containerStatusRepository.Get();

            return Ok(container);
        }
    }
}
