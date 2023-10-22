using System.Text.Json.Serialization;

namespace PicPayChallenge.Payment.Domain.PagSeguroIntegration.Repositories.Responses
{
    public class PaymentMethodResponse
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("installments")]
        public int Installments { get; set; }

        [JsonPropertyName("capture")]
        public bool Capture { get; set; }

        [JsonPropertyName("capture_before")]
        public DateTime CaptureBefore { get; set; }

        [JsonPropertyName("soft_descriptor")]
        public string SoftDescriptor { get; set; }

        [JsonPropertyName("card")]
        public CardResponse Card { get; set; }
    }
}