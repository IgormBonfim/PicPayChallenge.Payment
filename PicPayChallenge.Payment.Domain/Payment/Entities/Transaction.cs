using PicPayChallenge.Payment.Common.Exceptions;
using PicPayChallenge.Payment.Common.Validators;
using PicPayChallenge.Payment.Domain.Generics.Entities;
using PicPayChallenge.Payment.Domain.Payment.Enums;
using PicPayChallenge.Payment.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Payment.Domain.Payment.Entities
{
    public class Transaction : Entity
    {
        public virtual User Sender { get; protected set; }
        public virtual User Reciever { get; protected set; }
        public virtual decimal Amout { get; protected set; }
        public virtual PaymentMethodEnum PaymentMethod { get; protected set; }

        public Transaction() { }

        public Transaction(User sender, User reciever, decimal amount, PaymentMethodEnum paymentMethod)
        {
            SetSender(sender);
            SetReciever(reciever);
            SetAmount(amount);
            SetPaymentMethod(paymentMethod);
        }

        public virtual void SetSender(User sender)
        {
            sender.NullValidator();

            Sender = sender;
        }

        public virtual void SetReciever(User reciever)
        {
            reciever.NullValidator();

            Reciever = reciever;
        }

        public virtual void SetAmount(decimal amount)
        {
            if (amount <= 0)
                throw new BadRequestException("Amount have to be greater than zero");

            Amout = amount;
        }

        public virtual void SetPaymentMethod(PaymentMethodEnum paymentMethod)
        {
            paymentMethod.NullValidator();

            PaymentMethod = paymentMethod;
        }
    }
}
