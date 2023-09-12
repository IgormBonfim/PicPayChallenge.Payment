using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PicPayChallenge.Payment.Application.Payments.Services.Interfaces;
using PicPayChallenge.Payment.DataTransfer.Payments.Requests;

namespace PicPayChallenge.Payment.API.Controllers.Payments
{
    [Route("api/transactions")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionsAppService transactionsAppService;
        private readonly HttpContext httpContext;

        public TransactionsController(ITransactionsAppService transactionsAppService, HttpContext httpContext)
        {
            this.transactionsAppService = transactionsAppService;
            this.httpContext = httpContext;
        }

        [HttpPost]
        [Authorize]
        public IActionResult BeginTransaction(TranscationBeginRequest request)
        {
            int userId = Convert.ToInt32(httpContext.User.FindFirst("userId").Value);

            transactionsAppService.StartTransaction(userId, request);
            return Ok();
        }
    }
}
