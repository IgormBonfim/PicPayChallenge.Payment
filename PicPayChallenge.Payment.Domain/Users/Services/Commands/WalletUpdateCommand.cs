namespace PicPayChallenge.Payment.Domain.Users.Services.Commands
{
    public class WalletUpdateCommand
    {
        public int UserId { get; set; }
        public decimal Balance { get; set; }
    }
}
