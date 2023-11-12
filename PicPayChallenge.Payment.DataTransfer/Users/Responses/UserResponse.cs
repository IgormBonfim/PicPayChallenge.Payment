using PicPayChallenge.Common.Responses;

namespace PicPayChallenge.Payment.DataTransfer.Users.Responses
{
    public class UserResponse
    {
        public string FullName { get; set; }
        public string DocumentNumber { get; set; }
        public string Email { get; set; }
        public EnumValue UserType { get; set; }
        public WalletResponse Wallet { get; set; }
    }
}
