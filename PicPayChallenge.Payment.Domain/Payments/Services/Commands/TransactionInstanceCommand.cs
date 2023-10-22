using PicPayChallenge.Payment.Domain.Payments.Entities;

namespace PicPayChallenge.Payment.Domain.Payments.Services.Commands
{
    public class TransactionInstanceCommand
    {
        public int SenderId { get; set; }
        public int RecieverId { get; set; }
        public PaymentData PaymentData { get; set; }
        public decimal Amount { get; set; }
    }
}
