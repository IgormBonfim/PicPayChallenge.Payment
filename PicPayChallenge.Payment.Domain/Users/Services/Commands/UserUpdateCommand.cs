namespace PicPayChallenge.Payment.Domain.Users.Services.Commands
{
    public class UserUpdateCommand
    {
        public int Id { get; set; }
        public WalletUpdateCommand Wallet { get; set; }
    }
}
