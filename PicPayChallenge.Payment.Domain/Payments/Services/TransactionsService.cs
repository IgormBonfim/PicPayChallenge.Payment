using PicPayChallenge.Payment.Domain.Payments.Entities;
using PicPayChallenge.Payment.Domain.Payments.Repositories;
using PicPayChallenge.Payment.Domain.Payments.Services.Commands;
using PicPayChallenge.Payment.Domain.Payments.Services.Interfaces;
using PicPayChallenge.Payment.Domain.Users.Entities;
using PicPayChallenge.Payment.Domain.Users.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Payment.Domain.Payments.Services
{
    public class TransactionsService : ITransactionsService
    {
        private readonly ITransactionsRepository transactionsRepository;
        private readonly IUsersService usersService;

        public TransactionsService(ITransactionsRepository transactionsRepository, IUsersService usersService)
        {
            this.transactionsRepository = transactionsRepository;
            this.usersService = usersService;
        }

        public Transaction Instance(TransactionInstanceCommand command)
        {
            User sender = usersService.Validate(command.SenderId);
            User reciever = usersService.Validate(command.RecieverId);

            return new Transaction(sender, reciever, command.Amount, command.PaymentMethod);
        }
    }
}
