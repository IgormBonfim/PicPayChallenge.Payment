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
        public ChargeResponse ProcessPayment(Charge charge)
        {
            ChargeResponse response = pagSeguroIntegrationRepository.CreateCharge(charge);

            ValidatePayment(response);

            return response;
        }

        public ChargeResponse CardPayment(CreateChargeCommand command) 
        {
            Amount amount = InstanceAmount(command.Amount);

            Holder holder = new Holder(command.HolderName);

            Card card = new Card(command.EncryptedCard, command.SecurityCode.ToString(), holder);

            PaymentMethod paymentMethod = new PaymentMethod(command.PaymentMethod, command.Installments, true, "PicPayChallenge", card);

            Charge charge = new Charge(null, "Transaction between users", amount, paymentMethod);

            return ProcessPayment(charge);
        }

        public ChargeResponse BoletoPayment(BoletoChargeCommand command)
        {
            Amount amount = InstanceAmount(command.Amount);

            InstructionLines instructionLines = new InstructionLines(command.InstructionLines.Line1, command.InstructionLines.Line2);

            Address address = new Address(
                command.Holder.Address.Country, 
                command.Holder.Address.Region, 
                command.Holder.Address.RegionCode, 
                command.Holder.Address.City, 
                command.Holder.Address.PostalCode, 
                command.Holder.Address.Street, 
                command.Holder.Address.Number, 
                command.Holder.Address.Locality);

            BoletoHolder holder = new BoletoHolder(command.Holder.Name, command.Holder.TaxId, command.Holder.Email, address);

            Boleto boleto = new Boleto(command.DueDate, instructionLines, holder);

            PaymentMethod paymentMethod = new PaymentMethod("BOLETO", boleto);

            Charge charge = new Charge(null, "Transaction between users using boleto payment method", amount, paymentMethod);

            return ProcessPayment(charge);
        }

        public Amount InstanceAmount(decimal amount)
        {
            int pagSeguroMultiplier = 100;
            int pagSeguroAmount = Convert.ToInt32(amount * pagSeguroMultiplier);

            return new Amount(pagSeguroAmount, "BRL");
        }

        public void ValidatePayment(ChargeResponse charge)
        {
            if (charge.Status == PaymentStatusEnum.Declined)
                throw new PaymentStatusInvalidException(charge.PaymentResponse.Code, charge.Status, charge.PaymentResponse.Message);
        }
    }
}
