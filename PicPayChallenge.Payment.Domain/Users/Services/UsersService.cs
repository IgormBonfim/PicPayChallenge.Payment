using PicPayChallenge.Common.Exceptions;
using PicPayChallenge.Common.Utils;
using PicPayChallenge.Payment.Domain.Users.Entities;
using PicPayChallenge.Payment.Domain.Users.Repositories;
using PicPayChallenge.Payment.Domain.Users.Services.Commands;
using PicPayChallenge.Payment.Domain.Users.Services.Interfaces;

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

            Wallet wallet = walletsService.Instance(command.Id, initialBalance);

            return new User(command.Id, command.FullName, command.DocumentNumber, command.Email, command.UserType, wallet);
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
