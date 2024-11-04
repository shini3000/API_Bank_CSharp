using Microsoft.AspNetCore.Mvc;
using UserBankApi.Models.Dto;
using UserBankApi.Services;

namespace UserBankApi.Controllers
{
    [Route("User/[controller]")]
    public class UserController : Controller
    {

        private readonly UserServices _service;

        public UserController(UserServices service)
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
    }
}