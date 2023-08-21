﻿using PicPayChallenge.Payment.Domain.Users.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Payment.Domain.Users.Services.Commands
{
    public class UserInstanceCommand
    {
        public string FullName { get; set; }
        public string DocumentNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserTypeEnum UserType { get; set; }
    }
}
