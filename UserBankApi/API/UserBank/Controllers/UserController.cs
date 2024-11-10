using Application.Dto;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UserBankApi.Models.Dto;

namespace UserBankApi.Controllers
{
    [Route("[controller]")]
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
            var response = await _service.VerifyPassword(loginDto);
            if (response == null)
            {
                return BadRequest("Email o contraseña incorrecta");
            }
            return Ok(response);
        }


        [Authorize]
        [HttpGet("GetBalance/{Email}")]
        public IActionResult GetBalance([FromRoute]string email)
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            var balance = _service.GetBalance(email, userEmail).Result;
            return Ok(balance);
        }
    }
}