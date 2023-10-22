using PicPayChallenge.Payment.Domain.PagSeguroIntegration.Entities;
using PicPayChallenge.Payment.Domain.PagSeguroIntegration.Repositories.Responses;

namespace PicPayChallenge.Payment.Domain.PagSeguroIntegration.Repositories
{
    public interface IPagSeguroIntegrationRepository
    {
        ChargeResponse CreateCharge(Charge charge);
    }
}
