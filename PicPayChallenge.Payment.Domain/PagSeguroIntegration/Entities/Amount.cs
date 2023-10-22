using System.Text.Json.Serialization;

namespace PicPayChallenge.Payment.Domain.PagSeguroIntegration.Entities
{
    public class Amount
    {
        [JsonPropertyName("value")]
        public decimal Value { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        public Amount(decimal value, string currency)
        {
            Value = value;
            Currency = currency;
        }
    }
}
