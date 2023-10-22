namespace PicPayChallenge.Payment.DataTransfer.Payments.Requests
{
    public class CardPaymentRequest
    {
        public int Installments { get; set; }
        public string EncryptedCard { get; set; }
        public string HolderName { get; set; }
        public int SecurityCode { get; set; }
    }
}