using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Payment.DataTransfer.Payments.Responses
{
    public class TransactionBeginResponse
    {
        public int PaymentMethod { get; set; }
        public decimal Amount { get; set; }
    }
}
