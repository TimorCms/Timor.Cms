using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Timor.Cms.Dto.Users;
using Timor.Cms.Service.Users;

namespace Timor.Cms.Api.Controllers
{
    [Route("api/v1")]
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("users/user")]
        public async Task<IActionResult> CreateUser([FromBody]CreateUserInput input)
        {
           var userId= await _userService.CreateUser(input);

           return Created($"/api/v1/users/{userId}", null);
        }
    }
}