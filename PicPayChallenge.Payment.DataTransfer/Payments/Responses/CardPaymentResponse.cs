using PicPayChallenge.Common.Responses;

namespace PicPayChallenge.Payment.DataTransfer.Payments.Responses
{
    public class CardPaymentResponse
    {
        public int Id { get; set; }
        public string ChargeId { get; set; }
        public EnumValue CardPaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public int Installments { get; set; }
    }
}