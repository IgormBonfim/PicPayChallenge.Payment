namespace PicPayChallenge.Payment.Domain.Payments.Services.Commands
{
    public class TransactionCommand
    {
        public int RecieverId { get; set; }
        public int SenderId { get; set; }
        public decimal Amount { get; set; }
        public PaymentDataCommand Payment { get; set; }
    }
}
