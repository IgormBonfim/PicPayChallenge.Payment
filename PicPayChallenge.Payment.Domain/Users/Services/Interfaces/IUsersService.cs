using PicPayChallenge.Payment.Domain.Users.Entities;
using PicPayChallenge.Payment.Domain.Users.Services.Commands;

namespace PicPayChallenge.Payment.Domain.Users.Services.Interfaces
{
    public interface IUsersService
    {
        User Instance(UserInstanceCommand command);
        void RegisterUser(User user);
        User Validate(int userId);
        User Update(UserUpdateCommand command);
    }
}
