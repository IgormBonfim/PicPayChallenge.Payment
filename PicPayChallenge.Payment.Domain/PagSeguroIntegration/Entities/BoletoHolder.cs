using System.Text.Json.Serialization;

namespace PicPayChallenge.Payment.Domain.PagSeguroIntegration.Entities
{
    public class BoletoHolder
    {
        [JsonPropertyName("name")]
        public string Name { get; protected set; }

        [JsonPropertyName("tax_id")]
        public string TaxId { get; protected set; }

        [JsonPropertyName("email")]
        public string Email { get; protected set; }

        [JsonPropertyName("address")]
        public Address Address { get; protected set; }

        public BoletoHolder(string name, string taxId, string email, Address address)
        {
            Name = name;
            TaxId = taxId;
            Email = email;
            Address = address;
        }
    }
}