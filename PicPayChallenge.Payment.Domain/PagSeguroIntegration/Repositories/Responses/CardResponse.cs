using System.Text.Json.Serialization;

namespace PicPayChallenge.Payment.Domain.PagSeguroIntegration.Repositories.Responses
{
    public class CardResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("number")]
        public string Number { get; set; }

        [JsonPropertyName("network_token")]
        public string NetworkToken { get; set; }

        [JsonPropertyName("exp_month")]
        public string ExpMonth { get; set; }

        [JsonPropertyName("exp_year")]
        public string ExpYear { get; set; }

        //[JsonPropertyName("security_code")]
        //public int SecurityCode { get; set; }

        [JsonPropertyName("store")]
        public bool Store { get; set; }

        [JsonPropertyName("brand")]
        public string Brand { get; set; }

        [JsonPropertyName("product")]
        public string Product { get; set; }

        [JsonPropertyName("first_digits")]
        public string FirstDigits { get; set; } 

        [JsonPropertyName("last_digits")]
        public string LastDigits { get; set; }
    }
}