using PicPayChallenge.Payment.Domain.PagSeguroIntegration.Repositories.Responses;
using PicPayChallenge.Payment.Domain.PagSeguroIntegration.Services.Commands;

namespace PicPayChallenge.Payment.Domain.PagSeguroIntegration.Services.Interfaces
{
    public interface IPagSeguroIntegrationService
    {
        ChargeResponse ProcessPayment(CreateChargeCommand command);
    }
}
