using System.Text.Json.Serialization;

namespace PicPayChallenge.Payment.Domain.PagSeguroIntegration.Repositories.Responses
{
    public class ChargeResponse
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonPropertyName("paid_at")]
        public DateTime PaidAt { get; set;}

        [JsonPropertyName("description")]
        public string? Description { get; set;}        
        
        [JsonPropertyName("amount")]
        public AmountResponse? Amount { get; set;}

        [JsonPropertyName("payment_response")]
        public PaymentResponse? PaymentResponse { get; set; }

        [JsonPropertyName("payment_method")]
        public PaymentMethodResponse? PaymentMethod { get; set; }
    }
}
