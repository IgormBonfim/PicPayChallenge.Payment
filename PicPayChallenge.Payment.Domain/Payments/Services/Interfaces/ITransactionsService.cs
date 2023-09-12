using PicPayChallenge.Payment.Domain.Payments.Entities;
using PicPayChallenge.Payment.Domain.Payments.Services.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Payment.Domain.Payments.Services.Interfaces
{
    public interface ITransactionsService
    {
        Transaction Instance(TransactionInstanceCommand command);
        Transaction RealizeTransaction(Transaction transaction);
        //Transaction WalletTransaction(Transaction transaction);
    }
}
