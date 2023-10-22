using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Payment.Domain.Payments.Enums
{
    public enum PaymentMethodEnum
    {
        [Description("Wallet")]
        Wallet = 0,

        [Description("Credit Card")]
        CreditCard = 1,

        [Description("Debit Card")]
        DebitCard = 2,

        [Description("Boleto")]
        Boleto = 3,

        [Description("Pix")]
        Pix = 4,
    }
}