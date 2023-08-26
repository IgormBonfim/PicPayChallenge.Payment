using PicPayChallenge.Payment.Domain.Users.Enums;

namespace PicPayChallenge.Payment.Domain.Users.Services.Commands
{
    public class UserInstanceCommand
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string DocumentNumber { get; set; }
        public string Email { get; set; }
        public UserTypeEnum UserType { get; set; }
    }
}
