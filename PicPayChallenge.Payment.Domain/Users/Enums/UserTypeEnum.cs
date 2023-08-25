using System.ComponentModel;

namespace PicPayChallenge.Payment.Domain.Users.Enums
{
    public enum UserTypeEnum
    {
        [Description("Common")]
        Comum = 0,
        [Description("Store")]
        Lojista = 1,
    }
}
