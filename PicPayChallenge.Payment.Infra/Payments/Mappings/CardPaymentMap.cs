using FluentNHibernate.Mapping;
using PicPayChallenge.Payment.Domain.Payments.Entities;
using PicPayChallenge.Payment.Domain.Payments.Enums;

namespace PicPayChallenge.Payment.Infra.Payments.Mappings
{
    public class CardPaymentMap : ClassMap<CardPayment>
    {
        public CardPaymentMap()
        {
            Schema("PicPayChallengePayment");
            Table("CardPayment");
            Id(x => x.Id).Column("CardPaymentId").GeneratedBy.Identity();
            Map(x => x.ChargeId).Column("ChargeId");
            Map(x => x.CardPaymentMethod).Column("CardPaymentMethod").CustomType<CardPaymentMethodEnum>();
            Map(x => x.Amount).Column("Amount");
            Map(x => x.Installments).Column("Installments");
            Map(x => x.Brand).Column("Brand");
            Map(x => x.LastDigits).Column("LastDigits");
            Map(x => x.AuthorizationCode).Column("AuthorizationCode");
            Map(x => x.NsuHost).Column("NsuHost");
        }
    }
}
