using Application.Dto;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UserBankApi.Models.Entities;

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
        [Route("balance/{accountNumber}")]
        public async Task<IActionResult> GetBalance([FromRoute]int accountNumber)
        {
            AccountEntity balance;
            string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            balance = await _service.GetAccountByAccountNumber(accountNumber, userId);
            return Ok(balance);
        }

        [Authorize]
        [HttpPatch]
        [Route("deposit")]
        public async Task<IActionResult> Deposit([FromBody] DepositDto depositDto)
        {
            string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _service.UpdateAccount(depositDto, userId);
            return Ok("transaction completed");
        }
    }
}
