using PicPayChallenge.Payment.Domain.PagSeguroIntegration.Entities;
using PicPayChallenge.Payment.Domain.PagSeguroIntegration.Repositories.Responses;
using PicPayChallenge.Payment.Domain.PagSeguroIntegration.Services.Commands;

namespace PicPayChallenge.Payment.Domain.PagSeguroIntegration.Services.Interfaces
{
    public interface IPagSeguroIntegrationService
    {
        ChargeResponse BoletoPayment(BoletoChargeCommand command);
        ChargeResponse CardPayment(CreateChargeCommand command);
        ChargeResponse ProcessPayment(Charge charge);
    }
}
