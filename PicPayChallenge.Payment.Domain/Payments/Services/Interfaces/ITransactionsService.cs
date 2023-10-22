using PicPayChallenge.Payment.Domain.Payments.Entities;
using PicPayChallenge.Payment.Domain.Payments.Services.Commands;

namespace PicPayChallenge.Payment.Domain.Payments.Services.Interfaces
{
    public interface ITransactionsService
    {
        Transaction Instance(TransactionInstanceCommand command);
        Transaction RealizeTransaction(TransactionCommand command);
        //Transaction WalletTransaction(Transaction transaction);
        Transaction CardTransaction(TransactionCommand command, string paymentMethod);
        Transaction Insert(Transaction transaction);
    }
}
