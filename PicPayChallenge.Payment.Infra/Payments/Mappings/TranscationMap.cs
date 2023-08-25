using FluentNHibernate.Mapping;
using PicPayChallenge.Payment.Domain.Payments.Entities;
using PicPayChallenge.Payment.Domain.Payments.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Payment.Infra.Payments.Mappings
{
    public class TranscationMap : ClassMap<Transaction>
    {
        public TranscationMap()
        {
            Table("Transaction");
            Id(x => x.Id).Column("TransactionId").GeneratedBy.Identity();
            References(x => x.Sender).Column("SenderId");
            References(x => x.Reciever).Column("RecieverId");
            Map(x => x.Amount).Column("Amount");
            Map(x => x.PaymentMethod).Column("PaymentMethod").CustomType<PaymentMethodEnum>();
            Map(x => x.TransactionDate).Column("TransactionDate");
        }
    }
}