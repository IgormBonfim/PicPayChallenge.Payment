using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
