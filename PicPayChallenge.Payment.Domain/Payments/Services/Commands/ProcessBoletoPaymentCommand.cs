using PicPayChallenge.Payment.Domain.Users.Entities;

namespace PicPayChallenge.Payment.Domain.Payments.Services.Commands
{
    public class ProcessBoletoPaymentCommand
    {
        public decimal Amount { get; set; }
        public User Sender { get; set; }
        public BoletoPaymentCommand Payment { get; set; }
    }
}
