using PicPayChallenge.Common.Entities;
using PicPayChallenge.Payment.Domain.Payments.Enums;

namespace PicPayChallenge.Payment.Domain.Payments.Entities
{
    public class BoletoPayment : Entity
    {
        public virtual string ChargeId { get; protected set; }
        public virtual string BoletoPagSeguroId { get; protected set; }
        public virtual string Barcode { get; protected set; }
        public virtual BoletoPaymentStatusEnum Status { get; protected set; }
        public virtual DateTime DueDate { get; protected set; }
        public virtual DateTime CreatedAt { get; protected set; }
        public virtual DateTime PayedAt { get; protected set; }

        protected BoletoPayment() { }

        public BoletoPayment(string chargeId, string boletoPagSeguroId, string barcode, BoletoPaymentStatusEnum status, DateTime dueDate, DateTime createdAt)
        {
            ChargeId = chargeId;
            BoletoPagSeguroId = boletoPagSeguroId;
            Barcode = barcode;
            Status = status;
            DueDate = dueDate;
            CreatedAt = createdAt;

            ValidateDomain();
        }

        public virtual void Update(BoletoPaymentStatusEnum status, DateTime payedAt)
        {
            Status = status;
            PayedAt = payedAt;

            ValidateDomain();
        }

        protected virtual void ValidateDomain()
        {

        }
    }
}