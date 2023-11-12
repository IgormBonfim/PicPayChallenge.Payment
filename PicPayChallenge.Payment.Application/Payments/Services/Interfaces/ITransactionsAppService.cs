using PicPayChallenge.Common.Responses;
using PicPayChallenge.Payment.DataTransfer.Payments.Requests;
using PicPayChallenge.Payment.DataTransfer.Payments.Responses;

namespace PicPayChallenge.Payment.Application.Payments.Services.Interfaces
{
    public interface ITransactionsAppService
    {
        TransactionResponse StartTransaction(int userId, TranscationRequest request);
        Pagination<TransactionResponse> List(TransactionListRequest request);

    }
}
