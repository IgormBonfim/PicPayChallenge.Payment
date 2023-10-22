using FluentNHibernate.Mapping;
using PicPayChallenge.Payment.Domain.Payments.Entities;

namespace PicPayChallenge.Payment.Infra.Payments.Mappings
{
    public class PixPaymentMap : ClassMap<PixPayment>
    {
        public PixPaymentMap()
        {
            Schema("PicPayChallengePayment");
            Table("PixPayment");
            Id(x => x.Id).Column("PixPaymentId").GeneratedBy.Identity();
        }
    }
}
