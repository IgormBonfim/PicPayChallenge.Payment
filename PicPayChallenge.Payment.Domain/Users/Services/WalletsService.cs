using PicPayChallenge.Payment.Domain.Users.Entities;
using PicPayChallenge.Payment.Domain.Users.Repositories;
using PicPayChallenge.Payment.Domain.Users.Services.Interfaces;

namespace PicPayChallenge.Payment.Domain.Users.Services
{
    public class WalletsService : IWalletsService
    {
        private readonly IWalletsRepository walletsRepository;

        public WalletsService(IWalletsRepository walletsRepository)
        {
            this.walletsRepository = walletsRepository;
        }

        public Wallet Instance(int userId, decimal balance)
        {
            return new Wallet(userId, balance);
        }
    }
}
