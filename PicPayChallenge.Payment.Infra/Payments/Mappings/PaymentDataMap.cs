using FluentNHibernate.Mapping;
using PicPayChallenge.Payment.Domain.Payments.Entities;
using PicPayChallenge.Payment.Domain.Payments.Enums;

namespace PicPayChallenge.Payment.Infra.Payments.Mappings
{
    public class PaymentDataMap : ClassMap<PaymentData>
    {
        public PaymentDataMap()
        {
            Schema("PicPayChallengePayment");
            Table("Payment");
            Id(x => x.Id).Column("PaymentId").GeneratedBy.Identity();
            Map(x => x.PaymentMethod).Column("PaymentMethod").CustomType<PaymentMethodEnum>();
            References(x => x.CardPayment).Column("CardPaymentId");
            References(x => x.PixPayment).Column("PixPaymentId");
        }
    }
}
