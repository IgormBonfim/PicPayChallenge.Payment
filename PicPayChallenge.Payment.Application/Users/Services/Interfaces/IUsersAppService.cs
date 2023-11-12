using PicPayChallenge.Payment.DataTransfer.Users.Facts;
using PicPayChallenge.Payment.DataTransfer.Users.Requests;
using PicPayChallenge.Payment.DataTransfer.Users.Responses;

namespace PicPayChallenge.Payment.Application.Users.Services.Interfaces
{
    public interface IUsersAppService
    {
        void InsertUser(UserCreatedFact fact);
        UserResponse Get(int id);
    }
}
