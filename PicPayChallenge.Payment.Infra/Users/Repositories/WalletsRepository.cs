using NHibernate;
using PicPayChallenge.Common.Repositories;
using PicPayChallenge.Payment.Domain.Users.Entities;
using PicPayChallenge.Payment.Domain.Users.Repositories;

namespace PicPayChallenge.Payment.Infra.Users.Repositories
{
    public class WalletsRepository : NHibernateRepository<Wallet>, IWalletsRepository
    {
        public WalletsRepository(ISession session) : base(session) { }
    }
}
