using PicPayChallenge.Payment.Domain.Payments.Enums;

namespace PicPayChallenge.Payment.Domain.Payments.Services.Commands
{
    public class BoletoPaymentInstanceCommand
    {
        public string ChargeId { get; set; }
        public string BoletoPagSeguroId { get; set; }
        public string Barcode { get; set; }
        public BoletoPaymentStatusEnum Status { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
