using PicPayChallenge.Payment.Domain.PagSeguroIntegration.Repositories.Responses;
using PicPayChallenge.Payment.Domain.PagSeguroIntegration.Services.Commands;
using PicPayChallenge.Payment.Domain.Payments.Entities;
using PicPayChallenge.Payment.Domain.Payments.Enums;
using PicPayChallenge.Payment.Domain.Payments.Repositories;
using PicPayChallenge.Payment.Domain.Payments.Services.Commands;
using PicPayChallenge.Payment.Domain.Payments.Services.Interfaces;
using PicPayChallenge.Payment.Domain.PagSeguroIntegration.Services.Interfaces;

namespace PicPayChallenge.Payment.Domain.Payments.Services
{
    public class BoletoPaymentsService : IBoletoPaymentsService
    {
        private readonly IBoletoPaymentsRepository boletoPaymentsRepository;
        private readonly IPagSeguroIntegrationService pagSeguroIntegrationService;

        public BoletoPaymentsService(IBoletoPaymentsRepository boletoPaymentsRepository, IPagSeguroIntegrationService pagSeguroIntegrationService)
        {
            this.boletoPaymentsRepository = boletoPaymentsRepository;
            this.pagSeguroIntegrationService = pagSeguroIntegrationService;
        }
        public BoletoPayment Insert(BoletoPayment boletoPayment)
        {
            return boletoPaymentsRepository.Insert(boletoPayment);
        }

        public BoletoPayment Instance(BoletoPaymentInstanceCommand command)
        {
            return new BoletoPayment(command.ChargeId, command.BoletoPagSeguroId, command.Barcode, command.Status, command.DueDate, command.CreatedAt);
        }

        public BoletoPayment ProcessPayment(ProcessBoletoPaymentCommand command)
        {
            BoletoAddressCommand address = new BoletoAddressCommand
            {
                Country = command.Payment!.Country,
                Region = command.Payment.Region,
                RegionCode = command.Payment.RegionCode,
                City = command.Payment.City,
                PostalCode = command.Payment.PostalCode,
                Street = command.Payment.Street,
                Number = command.Payment.Number,
                Locality = command.Payment.Locality
            };

            BoletoHolderCommand holder = new BoletoHolderCommand
            {
                Name = command.Sender.FullName,
                TaxId = command.Sender.DocumentNumber,
                Email = command.Sender.Email,
                Address = address
            };

            InstructionLinesCommand instructionLines = new InstructionLinesCommand
            {
                Line1 = "PicPayChallenge",
                Line2 = "Via PagSeguro"
            };

            BoletoChargeCommand paymentCommand = new BoletoChargeCommand
            {
                Amount = command.Amount,
                DueDate = GetDueDate(),
                Holder = holder,
                InstructionLines = instructionLines
            };

            ChargeResponse charge = pagSeguroIntegrationService.BoletoPayment(paymentCommand);

            BoletoPaymentInstanceCommand paymentInstanceCommand = new BoletoPaymentInstanceCommand
            {
                ChargeId = charge.Id,
                BoletoPagSeguroId = charge.PaymentMethod.Boleto.Id,
                Barcode = charge.PaymentMethod.Boleto.Barcode,
                CreatedAt = charge.CreatedAt.Value,
                DueDate = charge.PaymentMethod.Boleto.DueDate,
                Status = BoletoPaymentStatusEnum.Waiting
            };

            BoletoPayment boletoPayment = Instance(paymentInstanceCommand);
            return Insert(boletoPayment);
        }

        public DateTime GetDueDate()
        {
            const int expirationDays = 4;

            DateTime workday = DateTime.Now.Date.AddDays(expirationDays);
            return ValidateWorkday(workday);
        }

        private DateTime ValidateWorkday(DateTime workday)
        {
            const int incrementDay = 1;

            List<DayOfWeek> weekend = new List<DayOfWeek>
            {
                DayOfWeek.Saturday,
                DayOfWeek.Sunday,
            };

            if (weekend.Contains(workday.DayOfWeek))
            {
                workday = workday.AddDays(incrementDay);
                workday = ValidateWorkday(workday);
            }

            return workday;
        }
    }
}
