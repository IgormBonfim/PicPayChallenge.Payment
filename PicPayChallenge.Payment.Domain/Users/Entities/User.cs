using PicPayChallenge.Payment.Common.Exceptions;
using PicPayChallenge.Payment.Common.Utils;
using PicPayChallenge.Payment.Common.Validators;
using PicPayChallenge.Payment.Domain.Generics.Entities;
using PicPayChallenge.Payment.Domain.Users.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Payment.Domain.Users.Entities
{
    public class User : Entity
    {
        public virtual string FullName { get; protected set; }
        public virtual string DocumentNumber { get; protected set; }
        public virtual string Email { get; protected set; }
        public virtual string Password { get; protected set; }
        public virtual UserTypeEnum UserType { get; protected set; }
        public virtual DateTime CreatedAt { get; protected set; }
        public virtual DateTime? UpdatedAt { get; protected set; }
        public virtual Wallet Wallet { get; protected set; }

        public User() { }

        public User(string fullName, string documentNumber, string email, string password, UserTypeEnum userType, Wallet wallet)
        {
            SetFullName(fullName);
            SetDocumentNumber(documentNumber);
            SetEmail(email);
            SetPassword(password);
            SetUserType(userType);
            SetCreatedAt(DateTime.Now);
            SetWallet(wallet);
        }


        public virtual void SetFullName(string fullName)
        {
            string propertyName = "Full Name";
            fullName.NullValidator(propertyName);
            fullName.MinLength(5, propertyName);
            fullName.MaxLength(100, propertyName);

            FullName = fullName;
        }

        public virtual void SetDocumentNumber(string documentNumber)
        {
            string propertyName = "Document Number";
            documentNumber.NullValidator(propertyName);

            DocumentNumber = documentNumber;
        }

        public virtual void SetEmail(string email)
        {
            string propertyName = "Email";

            propertyName.NullValidator(propertyName);

            if (!EmailUtil.IsValid(email))
                throw new BadRequestException("Email isn't valid");

            Email = email;
        }

        public virtual void SetPassword(string password)
        {
            string propertyName = "Password";
            password.NullValidator(propertyName);
            password.MinLength(8, propertyName);

            Password = PasswordUtil.GenerateHash(password);
        }

        public virtual void SetUserType(UserTypeEnum userType)
        {
            string propertyName = "User Type";
            userType.NullValidator(propertyName);
            
            UserType = userType;
        }

        protected virtual void SetCreatedAt(DateTime createdAt)
        {
            string propertyName = "Created At";
            createdAt.NullValidator(propertyName);

            CreatedAt = createdAt;
        }

        public virtual void SetUpdatedAt(DateTime updatedAt)
        {
            UpdatedAt = updatedAt;
        }

        public virtual void SetWallet(Wallet wallet)
        {
            string propertyName = "Wallet";

            wallet.NullValidator(propertyName);
            Wallet = wallet;
        }
    }
}