using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Payment.DataTransfer.Payments.Requests
{
    public class TranscationBeginRequest
    {
        public int RecieverId { get; set; }
        public int PaymentMethod { get; set; }
        public decimal Amount { get; set; }
    }
}