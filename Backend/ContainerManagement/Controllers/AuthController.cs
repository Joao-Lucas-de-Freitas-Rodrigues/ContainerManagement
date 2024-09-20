﻿using ContainerManagement.Model;
using ContainerManagement.Repository;
using ContainerManagement.Services;
using Microsoft.AspNetCore.Mvc;
using BC = BCrypt.Net.BCrypt;

namespace ContainerManagement.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AuthController()
        {
            // Usando o Singleton diretamente
            _userRepository = UserRepository.Instance;
        }

        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            User user = _userRepository.Get(username);

            if (!BC.Verify(password, user.password))
            {
                return BadRequest("invalid credentials");
            }

            var token = TokenServices.GenerateToken(user);

            return Ok(token);
        }
    }
}
