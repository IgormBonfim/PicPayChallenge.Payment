using PicPayChallenge.Payment.Domain.Users.Entities;
using PicPayChallenge.Payment.Domain.Users.Services.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Payment.Domain.Users.Services.Interfaces
{
    public interface IUsersService
    {
        User Instance(UserInstanceCommand command);
        void RegisterUser(User user);
        User Validate(int userId);
    }
}
