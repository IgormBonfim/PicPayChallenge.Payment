using System.ComponentModel;

namespace PicPayChallenge.Payment.Domain.Users.Enums
{
    public enum UserTypeEnum
    {
        [Description("Common")]
        Common = 0,
        [Description("Store")]
        Store = 1,
    }
}
