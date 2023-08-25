using PicPayChallenge.Payment.Domain.Payments.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Payment.Domain.Payments.Services.Commands
{
    public class TransactionInstanceCommand
    {
        public int SenderId { get; set; }
        public int RecieverId { get; set; }
        public PaymentMethodEnum PaymentMethod { get; set; }
        public decimal Amount { get; set; }
    }
}
