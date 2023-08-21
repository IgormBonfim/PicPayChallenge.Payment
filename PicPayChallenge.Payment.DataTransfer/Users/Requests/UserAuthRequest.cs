using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Payment.DataTransfer.Users.Requests
{
    public class UserAuthRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
