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

        public TransactionsController(ITransactionsAppService transactionsAppService)
        {
            this.transactionsAppService = transactionsAppService;
        }

        [HttpPost]
        public IActionResult BeginTransaction(TranscationBeginRequest request)
        {
            transactionsAppService.StartTransaction(request);
            return Ok();
        }
    }
}
