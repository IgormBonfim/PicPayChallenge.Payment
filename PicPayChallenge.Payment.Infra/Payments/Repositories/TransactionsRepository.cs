using NHibernate;
using PicPayChallenge.Payment.Domain.Payments.Entities;
using PicPayChallenge.Payment.Domain.Payments.Repositories;
using PicPayChallenge.Common.Repositories;

namespace PicPayChallenge.Payment.Infra.Payments.Repositories
{
    public class TransactionsRepository : NHibernateRepository<Transaction>, ITransactionsRepository
    {
        public TransactionsRepository(ISession session) : base(session) { }
    }
}
