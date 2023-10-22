namespace PicPayChallenge.Payment.DataTransfer.Payments.Requests
{
    public class TranscationRequest
    {
        public int RecieverId { get; set; }
        public decimal Amount { get; set; }
        public PaymentDataRequest Payment {  get; set; }
    }
}