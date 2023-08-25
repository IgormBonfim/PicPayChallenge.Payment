using PicPayChallenge.Common.Repositories.Interfaces;
using PicPayChallenge.Payment.Domain.Payments.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Payment.Domain.Payments.Repositories
{
    public interface ITransactionsRepository : INHibernateRepository<Transaction> { }
}
