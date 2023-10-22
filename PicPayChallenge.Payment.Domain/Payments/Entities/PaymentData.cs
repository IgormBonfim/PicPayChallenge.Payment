using PicPayChallenge.Common.Entities;
using PicPayChallenge.Common.Exceptions;
using PicPayChallenge.Common.Utils;
using PicPayChallenge.Common.Validators;
using PicPayChallenge.Payment.Domain.Payments.Enums;

namespace PicPayChallenge.Payment.Domain.Payments.Entities
{
    public class PaymentData : Entity
    {
        public virtual int PaymentId { get; protected set; }
        public virtual PaymentMethodEnum PaymentMethod { get; protected set; }
        public virtual CardPayment? CardPayment { get; protected set; }
        public virtual PixPayment? PixPayment { get; protected set; }

        protected PaymentData() { }

        public PaymentData(PaymentMethodEnum paymentMethod, CardPayment? cardPayment, PixPayment? pixPayment)
        {
            SetPaymentMethod(paymentMethod);
            SetCardPayment(cardPayment);
            SetPixPayment(pixPayment);
        }

        public PaymentData(PaymentMethodEnum paymentMethod, CardPayment cardPayment)
        {
            SetPaymentMethod(paymentMethod);
            SetCardPayment(cardPayment);
        }

        public PaymentData(PaymentMethodEnum paymentMethod, PixPayment pixPayment)
        {
            SetPaymentMethod(paymentMethod);
            SetPixPayment(pixPayment);
        }

        public virtual void SetPaymentMethod(PaymentMethodEnum paymentMethod)
        {
            paymentMethod.NullValidator();

            PaymentMethod = paymentMethod;
        }

        public virtual void SetCardPayment(CardPayment? cardPayment)
        {
            if (PaymentMethod == PaymentMethodEnum.CreditCard && cardPayment.IsNull())
                throw new BusinessRuleException();

            CardPayment = cardPayment;
        }

        public virtual void SetPixPayment(PixPayment? pixPayment)
        {
            if (PaymentMethod == PaymentMethodEnum.Pix && pixPayment.IsNull())
                throw new BusinessRuleException();

            PixPayment = pixPayment;
        }
    }
}
