using PicPayChallenge.Common.Repositories.Interfaces;
using PicPayChallenge.Payment.Domain.Payments.Entities;

namespace PicPayChallenge.Payment.Domain.Payments.Repositories
{
    public interface ICardPaymentRepository : INHibernateRepository<CardPayment>
    {
    }
}
