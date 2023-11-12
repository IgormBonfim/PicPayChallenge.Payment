using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PicPayChallenge.Payment.Application.Payments.Services.Interfaces;
using PicPayChallenge.Payment.DataTransfer.Payments.Requests;

namespace PicPayChallenge.Payment.API.Controllers.Payments
{
    [Route("api/transactions")]
    [ApiController]
    [Authorize]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionsAppService transactionsAppService;

        public TransactionsController(ITransactionsAppService transactionsAppService)
        {
            this.transactionsAppService = transactionsAppService;
        }

        [HttpPost]
        public IActionResult BeginTransaction(TranscationRequest request)
        {
            int userId = Convert.ToInt32(User.FindFirst("userId").Value);

            var response = transactionsAppService.StartTransaction(userId, request);
            return Ok(response);
        }

        [HttpGet]
        public IActionResult List([FromQuery] TransactionListRequest request)
        {
            request.UserId = Convert.ToInt32(User.FindFirst("userId").Value);

            var response = transactionsAppService.List(request);
            return Ok(response);
        }
    }
}
