using System.Text.Json.Serialization;

namespace PicPayChallenge.Payment.Domain.PagSeguroIntegration.Entities
{
    public class Address
    {

        [JsonPropertyName("country")]
        public string Country { get; protected set; }

        [JsonPropertyName("region")]
        public string Region { get; protected set; }

        [JsonPropertyName("region_code")]
        public string RegionCode { get; protected set; }

        [JsonPropertyName("city")]
        public string City { get; protected set; }

        [JsonPropertyName("postal_code")]
        public string PostalCode { get; protected set; }

        [JsonPropertyName("street")]
        public string Street { get; protected set; }

        [JsonPropertyName("number")]
        public string Number { get; protected set; }

        [JsonPropertyName("locality")]
        public string Locality { get; protected set; }

        public Address(string country, string region, string regionCode, string city, string postalCode, string street, string number, string locality)
        {
            Country = country;
            Region = region;
            RegionCode = regionCode;
            City = city;
            PostalCode = postalCode;
            Street = street;
            Number = number;
            Locality = locality;
        }
    }
}