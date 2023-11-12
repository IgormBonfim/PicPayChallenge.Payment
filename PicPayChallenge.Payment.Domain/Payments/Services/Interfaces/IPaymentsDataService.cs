using PicPayChallenge.Payment.Domain.Payments.Entities;
using PicPayChallenge.Payment.Domain.Payments.Services.Commands;

namespace PicPayChallenge.Payment.Domain.Payments.Services.Interfaces
{
    public interface IPaymentsDataService 
    {
        PaymentData InstanceBoletoPayment(PaymentDataInstanceCommand command);
        PaymentData InstanceCardPayment(PaymentDataInstanceCommand command);
        PaymentData InstancePixPayment(PaymentDataInstanceCommand command);
    }
}
