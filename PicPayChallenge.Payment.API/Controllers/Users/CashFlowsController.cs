using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PicPayChallenge.Payment.Application.Users.Services.Interfaces;
using PicPayChallenge.Payment.DataTransfer.Users.Requests;

namespace PicPayChallenge.Payment.API.Controllers.Users
{
    [Authorize]
    [Route("api/cash-flows")]
    [ApiController]
    public class CashFlowsController : ControllerBase
    {
        private readonly ICashFlowsAppService cashFlowsAppService;

        public CashFlowsController(ICashFlowsAppService cashFlowsAppService)
        {
            this.cashFlowsAppService = cashFlowsAppService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] CashFlowRequest request)
        {
            request.Id = Convert.ToInt32(User.FindFirst("userId").Value);

            var response = cashFlowsAppService.Get(request);
            return Ok(response);
        }
    }
}
