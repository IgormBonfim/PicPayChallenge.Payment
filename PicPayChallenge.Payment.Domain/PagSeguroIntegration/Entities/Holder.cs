using System.Text.Json.Serialization;

namespace PicPayChallenge.Payment.Domain.PagSeguroIntegration.Entities
{
    public class Holder
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        public Holder(string name)
        {
            Name = name;
        }
    }
}
