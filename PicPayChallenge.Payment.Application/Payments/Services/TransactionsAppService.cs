using AutoMapper;
using NHibernate;
using PicPayChallenge.Payment.Application.Payments.Services.Interfaces;
using PicPayChallenge.Payment.DataTransfer.Payments.Requests;
using PicPayChallenge.Payment.DataTransfer.Payments.Responses;
using PicPayChallenge.Payment.Domain.Payments.Entities;
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
        private readonly IMapper mapper;
        private readonly ISession session;

        public TransactionsAppService(ITransactionsService transactionsService, IMapper mapper, ISession session)
        {
            this.transactionsService = transactionsService;
            this.mapper = mapper;
            this.session = session;
        }

        public TransactionBeginResponse StartTransaction(int userId, TranscationBeginRequest request)
        {
            try
            {
                session.BeginTransaction();

                TransactionInstanceCommand command = mapper.Map<TransactionInstanceCommand>(request);

                command.SenderId = userId;

                Transaction transaction = transactionsService.Instance(command);

                transaction = transactionsService.RealizeTransaction(transaction);

                TransactionBeginResponse response = mapper.Map<TransactionBeginResponse>(transaction);

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
