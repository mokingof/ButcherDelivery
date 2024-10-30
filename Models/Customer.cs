using AldyarOnlineShoppig.Models.ExceptionHandling;
using AldyarOnlineShoppig.Models.Interfaces;
using System.Text.RegularExpressions;

namespace AldyarOnlineShoppig.Models
{
    public class Customer : ICustomer
    {
        private const int MinNameLength = 2;
        private const int MaxNameLength = 55;

        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phoneNumber;
        private string _postcode;
        private string _address;
        private readonly DateTime _registeredDate;

        // Required properties from interface
        public int CustomerId { get; private set; }
        public string FirstName => _firstName;
        public string LastName => _lastName;
        public string Email => _email;
        public string PhoneNumber => _phoneNumber;
        public string Address => _address;
        public string Postcode => _postcode;

        // Additional useful properties
        public string FullName => $"{FirstName} {LastName}";
        public DateTime RegisteredDate => _registeredDate;
        public ICollection<IOrder> OrderHistory => throw new NotImplementedException();



        public Customer(int customerId, string firstName, string lastName, string email,
                       string phoneNumber, string address, string postcode)
        {
            // What validation should we add here?
            CustomerId = customerId;
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _phoneNumber = phoneNumber;
            _address = address;
            _postcode = postcode;
            _registeredDate = DateTime.Now;
        }
        private void ValidateCustomerName(string firstName, string lastName)
        {
            ValidateName(firstName, NameField.FirstName);
            ValidateName(lastName, NameField.LastName);
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

        
    }
}
