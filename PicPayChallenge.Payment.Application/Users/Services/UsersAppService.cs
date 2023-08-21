using AutoMapper;
using PicPayChallenge.Payment.Application.Users.Services.Interfaces;
using PicPayChallenge.Payment.DataTransfer.Users.Requests;
using PicPayChallenge.Payment.Domain.Users.Entities;
using PicPayChallenge.Payment.Domain.Users.Services.Commands;
using PicPayChallenge.Payment.Domain.Users.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Payment.Application.Users.Services
{
    public class UsersAppService : IUsersAppService
    {
        private readonly IUsersService userService;
        private readonly IMapper mapper;

        public UsersAppService(IUsersService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        public void AuthUser(UserAuthRequest request)
        {
            throw new NotImplementedException();
        }

        public void RegisterUser(UserRegisterRequest request)
        {
            UserInstanceCommand command = mapper.Map<UserInstanceCommand>(request);

            User user = userService.Instance(command);
            userService.RegisterUser(user);
        }
    }
}
