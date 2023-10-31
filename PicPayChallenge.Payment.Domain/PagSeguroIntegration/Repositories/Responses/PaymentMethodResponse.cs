using System.Text.Json.Serialization;

namespace PicPayChallenge.Payment.Domain.PagSeguroIntegration.Repositories.Responses
{
    public class PaymentMethodResponse
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("installments")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Installments { get; set; }

        [JsonPropertyName("capture")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Capture { get; set; }

        [JsonPropertyName("capture_before")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? CaptureBefore { get; set; }

        [JsonPropertyName("soft_descriptor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SoftDescriptor { get; set; }

        [JsonPropertyName("card")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]        
        public CardResponse? Card { get; set; }

        [JsonPropertyName("boleto")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BoletoResponse? Boleto { get; set; }
    }
}