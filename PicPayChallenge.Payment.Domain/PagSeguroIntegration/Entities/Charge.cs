using System.Text.Json.Serialization;

namespace PicPayChallenge.Payment.Domain.PagSeguroIntegration.Entities
{
    public class Charge
    {
        [JsonPropertyName("reference_id")]
        public string? ReferenceId { get; protected set; }

        [JsonPropertyName("description")]
        public string Description { get; protected set; }

        [JsonPropertyName("amount")]
        public Amount Amount { get; protected set; }

        [JsonPropertyName("payment_method")]
        public PaymentMethod PaymentMethod { get; protected set; }

        public Charge(string? referenceId, string description, Amount amount, PaymentMethod paymentMethod)
        {
            ReferenceId = referenceId;
            Description = description;
            Amount = amount;
            PaymentMethod = paymentMethod;
        }
    }
}
