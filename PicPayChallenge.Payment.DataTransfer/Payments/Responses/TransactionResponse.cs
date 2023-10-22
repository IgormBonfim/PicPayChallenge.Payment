using PicPayChallenge.Common.Responses;
using PicPayChallenge.Payment.DataTransfer.Users.Responses;

namespace PicPayChallenge.Payment.DataTransfer.Payments.Responses
{
    public class TransactionResponse
    {
        public UserTransactionResponse Sender { get; set; }
        public UserTransactionResponse Reciever { get; set; }
        public decimal Amount { get; set; }
        public PaymentDataResponse Payment { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
