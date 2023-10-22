namespace PicPayChallenge.Payment.Domain.Payments.Services.Commands
{
    public class CardPaymentCommand
    {
        public int Installments { get; set; }
        public string EncryptedCard { get; set; }
        public string HolderName { get; set; }
        public int SecurityCode { get; set; }
    }
}
