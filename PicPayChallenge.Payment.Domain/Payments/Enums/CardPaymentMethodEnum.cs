using System.ComponentModel;

namespace PicPayChallenge.Payment.Domain.Payments.Enums
{
    public enum CardPaymentMethodEnum
    {
        [Description("Credit Card")]
        CreditCard = 1,

        [Description("Debit Card")]
        DebitCard = 2,
    }
}
