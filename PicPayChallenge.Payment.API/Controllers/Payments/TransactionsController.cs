using Microsoft.AspNetCore.Authorization;
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

        public TransactionsController(ITransactionsAppService transactionsAppService)
        {
            this.transactionsAppService = transactionsAppService;
        }

        [HttpPost]
        [Authorize]
        public IActionResult BeginTransaction(TranscationBeginRequest request)
        {
            int userId = Convert.ToInt32(User.FindFirst("userId").Value);

            var response = transactionsAppService.StartTransaction(userId, request);
            return Ok(response);
        }
    }
}
