using PicPayChallenge.Payment.Domain.Users.Entities;
using PicPayChallenge.Payment.Domain.Users.Repositories;
using PicPayChallenge.Payment.Domain.Users.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Payment.Domain.Users.Services
{
    public class WalletsService : IWalletsService
    {
        private readonly IWalletsRepository walletsRepository;

        public WalletsService(IWalletsRepository walletsRepository)
        {
            this.walletsRepository = walletsRepository;
        }

        public Wallet InsertWallet(Wallet wallet)
        {
            return walletsRepository.Insert(wallet);
        }

        public Wallet Instance(decimal balance)
        {
            return new Wallet(balance);
        }
    }
}
