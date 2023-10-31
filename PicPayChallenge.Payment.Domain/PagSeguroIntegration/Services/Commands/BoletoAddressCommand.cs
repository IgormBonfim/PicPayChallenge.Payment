namespace PicPayChallenge.Payment.Domain.PagSeguroIntegration.Services.Commands
{
    public class BoletoAddressCommand
    {
        public string Country { get; set; }
        public string Region { get; set; }
        public string RegionCode { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Locality { get; set; }
    }
}