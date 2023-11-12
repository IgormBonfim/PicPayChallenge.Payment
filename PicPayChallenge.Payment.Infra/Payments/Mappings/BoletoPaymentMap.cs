using FluentNHibernate.Mapping;
using PicPayChallenge.Payment.Domain.Payments.Entities;
using PicPayChallenge.Payment.Domain.Payments.Enums;

namespace PicPayChallenge.Payment.Infra.Payments.Mappings
{
    public class BoletoPaymentMap : ClassMap<BoletoPayment>
    {
        public BoletoPaymentMap()
        {
            Schema("PicPayChallengePayment");
            Table("BoletoPayment");
            Id(x => x.Id).Column("BoletoPaymentId").GeneratedBy.Identity();
            Map(x => x.ChargeId).Column("ChargeId");
            Map(x => x.BoletoPagSeguroId).Column("BoletoPagSeguroId");
            Map(x => x.Barcode).Column("Barcode");
            Map(x => x.Status).Column("Status").CustomType<BoletoPaymentStatusEnum>();
            Map(x => x.DueDate).Column("DueDate");
            Map(x => x.CreatedAt).Column("CreatedAt");
            Map(x => x.PayedAt).Column("PayedAt");
        }
    }
}
