using PicPayChallenge.Payment.Domain.Payments.Entities;
using PicPayChallenge.Payment.Domain.Payments.Services.Commands;

namespace PicPayChallenge.Payment.Domain.Payments.Services.Interfaces
{
    public interface ICardPaymentService
    {
        CardPayment Instance(CardPaymentInstanceCommand command);
        CardPayment Insert(CardPayment cardPayment);
    }
}
