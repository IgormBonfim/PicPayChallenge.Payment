﻿using AutoMapper;
using PicPayChallenge.Payment.DataTransfer.Payments.Requests;
using PicPayChallenge.Payment.DataTransfer.Payments.Responses;
using PicPayChallenge.Payment.Domain.Payments.Entities;
using PicPayChallenge.Payment.Domain.Payments.Services.Commands;

namespace PicPayChallenge.Payment.Application.Payments.Profiles
{
    public class BoletoPaymentProfile : Profile
    {
        public BoletoPaymentProfile()
        {
            CreateMap<BoletoPaymentRequest, BoletoPaymentCommand>();
            CreateMap<BoletoPayment, BoletoPaymentResponse>();
        }
    }
}
