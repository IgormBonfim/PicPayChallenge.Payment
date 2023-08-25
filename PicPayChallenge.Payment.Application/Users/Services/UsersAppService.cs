using AutoMapper;
using NHibernate;
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
        private readonly ISession session;

        public UsersAppService(IUsersService userService, IMapper mapper, ISession session)
        {
            this.userService = userService;
            this.mapper = mapper;
            this.session = session;
        }

        public void AuthUser(UserAuthRequest request)
        {
            throw new NotImplementedException();
        }

        public void RegisterUser(UserRegisterRequest request)
        {
            try
            {
                session.BeginTransaction();
                UserInstanceCommand command = mapper.Map<UserInstanceCommand>(request);

                User user = userService.Instance(command);
                userService.RegisterUser(user);
                session.GetCurrentTransaction().Commit();
            }
            catch (Exception)
            {
                session.GetCurrentTransaction().Rollback();
                throw;
            }
        }
    }
}
