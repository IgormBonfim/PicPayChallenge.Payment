using PicPayChallenge.Payment.DataTransfer.Users.Requests;
using PicPayChallenge.Payment.DataTransfer.Users.Responses;

namespace PicPayChallenge.Payment.Application.Users.Services.Interfaces
{
    public interface ICashFlowsAppService
    {
        CashFlowResponse Get(CashFlowRequest request);
    }
}
