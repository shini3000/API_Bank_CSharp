using Microsoft.AspNetCore.Mvc;

namespace UserBankApi.Controllers
{
    [Route("User/[controller]")]
    public class UserController : Controller
    {

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateUser()
        {
            return Ok("is ok");
        }

    }
}
