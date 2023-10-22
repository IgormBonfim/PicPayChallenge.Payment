using PicPayChallenge.Payment.Domain.Payments.Entities;
using PicPayChallenge.Payment.Domain.Payments.Enums;

namespace PicPayChallenge.Payment.Domain.Payments.Services.Commands
{
    public class PaymentDataInstanceCommand
    {
        public PaymentMethodEnum PaymentMethod { get; set; }
        public CardPayment? CardPayment { get; set; }
        public PixPayment? PixPayment { get; set; }
    }
}
