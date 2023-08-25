using NHibernate;
using PicPayChallenge.Common.Repositories;
using PicPayChallenge.Payment.Domain.Users.Entities;
using PicPayChallenge.Payment.Domain.Users.Repositories;

namespace PicPayChallenge.Payment.Infra.Users.Repositories
{
    public class UsersRepository : NHibernateRepository<User>, IUsersRepository
    {
        public UsersRepository(ISession session) : base(session) { }
    }
}
