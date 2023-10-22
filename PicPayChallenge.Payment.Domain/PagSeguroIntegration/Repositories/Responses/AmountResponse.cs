using System.Text.Json.Serialization;

namespace PicPayChallenge.Payment.Domain.PagSeguroIntegration.Repositories.Responses
{
    public class AmountResponse
    {
        [JsonPropertyName("value")]
        public int Value { get; set; }        
        
        [JsonPropertyName("currency")]
        public string Currency { get; set; }   
        
        [JsonPropertyName("summary")]
        public SummaryResponse Sumarry { get; set; }
    }
}