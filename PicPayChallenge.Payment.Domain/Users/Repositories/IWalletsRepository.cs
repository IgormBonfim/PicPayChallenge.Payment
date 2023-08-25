using PicPayChallenge.Common.Repositories.Interfaces;
using PicPayChallenge.Payment.Domain.Users.Entities;

namespace PicPayChallenge.Payment.Domain.Users.Repositories
{
    public interface IWalletsRepository : INHibernateRepository<Wallet>
    {
    }
}
