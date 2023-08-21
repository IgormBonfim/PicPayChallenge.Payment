using PicPayChallenge.Payment.Common.Exceptions;
using PicPayChallenge.Payment.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Payment.Common.Validators
{
    public static class StringValidator
    {
        public static void MinLength(this string value, int length, string propertyName)
        {
            if (value.Length < length)
                throw new BadRequestException($"The {propertyName} must contain at least {length} characters");
        }

        public static void MinLength(this string value, int length)
        {
            if (value.Length < length)
                throw new BadRequestException($"The property must contain at least {length} characters");
        }

        public static void MaxLength(this string value, int length, string propertyName)
        {
            if (value.Length > length)
                throw new BadRequestException($"The {propertyName} must contain a maximum of {length} characters");
        }

        public static void MaxLength(this string value, int length)
        {
            if (value.Length > length)
                throw new BadRequestException($"The property must contain a maximum of {length} characters");
        }
    }
}