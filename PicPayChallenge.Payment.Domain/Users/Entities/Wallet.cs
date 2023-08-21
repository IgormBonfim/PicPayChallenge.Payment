using PicPayChallenge.Payment.Common.Validators;
using PicPayChallenge.Payment.Domain.Generics.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
