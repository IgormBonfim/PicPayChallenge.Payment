using AutoMapper;
using NHibernate;
using PicPayChallenge.Common.Responses;
using PicPayChallenge.Common.Utils;
using PicPayChallenge.Payment.Application.Payments.Services.Interfaces;
using PicPayChallenge.Payment.DataTransfer.Payments.Requests;
using PicPayChallenge.Payment.DataTransfer.Payments.Responses;
using PicPayChallenge.Payment.Domain.Payments.Entities;
using PicPayChallenge.Payment.Domain.Payments.Repositories;
using PicPayChallenge.Payment.Domain.Payments.Services.Commands;
using PicPayChallenge.Payment.Domain.Payments.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Payment.Application.Payments.Services
{
    public class TransactionsAppService : ITransactionsAppService
    {
        private readonly ITransactionsService transactionsService;
        private readonly ITransactionsRepository transactionsRepository;
        private readonly IMapper mapper;
        private readonly ISession session;

        public TransactionsAppService(ITransactionsService transactionsService, ITransactionsRepository transactionsRepository, IMapper mapper, ISession session)
        {
            this.transactionsService = transactionsService;
            this.transactionsRepository = transactionsRepository;
            this.mapper = mapper;
            this.session = session;
        }

        public Pagination<TransactionResponse> List(TransactionListRequest request)
        {
            IQueryable<Transaction> query = transactionsRepository.Query();

            if (request.UserId.IsNotNull())
                query = query.Where(x => x.Sender.Id == request.UserId || x.Reciever.Id == request.UserId);
 
            if (request.SenderId.IsNotNull())
                query = query.Where(x => x.Sender.Id == request.SenderId);

            if (request.RecieverId.IsNotNull())
                query = query.Where(x => x.Reciever.Id == request.RecieverId);

            if (request.PaymentMethod.IsNotNull())
                query = query.Where(x => (int)x.Payment.PaymentMethod == request.PaymentMethod);

            if (request.StartDate.IsNotNull())
                query = query.Where(x => x.TransactionDate.Date >= request.StartDate!.Value.Date);            
            
            if (request.EndDate.IsNotNull())
                query = query.Where(x => x.TransactionDate.Date <= request.EndDate!.Value.Date);            
            
            if (request.StartAmount.IsNotNull())
                query = query.Where(x => x.Amount >= request.StartAmount);            
            
            if (request.EndAmount.IsNotNull())
                query = query.Where(x => x.Amount <= request.EndAmount);

            Pagination<Transaction> transactions = transactionsRepository.ListPaginated(query, request.ItemsPerPage, request.Page);

            return mapper.Map<Pagination<TransactionResponse>>(transactions);
        }
        public decimal? StartAmount { get; set; }
        public decimal? EndAmount { get; set; }

        public TransactionResponse StartTransaction(int userId, TranscationRequest request)
        {
            try
            {
                session.BeginTransaction();

                TransactionCommand command = mapper.Map<TransactionCommand>(request);

                command.SenderId = userId;

                Transaction transaction = transactionsService.RealizeTransaction(command);

                TransactionResponse response = mapper.Map<TransactionResponse>(transaction);

                session.GetCurrentTransaction().Commit();

                return response;

            }
            catch (Exception)
            {
                session.GetCurrentTransaction().Rollback();
                throw;
            }
        }
    }
}
