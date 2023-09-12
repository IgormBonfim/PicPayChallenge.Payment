using AutoMapper;
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

        public TransactionsAppService(ITransactionsService transactionsService, IMapper mapper)
        {
            this.transactionsService = transactionsService;
            this.mapper = mapper;
        }

        public TransactionBeginResponse StartTransaction(int userId, TranscationBeginRequest request)
        {
            TransactionInstanceCommand command = mapper.Map<TransactionInstanceCommand>(request);

            command.SenderId = userId;

            Transaction transaction = transactionsService.Instance(command);

            throw new NotImplementedException();
        }
    }
}
