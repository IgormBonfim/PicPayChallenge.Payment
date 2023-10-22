namespace PicPayChallenge.Payment.Domain.PagSeguroIntegration.Services.Commands
{
    public class CreateChargeCommand
    {
        public decimal Amount { get; set; }
        public int Installments { get; set; }
        public string EncryptedCard { get; set; }
        public string HolderName { get; set; }
        public int SecurityCode { get; set; }
        public string PaymentMethod { get; set; }
    }
}
