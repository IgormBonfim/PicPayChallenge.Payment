using AutoMapper;
using PicPayChallenge.Common.Responses;
using PicPayChallenge.Payment.Application.Payments.Services.Interfaces;
using PicPayChallenge.Payment.Domain.Payments.Enums;

namespace PicPayChallenge.Payment.Application.Payments.Services
{
    public class PaymentMethodsAppService : IPaymentMethodsAppService
    {
        private readonly IMapper mapper;

        public PaymentMethodsAppService(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public IEnumerable<EnumValue> ListPaymentMethods()
        {
            IList<PaymentMethodEnum> paymentMethods = new List<PaymentMethodEnum>();

            foreach (int item in Enum.GetValues(typeof(PaymentMethodEnum)))
            {
                paymentMethods.Add((PaymentMethodEnum)item);
            }

            return mapper.Map<IEnumerable<EnumValue>>(paymentMethods);
        }
    }
}
