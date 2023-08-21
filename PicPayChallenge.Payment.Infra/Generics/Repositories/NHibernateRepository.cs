using NHibernate;
using PicPayChallenge.Payment.Domain.Generics.Entities;
using PicPayChallenge.Payment.Domain.Generics.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Payment.Infra.Generics.Repositories
{
    public class NHibernateRepository<T> : INHibernateRepository<T> where T : Entity
    {
        private readonly ISession session;

        public NHibernateRepository(ISession session)
        {
            this.session = session;
        }

        public T Insert(T entity)
        {
            int id = (int)session.Save(entity);
            entity.SetId(id);

            return entity;
        }

        public T Get(int id)
        {
            return session.Get<T>(id);
        }

        public T Update(T entity)
        {
            session.Update(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            session.Delete(entity);
        }

        public IQueryable<T> Query()
        {
            return session.Query<T>();
        }

    }
}
