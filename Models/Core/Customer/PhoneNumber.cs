using AldyarOnlineShoppig.Models.Enums.ValidationErrors;
using AldyarOnlineShoppig.Models.ExceptionHandling.CustomerException;
using AldyarOnlineShoppig.Models.Interfaces.Customer;
using System.Text.RegularExpressions;
using PhoneNumbers;

namespace AldyarOnlineShoppig.Models.Core.Customer
{
    public class PhoneNumber : IPhoneNumber
    {
        private readonly string _phoneNumber;
        string IPhoneNumber.PhoneNumber => _phoneNumber;


        public PhoneNumber(string phoneNumber)
        {     
            _phoneNumber = phoneNumber;
        }
    }
}
