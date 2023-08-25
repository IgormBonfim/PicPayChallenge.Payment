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

        public Wallet Instance(decimal balance)
        {
            return new Wallet(balance);
        }
    }
}
