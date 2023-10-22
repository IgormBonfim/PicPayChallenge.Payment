using System.Text.Json.Serialization;

namespace PicPayChallenge.Payment.Domain.PagSeguroIntegration.Entities
{
    public class Card
    {
        [JsonPropertyName("encrypted")]
        public string Encrypted { get; set; }

        [JsonPropertyName("security_code")]
        public string SecurityCode { get; set; }

        [JsonPropertyName("holder")]
        public Holder Holder { get; set; }

        public Card(string encrypted, string securityCode, Holder holder)
        {
            Encrypted = encrypted;
            SecurityCode = securityCode;
            Holder = holder;
        }
    }
}
