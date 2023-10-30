using System.Runtime.Serialization;
using PicPayChallenge.Common.Exceptions;

namespace PicPayChallenge.Payment.Domain.PagSeguroIntegration.Exceptions
{
    public class PaymentStatusInvalidException : BusinessRuleException
    {
        public string Code { get; set; }
        public string Status { get; set; }
        public PaymentStatusInvalidException(string code, string status, string message) : base(message) 
        {
            Code = code;
            Status = status;
        }

        public PaymentStatusInvalidException()
        {
        }

        public PaymentStatusInvalidException(string? message) : base(message)
        {
        }

        public PaymentStatusInvalidException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PaymentStatusInvalidException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
