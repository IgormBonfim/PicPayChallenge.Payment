using NHibernate;
using PicPayChallenge.Payment.Domain.Users.Entities;
using PicPayChallenge.Payment.Domain.Users.Repositories;
using PicPayChallenge.Payment.Infra.Generics.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Payment.Infra.Users.Repositories
{
    public class UsersRepository : NHibernateRepository<User>, IUsersRepository
    {
        public UsersRepository(ISession session) : base(session) { }
    }
}
