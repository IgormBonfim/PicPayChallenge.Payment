namespace PicPayChallenge.Payment.DataTransfer.Payments.Requests
{
    public class PaymentDataRequest
    {
        public int PaymentMethod { get; set; }
        public CardPaymentRequest? CardPayment { get; set; }
        public PixPaymentRequest? PixPayment { get; set; }
    }
}
