using AutoMapper;
using PicPayChallenge.Payment.DataTransfer.Users.Responses;
using PicPayChallenge.Payment.Domain.Users.Entities;

namespace PicPayChallenge.Payment.Application.Users.Profiles
{
    public class WalletProfile : Profile
    {
        public WalletProfile()
        {
            CreateMap<Wallet, WalletResponse>();
        }
    }
}
