using FluentNHibernate.Mapping;
using PicPayChallenge.Payment.Domain.Payments.Entities;

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
            References(x => x.Payment).Column("PaymentId").Cascade.All();
            Map(x => x.Amount).Column("Amount");
            Map(x => x.TransactionDate).Column("TransactionDate");
        }
    }
}