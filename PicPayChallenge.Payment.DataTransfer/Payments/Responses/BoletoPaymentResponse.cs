using PicPayChallenge.Common.Responses;

namespace PicPayChallenge.Payment.DataTransfer.Payments.Responses
{
    public class BoletoPaymentResponse
    {
        public string ChargeId { get; set; }
        public string BoletoPagSeguroId { get; set; }
        public string Barcode { get; set; }
        public EnumValue Status { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime PayedAt { get; set; }
    }
}
