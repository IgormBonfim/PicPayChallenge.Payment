using PicPayChallenge.Payment.Domain.Users.Entities;
using PicPayChallenge.Payment.Domain.Users.Services.Commands;

namespace PicPayChallenge.Payment.Domain.Users.Services.Interfaces
{
    public interface IWalletsService 
    {
        Wallet Instance(int userId, decimal balance);
        Wallet Update(WalletUpdateCommand command);
        Wallet Get(int userId);
    }
}
