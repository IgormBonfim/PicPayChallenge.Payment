using System.Text.Json.Serialization;

namespace PicPayChallenge.Payment.Domain.PagSeguroIntegration.Repositories.Responses
{
    public class InstructionLinesResponse
    {
        [JsonPropertyName("line_1")]
        public string Line1 { get; set; }

        [JsonPropertyName("line_2")]
        public string Line2 { get; set; }
    }
}