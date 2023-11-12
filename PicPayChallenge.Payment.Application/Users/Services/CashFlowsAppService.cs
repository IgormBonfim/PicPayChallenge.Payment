using PicPayChallenge.Payment.Application.Users.Services.Interfaces;
using PicPayChallenge.Payment.DataTransfer.Users.Requests;
using PicPayChallenge.Payment.DataTransfer.Users.Responses;
using PicPayChallenge.Payment.Domain.Payments.Entities;
using PicPayChallenge.Payment.Domain.Payments.Repositories;
using PicPayChallenge.Payment.Domain.Users.Entities;
using PicPayChallenge.Payment.Domain.Users.Services.Interfaces;

namespace PicPayChallenge.Payment.Application.Users.Services
{
    public class CashFlowsAppService : ICashFlowsAppService
    {
        private readonly IUsersService usersService;
        private readonly ITransactionsRepository transactionsRepository;

        public CashFlowsAppService(IUsersService usersService, ITransactionsRepository transactionsRepository)
        {
            this.usersService = usersService;
            this.transactionsRepository = transactionsRepository;
        }

        public CashFlowResponse Get(CashFlowRequest request)
        {
            User user = usersService.Validate(request.Id);

            var transactionsQuery = transactionsRepository.Query()
                .Where(x => x.Sender.Id == user.Id || x.Reciever.Id == user.Id)
                .Where(x => x.TransactionDate.Date >= request.StartDate.Date)
                .Where(x => x.TransactionDate.Date <= request.EndDate.Date);

            IEnumerable<Transaction> transactions = transactionsRepository.List(transactionsQuery);

            decimal income = transactions.Where(x => x.Reciever.Id == user.Id).Sum(x => x.Amount);
            decimal expense = transactions.Where(x => x.Sender.Id == user.Id).Sum(x => x.Amount);

            return new CashFlowResponse
            {
                Income = income,
                Expense = expense
            };
        }
    }
}
