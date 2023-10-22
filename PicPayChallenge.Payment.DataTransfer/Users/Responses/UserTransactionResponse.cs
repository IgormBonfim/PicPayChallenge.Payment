using PicPayChallenge.Common.Responses;

namespace PicPayChallenge.Payment.DataTransfer.Users.Responses
{
    public class UserTransactionResponse
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public EnumValue UserType { get; set; }
    }
}
