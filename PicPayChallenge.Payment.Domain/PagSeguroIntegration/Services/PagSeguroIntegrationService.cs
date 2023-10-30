using PicPayChallenge.Payment.Domain.PagSeguroIntegration.Entities;
using PicPayChallenge.Payment.Domain.PagSeguroIntegration.Enums;
using PicPayChallenge.Payment.Domain.PagSeguroIntegration.Exceptions;
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
            int pagSeguroMultiplier = 100;
            int pagSeguroAmount = Convert.ToInt32(command.Amount * pagSeguroMultiplier);

            Amount amount = new Amount(pagSeguroAmount, "BRL");

            Holder holder = new Holder(command.HolderName);

            Card card = new Card(command.EncryptedCard, command.SecurityCode.ToString(), holder);

            PaymentMethod paymentMethod = new PaymentMethod(command.PaymentMethod, command.Installments, true, "PicPayChallenge", card);

            Charge charge = new Charge(null, "Transaction between users", amount, paymentMethod);

            ChargeResponse response = pagSeguroIntegrationRepository.CreateCharge(charge);

            ValidatePayment(response);

            return response;
        }

        public void ValidatePayment(ChargeResponse charge)
        {
            if (charge.Status == PaymentStatusEnum.Declined)
                throw new PaymentStatusInvalidException(charge.PaymentResponse.Code, charge.Status, charge.PaymentResponse.Message);
        }
    }
}
