using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserBankApi.Models.Dto;

namespace UserBank.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {

        [Authorize]
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAccount()
        {
            return await Task.FromResult(Ok());
        }
    }
}
