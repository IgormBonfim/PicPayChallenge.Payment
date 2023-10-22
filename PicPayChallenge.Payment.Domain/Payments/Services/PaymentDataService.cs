using PicPayChallenge.Payment.Domain.Payments.Entities;
using PicPayChallenge.Payment.Domain.Payments.Services.Commands;
using PicPayChallenge.Payment.Domain.Payments.Services.Interfaces;

namespace PicPayChallenge.Payment.Domain.Payments.Services
{
    public class PaymentDataService : IPaymentDataService
    {
        public PaymentDataService()
        {
            
        }
        public PaymentData InstanceCardPayment(PaymentDataInstanceCommand command)
        {
            return new PaymentData(command.PaymentMethod, command.CardPayment);
        }

        public PaymentData InstancePixPayment(PaymentDataInstanceCommand command)
        {
            return new PaymentData(command.PaymentMethod, command.PixPayment);
        }
    }
}
