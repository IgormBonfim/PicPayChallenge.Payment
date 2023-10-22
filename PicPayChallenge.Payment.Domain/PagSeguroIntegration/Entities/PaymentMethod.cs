using System.Text.Json.Serialization;

namespace PicPayChallenge.Payment.Domain.PagSeguroIntegration.Entities
{
    public class PaymentMethod
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("installments")]
        public int Installments { get; set; }

        [JsonPropertyName("capture")]
        public bool Capture { get; set; }

        [JsonPropertyName("soft_descriptor")]
        public string SoftDescriptor { get; set; }

        [JsonPropertyName("card")]
        public Card Card { get; set; }

        public PaymentMethod(string type, int installments, bool capture, string softDescriptor, Card card)
        {
            Type = type;
            Installments = installments;
            Capture = capture;
            SoftDescriptor = softDescriptor;
            Card = card;
        }
    }
}
