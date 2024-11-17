using Application.Dto;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace UserBank.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountServices _service;

        public AccountController(IAccountServices service)
        {
            _service = service;
        }

        [Authorize]
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAccount([FromBody] Account accountDto)
        {
            return Ok(await _service.CreateAccount(accountDto));
        }

        [Authorize]
        [HttpGet]
        [Route("balance/{id}")]
        public async Task<IActionResult> GetBalance([FromRoute]Guid id) 
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            return null;
        }

    }
}
