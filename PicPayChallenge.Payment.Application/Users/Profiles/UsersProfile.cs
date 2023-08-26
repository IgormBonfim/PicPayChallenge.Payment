using AutoMapper;
using PicPayChallenge.Payment.DataTransfer.Users.Facts;
using PicPayChallenge.Payment.Domain.Users.Services.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Payment.Application.Users.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<UserCreatedFact, UserInstanceCommand>();
        }
    }
}
