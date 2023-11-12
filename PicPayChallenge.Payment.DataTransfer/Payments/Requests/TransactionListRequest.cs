using PicPayChallenge.Common.Requests;

namespace PicPayChallenge.Payment.DataTransfer.Payments.Requests
{
    public class TransactionListRequest : PaginationRequest
    {
        public int? TransactionId { get; set; }
        public int? UserId { get; set; }
        public int? SenderId { get; set; }
        public int? RecieverId { get; set; }
        public int? PaymentMethod { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? StartAmount { get; set; }
        public decimal? EndAmount { get; set; }
    }
}
