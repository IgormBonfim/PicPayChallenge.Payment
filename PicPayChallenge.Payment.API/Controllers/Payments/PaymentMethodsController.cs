using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PicPayChallenge.Payment.Application.Payments.Services.Interfaces;

namespace PicPayChallenge.Payment.API.Controllers.Payments
{
    [Route("api/payment-methods")]
    [ApiController]
    public class PaymentMethodsController : ControllerBase
    {
        private readonly IPaymentMethodsAppService paymentMethodsAppService;

        public PaymentMethodsController(IPaymentMethodsAppService paymentMethodsAppService)
        {
            this.paymentMethodsAppService = paymentMethodsAppService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var response = paymentMethodsAppService.ListPaymentMethods();
            return Ok(response);
        }
    }
}
