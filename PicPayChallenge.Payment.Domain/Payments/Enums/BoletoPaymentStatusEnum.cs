using System.ComponentModel;

namespace PicPayChallenge.Payment.Domain.Payments.Enums
{
    public enum BoletoPaymentStatusEnum
    {
        [Description("Waiting")]
        Waiting = 0,

        [Description("Paid")]
        Paid = 1,

        [Description("Canceled")]
        Canceled = 1,
    }
}
