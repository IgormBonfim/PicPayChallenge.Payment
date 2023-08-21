using PicPayChallenge.Payment.Domain.Generics.Repositories;
using PicPayChallenge.Payment.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Payment.Domain.Users.Repositories
{
    public interface IWalletsRepository : INHibernateRepository<Wallet>
    {
    }
}
