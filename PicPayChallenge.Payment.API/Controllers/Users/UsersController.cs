using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PicPayChallenge.Payment.Application.Users.Services.Interfaces;
using PicPayChallenge.Payment.DataTransfer.Users.Requests;

namespace PicPayChallenge.Payment.API.Controllers.Users
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersAppService usersAppService;

        public UsersController(IUsersAppService usersAppService)
        {
            this.usersAppService = usersAppService;
        }

        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody] UserRegisterRequest request)
        {
            usersAppService.RegisterUser(request);
            return Ok();
        }

        [HttpPost("auth")]
        public IActionResult AuthUser([FromBody] UserAuthRequest request)
        {
            usersAppService.AuthUser(request);
            return Ok();
        }
    }
}
