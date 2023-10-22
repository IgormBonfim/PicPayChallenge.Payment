﻿using NHibernate;
using PicPayChallenge.Common.Repositories;
using PicPayChallenge.Payment.Domain.Payments.Entities;
using PicPayChallenge.Payment.Domain.Payments.Repositories;

namespace PicPayChallenge.Payment.Infra.Payments.Repositories
{
    public class CardPaymentRepository : NHibernateRepository<CardPayment>, ICardPaymentRepository
    {
        public CardPaymentRepository(ISession session) : base(session) { }
    }
}
