using System.Text.Json.Serialization;
using PicPayChallenge.Common.Responses;

namespace PicPayChallenge.Payment.DataTransfer.Payments.Responses
{
    public class PaymentDataResponse
    {
        public int PaymentId { get; set; }
        public EnumValue PaymentMethod { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CardPaymentResponse? CardPayment { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public PixPaymentResponse? PixPayment { get; set; }        
        
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BoletoPaymentResponse? BoletoPayment { get; set; }
    }
}
