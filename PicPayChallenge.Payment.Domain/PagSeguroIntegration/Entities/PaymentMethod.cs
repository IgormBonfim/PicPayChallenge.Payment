using System.Text.Json.Serialization;

namespace PicPayChallenge.Payment.Domain.PagSeguroIntegration.Entities
{
    public class PaymentMethod
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("installments")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Installments { get; protected set; }

        [JsonPropertyName("capture")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Capture { get; protected set; }

        [JsonPropertyName("soft_descriptor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SoftDescriptor { get; protected set; }

        [JsonPropertyName("card")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Card? Card { get; protected set; }

        [JsonPropertyName("boleto")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Boleto? Boleto { get; protected set; }

        public PaymentMethod(string type, int installments, bool capture, string softDescriptor, Card card)
        {
            Type = type;
            Installments = installments;
            Capture = capture;
            SoftDescriptor = softDescriptor;
            Card = card;
        }

        public PaymentMethod(string type, Boleto boleto)
        {
            Type = type;
            Boleto = boleto;
        }
    }
}
