using PicPayChallenge.Common.Entities;
using PicPayChallenge.Common.Validators;
using PicPayChallenge.Payment.Domain.Payments.Enums;

namespace PicPayChallenge.Payment.Domain.Payments.Entities
{
    public class CardPayment : Entity
    {
        public virtual string ChargeId { get; set; }
        public virtual CardPaymentMethodEnum CardPaymentMethod { get; protected set; }
        public virtual decimal Amount { get; protected set; }
        public virtual int Installments { get; protected set; }
        public virtual string Brand { get; protected set; }
        public virtual string LastDigits { get; protected set; }
        public virtual int AuthorizationCode { get; protected set; }
        public virtual string NsuHost { get; protected set; }

        protected CardPayment() { }

        public CardPayment(string chargeId, CardPaymentMethodEnum cardPaymentMethod, decimal amount, int installments, string brand, string lastDigits, int authorizationCode, string nsuHost)
        {
            SetChargeId(chargeId);
            SetCardPaymentMethod(cardPaymentMethod);
            SetAmount(amount);
            SetInstallments(installments);
            SetBrand(brand);
            SetLastDigits(lastDigits);
            SetAuthorizationCode(authorizationCode);
            SetNsuHost(nsuHost);
        }

        public virtual void SetChargeId(string chargeId)
        {
            string propertyName = "ChargeId";

            chargeId.MinLength(41, propertyName);
            chargeId.MaxLength(41, propertyName);

            ChargeId = chargeId;
        }

        public virtual void SetCardPaymentMethod(CardPaymentMethodEnum cardPaymentMethod)
        {
            CardPaymentMethod = cardPaymentMethod;
        }

        public virtual void SetAmount(decimal amount)
        {
            Amount = amount;
        }

        public virtual void SetInstallments(int installments)
        {
            Installments = installments;
        }

        public virtual void SetBrand(string brand)
        {
            string propertyName = "Brand";

            brand.MaxLength(20, propertyName);
            
            Brand = brand;
        }

        public virtual void SetLastDigits(string lastDigits)
        {
            string propertyName = "LastDigits";
            lastDigits.MinLength(4, propertyName);
            lastDigits.MaxLength(4, propertyName);

            LastDigits = lastDigits;
        }

        public virtual void SetAuthorizationCode(int authorizationCode)
        {
            AuthorizationCode = authorizationCode;
        }

        public virtual void SetNsuHost(string nsuHost)
        {
            string propertyName = "NsuHost";

            nsuHost.MinLength(4, propertyName);

            nsuHost.MaxLength(20, propertyName);

            NsuHost = nsuHost;
        }
    }
}