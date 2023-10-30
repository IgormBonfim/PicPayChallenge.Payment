using PicPayChallenge.Common.Exceptions;
using PicPayChallenge.Common.Utils;
using PicPayChallenge.Payment.Domain.PagSeguroIntegration.Entities;
using PicPayChallenge.Payment.Domain.PagSeguroIntegration.Repositories.Responses;
using PicPayChallenge.Payment.Domain.PagSeguroIntegration.Services.Commands;
using PicPayChallenge.Payment.Domain.PagSeguroIntegration.Services.Interfaces;
using PicPayChallenge.Payment.Domain.Payments.Entities;
using PicPayChallenge.Payment.Domain.Payments.Enums;
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
        private readonly IPagSeguroIntegrationService pagSeguroIntegrationService;
        private readonly ICardPaymentService cardPaymentService;
        private readonly IPaymentDataService paymentDataService;

        public TransactionsService(
            ITransactionsRepository transactionsRepository, 
            IUsersService usersService, 
            IWalletsService walletsService, 
            IPagSeguroIntegrationService pagSeguroIntegrationService, 
            ICardPaymentService cardPaymentService,
            IPaymentDataService paymentDataService)
        {
            this.transactionsRepository = transactionsRepository;
            this.usersService = usersService;
            this.walletsService = walletsService;
            this.pagSeguroIntegrationService = pagSeguroIntegrationService;
            this.cardPaymentService = cardPaymentService;
            this.paymentDataService = paymentDataService;
        }

        public Transaction CardTransaction(TransactionCommand command, string paymentMethod)
        {
            int installments = command.Payment.PaymentMethod == PaymentMethodEnum.CreditCard ? command.Payment.CardPayment.Installments : 1;

            CreateChargeCommand paymentCommand = new CreateChargeCommand
            {
                Amount = command.Amount,
                Installments = installments,
                EncryptedCard = command.Payment.CardPayment.EncryptedCard,
                HolderName = command.Payment.CardPayment.HolderName,
                SecurityCode = command.Payment.CardPayment.SecurityCode,
                PaymentMethod = paymentMethod,
            };

            ChargeResponse charge = pagSeguroIntegrationService.ProcessPayment(paymentCommand);

            CardPaymentInstanceCommand paymentInstanceCommand = new CardPaymentInstanceCommand
            {
                ChargeId = charge.Id,
                CardPaymentMethod = command.Payment.PaymentMethod == PaymentMethodEnum.CreditCard ? CardPaymentMethodEnum.CreditCard : CardPaymentMethodEnum.DebitCard,
                Amount = command.Amount,
                Installments = command.Payment.CardPayment.Installments,
                Brand = charge.PaymentMethod.Card.Brand,
                LastDigits = charge.PaymentMethod.Card.LastDigits,
                AuthorizationCode = Convert.ToInt32(charge.PaymentResponse.PaymentData.AuthorizationCode),
                NsuHost = charge.PaymentResponse.PaymentData.Nsu,

            };

            CardPayment cardPayment = cardPaymentService.Instance(paymentInstanceCommand);
            cardPayment = cardPaymentService.Insert(cardPayment);

            PaymentDataInstanceCommand paymentDataInstanceCommand = new PaymentDataInstanceCommand 
            {
                PaymentMethod = command.Payment.PaymentMethod,
                CardPayment = cardPayment,
            };

            PaymentData paymentData = paymentDataService.InstanceCardPayment(paymentDataInstanceCommand);

            TransactionInstanceCommand transactionInstanceCommand = new TransactionInstanceCommand 
            {
                Amount = command.Amount,
                PaymentData = paymentData,
                RecieverId = command.RecieverId,
                SenderId = command.SenderId,
            };

            Transaction transaction = Instance(transactionInstanceCommand);

            decimal newRecieverBalance = transaction.Reciever.Wallet.Balance + transaction.Amount;

            WalletUpdateCommand recieverWallet = new WalletUpdateCommand
            {
                UserId = transaction.Reciever.Id,
                Balance = newRecieverBalance,
            };

            transaction.Reciever.SetWallet(walletsService.Update(recieverWallet));

            return Insert(transaction);
        }

        public Transaction Insert(Transaction transaction)
        {
            return transactionsRepository.Insert(transaction);
        }

        public Transaction Instance(TransactionInstanceCommand command)
        {
            User sender = usersService.Validate(command.SenderId);
            User reciever = usersService.Validate(command.RecieverId);

            return new Transaction(sender, reciever, command.Amount, command.PaymentData);
        }

        public Transaction RealizeTransaction(TransactionCommand command)
        {
            Transaction? transaction = null;

            User sender = usersService.Validate(command.SenderId);

            if (sender.UserType == UserTypeEnum.Store)
                throw new BusinessRuleException("Stores can't make transaction");

            switch (command.Payment.PaymentMethod)
            {
                case PaymentMethodEnum.Wallet:
                    //transaction = WalletTransaction(transaction);
                    break;

                case PaymentMethodEnum.CreditCard:
                    transaction = CardTransaction(command, "CREDIT_CARD");
                    break;

                case PaymentMethodEnum.DebitCard:
                    //transaction = CardTransaction(command, "DEBIT_CARD");
                    throw new NotImplementedException();
                    break;

                case PaymentMethodEnum.Boleto:
                    throw new NotImplementedException();

                case PaymentMethodEnum.Pix:
                    throw new NotImplementedException();

                default:
                    throw new BusinessRuleException($"Payment Method '{command.Payment.PaymentMethod}' doesn't exists");
            }

            return transaction!;
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
