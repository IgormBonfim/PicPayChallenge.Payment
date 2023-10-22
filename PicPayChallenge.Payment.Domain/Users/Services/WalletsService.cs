using PicPayChallenge.Common.Exceptions;
using PicPayChallenge.Common.Utils;
using PicPayChallenge.Payment.Domain.Users.Entities;
using PicPayChallenge.Payment.Domain.Users.Repositories;
using PicPayChallenge.Payment.Domain.Users.Services.Commands;
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

        public Wallet Get(int userId)
        {
            Wallet wallet = walletsRepository.Get(userId);

            if (wallet.IsNull())
                throw new NotFoundException("Wallet not found");

            return wallet;
        }

        public Wallet Instance(int userId, decimal balance)
        {
            return new Wallet(userId, balance);
        }

        public Wallet Update(WalletUpdateCommand command)
        {
            Wallet wallet = Get(command.UserId);

            wallet.SetBalance(command.Balance);

            return walletsRepository.Update(wallet);
        }
    }
}
