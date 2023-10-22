using System.Text.Json.Serialization;

namespace PicPayChallenge.Payment.Domain.PagSeguroIntegration.Repositories.Responses
{
    public class SummaryResponse
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("paid")]
        public int Paid { get; set; }

        [JsonPropertyName("refunded")]
        public int Refunded { get; set; }
    }
}