namespace PicPayChallenge.Payment.DataTransfer.Users.Requests
{
    public class CashFlowRequest
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
