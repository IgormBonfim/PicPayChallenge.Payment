
using PicPayChallenge.Common.Responses;

namespace PicPayChallenge.Payment.Application.Payments.Services.Interfaces
{
    public interface IPaymentMethodsAppService
    {
        IEnumerable<EnumValue> ListPaymentMethods();
    }
}
