using PicPayChallenge.Payment.Domain.Payments.Enums;

namespace PicPayChallenge.Payment.Domain.Payments.Services.Commands
{
    public class CardPaymentInstanceCommand
    {
        public string ChargeId { get; set; }
        public CardPaymentMethodEnum CardPaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public int Installments { get; set; }
        public string Brand { get; set; }
        public string LastDigits { get; set; }
        public int AuthorizationCode { get; set; }
        public string NsuHost { get; set; }
    }
}
