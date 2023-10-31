using PicPayChallenge.Payment.Domain.PagSeguroIntegration.Entities;
using System.Text.Json.Serialization;

namespace PicPayChallenge.Payment.Domain.PagSeguroIntegration.Repositories.Responses
{
    public class BoletoHolderResponse
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("tax_id")]
        public string TaxId { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("address")]
        public Address Address { get; set; }
    }
}