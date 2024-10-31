using AldyarOnlineShoppig.Models.ExceptionHandling.CustomerException;
using System.Text.RegularExpressions;
using Rbec.Postcodes;
using AldyarOnlineShoppig.Models.Interfaces.Customer;
using AldyarOnlineShoppig.Models.Interfaces.Order;

namespace AldyarOnlineShoppig.Models.Core.Customer
{
    public class Customer : ICustomer
    {
        private const int MinNameLength = 2;
        private const int MaxNameLength = 55;
        
        private static readonly string MobilePattern = @"^(\+44\s?7\d{3}|\(?07\d{3}\)?)\s?\d{3}\s?\d{3}$";
        private static readonly string LandlinePattern = @"^(\+44\s?|0)(?:1|2|3)\d{2,3}\s?\d{3,4}\s?\d{3,4}$";

        private string _firstName;
        private string _lastName;
        private IEmail _email;
        private string _phoneNumber;
        private IAddress _address;
        private readonly DateTime _registeredDate;

        // Required properties from interface
        public int CustomerId { get; private set; }
        public string FirstName => _firstName;
        public string LastName => _lastName;
        public IEmail Email => _email;
        public string PhoneNumber => _phoneNumber;


        // Additional useful properties
        public string FullName => $"{FirstName} {LastName}";
        public DateTime RegisteredDate => _registeredDate;
        public ICollection<IOrder> OrderHistory => throw new NotImplementedException();

        public IAddress Address => _address;

        public Customer(int customerId, string firstName, string lastName, string email,
                       string phoneNumber, string street, string city, string postcode)
        {
            // What validation should we add here?
            CustomerId = customerId;
            _firstName = firstName;
            _lastName = lastName;
            _email = new Email(email);
            _address = new Address(street, city, postcode);
            _phoneNumber = phoneNumber;
            _registeredDate = DateTime.Now;
        }
        private void ValidateCustomerName(string firstName, string lastName)
        {
            ValidateName(firstName, NameField.FirstName);
            ValidateName(lastName, NameField.LastName);
        }
        private static bool ValidatePhoneNumberFormat(string number)
        {
            return Regex.Match(number, MobilePattern, RegexOptions.IgnoreCase).Success ||
                   Regex.Match(number, LandlinePattern, RegexOptions.IgnoreCase).Success;
        }
        private void ValidateName(string name, NameField field)
        {
            if (name == null)
                throw new CustomerNameValidationException(field, NameValidationError.Null, name);

            if (string.IsNullOrWhiteSpace(name))  // Note: Changed from IsNullOrEmpty to IsNullOrWhiteSpace
                throw new CustomerNameValidationException(field, NameValidationError.Empty, name);

            if (name.Length < MinNameLength)
                throw new CustomerNameValidationException(field, NameValidationError.TooShort, name);

            if (name.Length > MaxNameLength)
                throw new CustomerNameValidationException(field, NameValidationError.TooLong, name);
            if (!IsValidNameCharacters(name))
                throw new CustomerNameValidationException(field, NameValidationError.InvalidCharacters, name);
        }
        private bool IsValidNameCharacters(string name)
        {
            // Define allowed special characters for names
            char[] allowedSpecialChars = new[] { ' ', '-', '\'', '.' };

            foreach (char c in name)
            {
                // Check if character is a letter (handles international characters too)
                bool isLetter = char.IsLetter(c);

                // Check if it's one of our allowed special characters
                bool isAllowedSpecialChar = allowedSpecialChars.Contains(c);

                // If character is neither a letter nor an allowed special character
                if (!isLetter && !isAllowedSpecialChar)
                {
                    return false;
                }
            }

            return true;
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
     
    }
}
