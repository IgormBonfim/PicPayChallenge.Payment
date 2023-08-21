using PicPayChallenge.Payment.DataTransfer.Users.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Payment.Application.Users.Services.Interfaces
{
    public interface IUsersAppService
    {
        void RegisterUser(UserRegisterRequest request);
        void AuthUser(UserAuthRequest request);
    }
}
