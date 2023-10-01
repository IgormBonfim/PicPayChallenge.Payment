using PicPayChallenge.Common.Exceptions;
using PicPayChallenge.Payment.Domain.Payments.Entities;
using PicPayChallenge.Payment.Domain.Payments.Repositories;
using PicPayChallenge.Payment.Domain.Payments.Services.Commands;
using PicPayChallenge.Payment.Domain.Payments.Services.Interfaces;
using PicPayChallenge.Payment.Domain.Users.Entities;
using PicPayChallenge.Payment.Domain.Users.Enums;
using PicPayChallenge.Payment.Domain.Users.Services.Commands;
using PicPayChallenge.Payment.Domain.Users.Services.Interfaces;

namespace PicPayChallenge.Payment.Domain.Payments.Services
{
    public class TransactionsService : ITransactionsService
    {
        private readonly ITransactionsRepository transactionsRepository;
        private readonly IUsersService usersService;
        private readonly IWalletsService walletsService;

        public TransactionsService(ITransactionsRepository transactionsRepository, IUsersService usersService, IWalletsService walletsService)
        {
            this.transactionsRepository = transactionsRepository;
            this.usersService = usersService;
            this.walletsService = walletsService;
        }

        public Transaction Instance(TransactionInstanceCommand command)
        {
            User sender = usersService.Validate(command.SenderId);
            User reciever = usersService.Validate(command.RecieverId);

            return new Transaction(sender, reciever, command.Amount, command.PaymentMethod);
        }

        public Transaction RealizeTransaction(Transaction transaction)
        {
            if (transaction.Sender.UserType == UserTypeEnum.Store)
                throw new BusinessRuleException("Stores can't make transaction");

            switch (transaction.PaymentMethod)
            {
                case Enums.PaymentMethodEnum.Wallet:
                    transaction = WalletTransaction(transaction);
                    break;

                case Enums.PaymentMethodEnum.CreditCard:
                    throw new NotImplementedException();

                case Enums.PaymentMethodEnum.DebitCard:
                    throw new NotImplementedException();

                case Enums.PaymentMethodEnum.Boleto:
                    throw new NotImplementedException();

                default:
                    throw new BusinessRuleException($"Payment Method '{transaction.PaymentMethod}' doesn't exists");
            }

            return transaction;
        }

        public Transaction WalletTransaction(Transaction transaction)
        {
            if (transaction.Amount > transaction.Sender.Wallet.Balance)
                throw new BusinessRuleException("Insufficient balance");

            decimal newSenderBalance = transaction.Sender.Wallet.Balance - transaction.Amount;
            decimal newRecieverBalance = transaction.Reciever.Wallet.Balance + transaction.Amount;

            WalletUpdateCommand senderWallet = new WalletUpdateCommand
            {
                UserId = transaction.Sender.Id,
                Balance = newSenderBalance,
            };

            transaction.Sender.SetWallet(walletsService.Update(senderWallet));

            WalletUpdateCommand recieverWallet = new WalletUpdateCommand
            {
                UserId = transaction.Reciever.Id,
                Balance = newRecieverBalance,
            };

           transaction.Reciever.SetWallet(walletsService.Update(recieverWallet));

            return transactionsRepository.Insert(transaction);
        }
    }
}
