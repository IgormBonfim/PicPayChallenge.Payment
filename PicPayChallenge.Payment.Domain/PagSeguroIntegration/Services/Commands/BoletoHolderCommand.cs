namespace PicPayChallenge.Payment.Domain.PagSeguroIntegration.Services.Commands
{
    public class BoletoHolderCommand
    {
        public string Name { get; set; }
        public string TaxId { get; set; }
        public string Email { get; set; }
        public BoletoAddressCommand Address { get; set; }
    }
}