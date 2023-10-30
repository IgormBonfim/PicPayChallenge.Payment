using PicPayChallenge.Common.Entities;
using PicPayChallenge.Common.Exceptions;
using PicPayChallenge.Common.Validators;
using PicPayChallenge.Payment.Domain.Users.Entities;

namespace PicPayChallenge.Payment.Domain.Payments.Entities
{
    public class Transaction : Entity
    {
        public virtual User Sender { get; protected set; }
        public virtual User Reciever { get; protected set; }
        public virtual decimal Amount { get; protected set; }
        public virtual PaymentData Payment { get; protected set; }
        public virtual DateTime TransactionDate { get; protected set; }

        protected Transaction() { }

        public Transaction(User sender, User reciever, decimal amount, PaymentData payment)
        {
            SetSender(sender);
            SetReciever(reciever);
            SetAmount(amount);
            SetPayment(payment);
            SetTransactionDate(DateTime.Now);
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

            Amount = amount;
        }

        public virtual void SetPayment(PaymentData payment)
        {
            payment.NullValidator();

            Payment = payment;
        }
        protected virtual void SetTransactionDate(DateTime transactionDate)
        {
            string propertyName = "Transaction date";
            transactionDate.NullValidator(propertyName);

            TransactionDate = transactionDate;
        }
    }
}
