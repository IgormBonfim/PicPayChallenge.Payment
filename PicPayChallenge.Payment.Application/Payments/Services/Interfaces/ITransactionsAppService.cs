using PicPayChallenge.Payment.DataTransfer.Payments.Requests;
using PicPayChallenge.Payment.DataTransfer.Payments.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Payment.Application.Payments.Services.Interfaces
{
    public interface ITransactionsAppService
    {
        TransactionBeginResponse StartTransaction(int userId, TranscationBeginRequest request);
    }
}
