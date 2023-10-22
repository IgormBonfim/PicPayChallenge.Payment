using PicPayChallenge.Payment.Domain.PagSeguroIntegration.Entities;
using PicPayChallenge.Payment.Domain.PagSeguroIntegration.Repositories;
using PicPayChallenge.Payment.Domain.PagSeguroIntegration.Repositories.Responses;
using PicPayChallenge.Payment.Domain.PagSeguroIntegration.Services.Commands;
using PicPayChallenge.Payment.Domain.PagSeguroIntegration.Services.Interfaces;

namespace PicPayChallenge.Payment.Domain.PagSeguroIntegration.Services
{
    public class PagSeguroIntegrationService : IPagSeguroIntegrationService
    {
        private readonly IPagSeguroIntegrationRepository pagSeguroIntegrationRepository;

        public PagSeguroIntegrationService(IPagSeguroIntegrationRepository pagSeguroIntegrationRepository)
        {
            this.pagSeguroIntegrationRepository = pagSeguroIntegrationRepository;
        }
        public ChargeResponse ProcessPayment(CreateChargeCommand command)
        {
            Amount amount = new Amount(command.Amount, "BRL");

            Holder holder = new Holder(command.HolderName);

            Card card = new Card(command.EncryptedCard, command.SecurityCode.ToString(), holder);

            PaymentMethod paymentMethod = new PaymentMethod(command.PaymentMethod, command.Installments, false, "PicPayChallenge", card);

            Charge charge = new Charge(null, "Transaction between users", amount, paymentMethod);

            return pagSeguroIntegrationRepository.CreateCharge(charge);
        }
    }
}
