using PicPayChallenge.Common.Entities;
using PicPayChallenge.Common.Validators;

namespace PicPayChallenge.Payment.Domain.Users.Entities
{
    public class Wallet : Entity
    {
        public virtual decimal Balance { get; protected set; }

        public Wallet() { }

        public Wallet(decimal balance)
        {
            SetBalance(balance);
        }

        public virtual void SetBalance(decimal balance) 
        {
            string propertyName = "Balance";

            balance.NullValidator(propertyName);
            Balance = balance;
        }
    }
}
