using AutoMapper;
using PicPayChallenge.Payment.DataTransfer.Users.Facts;
using PicPayChallenge.Payment.DataTransfer.Users.Responses;
using PicPayChallenge.Payment.Domain.Users.Entities;
using PicPayChallenge.Payment.Domain.Users.Services.Commands;

namespace PicPayChallenge.Payment.Application.Users.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<UserCreatedFact, UserInstanceCommand>();
            CreateMap<User, UserTransactionResponse>();
        }
    }
}
