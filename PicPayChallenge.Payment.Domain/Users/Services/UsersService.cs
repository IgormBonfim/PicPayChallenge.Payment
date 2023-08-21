using PicPayChallenge.Payment.Common.Exceptions;
using PicPayChallenge.Payment.Common.Utils;
using PicPayChallenge.Payment.Domain.Users.Entities;
using PicPayChallenge.Payment.Domain.Users.Repositories;
using PicPayChallenge.Payment.Domain.Users.Services.Commands;
using PicPayChallenge.Payment.Domain.Users.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Payment.Domain.Users.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository usersRepository;
        private readonly IWalletsService walletsService;

        public UsersService(IUsersRepository usersRepository, IWalletsService walletsService)
        {
            this.usersRepository = usersRepository;
            this.walletsService = walletsService;
        }

        public User Instance(UserInstanceCommand command)
        {
            decimal initialBalance = 0M;

            Wallet wallet = walletsService.Instance(initialBalance);
            wallet = walletsService.InsertWallet(wallet);

            return new User(command.FullName, command.DocumentNumber, command.Email, command.Password, command.UserType, wallet);
        }

        public void RegisterUser(User user)
        {
            var userQuery = usersRepository.Query();

            User? userEmail = userQuery.Where(x => x.Email == user.Email).FirstOrDefault();

            if (userEmail.IsNotNull())
                throw new BusinessRuleException("The user only can have one account per email.");

            User? userDocument = userQuery.Where(x => x.DocumentNumber == user.DocumentNumber).FirstOrDefault();

            if (userDocument.IsNotNull())
                throw new BusinessRuleException("The user only can have one account per document number.");

            usersRepository.Insert(user);
        }

        public User Validate(int userId)
        {
            User user = usersRepository.Get(userId);

            if (user.IsNull())
                throw new NotFoundException("User not found");

            return user;
        }
    }
}
