using PicPayChallenge.Payment.DataTransfer.Users.Facts;

namespace PicPayChallenge.Payment.Application.Users.Services.Interfaces
{
    public interface IUsersAppService
    {
        void InsertUser(UserCreatedFact fact);
    }
}
