using PicPayChallenge.Payment.Domain.Payments.Enums;

namespace PicPayChallenge.Payment.Domain.Payments.Services.Commands
{
    public class PaymentDataCommand
    {
        public PaymentMethodEnum PaymentMethod { get; set; }
        public CardPaymentCommand? CardPayment { get; set; }
        public PixPaymentCommand? PixPayment { get; set; }
        public BoletoPaymentCommand? BoletoPayment { get; set; }
    }
}
