using PicPayChallenge.Common.Entities;
using PicPayChallenge.Common.Exceptions;
using PicPayChallenge.Common.Utils;
using PicPayChallenge.Common.Validators;
using PicPayChallenge.Payment.Domain.Users.Enums;

namespace PicPayChallenge.Payment.Domain.Users.Entities
{
    public class User : Entity
    {
        public virtual string FullName { get; protected set; }
        public virtual string DocumentNumber { get; protected set; }
        public virtual string Email { get; protected set; }
        public virtual UserTypeEnum UserType { get; protected set; }
        public virtual Wallet Wallet { get; protected set; }

        public User() { }

        public User(int id, string fullName, string documentNumber, string email, UserTypeEnum userType, Wallet wallet)
        {
            SetId(id);
            SetFullName(fullName);
            SetDocumentNumber(documentNumber);
            SetEmail(email);
            SetUserType(userType);
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

        public virtual void SetUserType(UserTypeEnum userType)
        {
            string propertyName = "User Type";
            userType.NullValidator(propertyName);
            
            UserType = userType;
        }

        public virtual void SetWallet(Wallet wallet)
        {
            string propertyName = "Wallet";

            wallet.NullValidator(propertyName);
            Wallet = wallet;
        }
    }
}