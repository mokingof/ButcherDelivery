using AldyarOnlineShoppig.Models.Enums.ValidationErrors;
using AldyarOnlineShoppig.Models.ExceptionHandling.CustomerException;
using AldyarOnlineShoppig.Models.Interfaces.Customer;
using System.Text.RegularExpressions;

namespace AldyarOnlineShoppig.Models.Core.Customer
{
    public class PhoneNumber : IPhoneNumber
    {
        private static readonly string MobilePattern = @"^(\+44\s?7\d{3}|\(?07\d{3}\)?)\s?\d{3}\s?\d{3}$";
        private static readonly string LandlinePattern = @"^(\+44\s?|0)(?:1|2|3)\d{2,3}\s?\d{3,4}\s?\d{3,4}$";
        private readonly string _phoneNumber;
        string IPhoneNumber.PhoneNumber => _phoneNumber;


        public PhoneNumber(string phoneNumber)
        {
            ValidatePhoneNumber(phoneNumber);
            _phoneNumber = phoneNumber;
        }

        private void ValidatePhoneNumber(string number)
        {
            if (number == null)
                throw new PhoneValidationException(PhoneValidationError.Null, number);

            if (string.IsNullOrWhiteSpace(number))
                throw new PhoneValidationException(PhoneValidationError.Empty, number);

            if (!ValidatePhoneNumberFormat(number))
                throw new PhoneValidationException(PhoneValidationError.InvalidFormat, number);
        }
        private static bool ValidatePhoneNumberFormat(string number)
        {
            return Regex.Match(number, MobilePattern, RegexOptions.IgnoreCase).Success ||
                   Regex.Match(number, LandlinePattern, RegexOptions.IgnoreCase).Success;
        }
    }
}
