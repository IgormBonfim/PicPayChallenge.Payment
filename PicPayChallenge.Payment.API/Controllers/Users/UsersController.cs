using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using PicPayChallenge.Payment.Application.Users.Services.Interfaces;

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

        [HttpGet("wallet")]
        [Authorize]
        public IActionResult Get()
        {
            int id = Convert.ToInt32(User.FindFirst("userId").Value);

            var response = usersAppService.Get(id);
            return Ok(response);
        }
    }
}
