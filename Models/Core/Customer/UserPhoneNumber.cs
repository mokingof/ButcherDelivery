using AldyarOnlineShoppig.Models.Enums.ValidationErrors;
using AldyarOnlineShoppig.Models.ExceptionHandling.CustomerException;
using AldyarOnlineShoppig.Models.Interfaces.Customer;
using System.Text.RegularExpressions;
using PhoneNumbers;

namespace AldyarOnlineShoppig.Models.Core.Customer
{
    public class UserPhoneNumber : IPhoneNumber
    {
        private static readonly PhoneNumberUtil _phoneUtil = PhoneNumberUtil.GetInstance();
        private readonly string _phoneNumber;

        public string PhoneNumber => _phoneNumber;

        public UserPhoneNumber(string phoneNumber)
        {

           
            _phoneNumber = IsValidPhoneNumber(phoneNumber);

        }

        private string IsValidPhoneNumber(string number)
        {
            if (number == null)
                throw new PhoneValidationException(PhoneValidationError.Null, number);

            if (string.IsNullOrWhiteSpace(number))
                throw new PhoneValidationException(PhoneValidationError.Empty, number);

            try
            {
                PhoneNumber phoneNumber = _phoneUtil.Parse(number, "GB");


                if (!IsValidNumber(phoneNumber))
                {
                    throw new PhoneValidationException(PhoneValidationError.InvalidFormat, number);
                }
                return _phoneUtil.Format(phoneNumber, PhoneNumberFormat.NATIONAL);
            }
            catch (NumberParseException ex)
            {
                throw new PhoneValidationException(PhoneValidationError.InvalidFormat, number);
            }


        }

        private bool IsValidNumber(PhoneNumber number)
        {
            return _phoneUtil.IsValidNumberForRegion(number, "GB");
        }
    }
}
