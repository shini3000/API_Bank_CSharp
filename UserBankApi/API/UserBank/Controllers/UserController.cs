using Application.Dto;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using UserBankApi.Models.Dto;

namespace UserBankApi.Controllers
{
    [Route("User/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserServices _service;

        public UserController(IUserServices service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateUser([FromBody]UserDto user)
        {
            var createdUser = await _service.save(user);
            return Ok(createdUser);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody]LoginDto loginDto)
        {
            if (await _service.VerifyPassword(loginDto)) { return Ok("login success"); }
            return BadRequest("Email o contraseña incorrecta");
        }
    }
}