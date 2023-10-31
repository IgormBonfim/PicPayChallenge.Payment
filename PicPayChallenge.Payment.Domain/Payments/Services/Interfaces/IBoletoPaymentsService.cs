using PicPayChallenge.Payment.Domain.Payments.Entities;
using PicPayChallenge.Payment.Domain.Payments.Services.Commands;

namespace PicPayChallenge.Payment.Domain.Payments.Services.Interfaces
{
    public interface IBoletoPaymentsService
    {
        BoletoPayment Instance(BoletoPaymentInstanceCommand command);
        BoletoPayment Insert(BoletoPayment boletoPayment);
        BoletoPayment ProcessPayment(ProcessBoletoPaymentCommand command);
    }
}
