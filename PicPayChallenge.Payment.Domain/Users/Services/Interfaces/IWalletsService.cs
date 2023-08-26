using PicPayChallenge.Payment.Domain.Users.Entities;

namespace PicPayChallenge.Payment.Domain.Users.Services.Interfaces
{
    public interface IWalletsService 
    {
        Wallet Instance(int userId, decimal balance);
    }
}
