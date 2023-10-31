using System.Text.Json.Serialization;

namespace PicPayChallenge.Payment.Domain.PagSeguroIntegration.Entities
{
    public class InstructionLines
    {
        [JsonPropertyName("line_1")]
        public string Line1 { get; protected set; }

        [JsonPropertyName("line_2")]
        public string Line2 { get; protected set; }

        public InstructionLines(string line1, string line2)
        {
            Line1 = line1;
            Line2 = line2;
        }
    }
}
