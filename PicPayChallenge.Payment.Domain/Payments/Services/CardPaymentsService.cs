﻿using PicPayChallenge.Payment.Domain.Payments.Entities;
using PicPayChallenge.Payment.Domain.Payments.Repositories;
using PicPayChallenge.Payment.Domain.Payments.Services.Commands;
using PicPayChallenge.Payment.Domain.Payments.Services.Interfaces;

namespace PicPayChallenge.Payment.Domain.Payments.Services
{
    public class CardPaymentsService : ICardPaymentsService
    {
        private readonly ICardPaymentsRepository cardPaymentRepository;

        public CardPaymentsService(ICardPaymentsRepository cardPaymentRepository)
        {
            this.cardPaymentRepository = cardPaymentRepository;
        }
        public CardPayment Insert(CardPayment cardPayment)
        {
            return cardPaymentRepository.Insert(cardPayment);
        }

        public CardPayment Instance(CardPaymentInstanceCommand command)
        {
            return new CardPayment(command.ChargeId, command.CardPaymentMethod, command.Amount, command.Installments, command.Brand, command.LastDigits, command.AuthorizationCode, command.NsuHost);
        }
    }
}
