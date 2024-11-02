using AldyarOnlineShoppig.Models.Enums.ValidationErrors;
using AldyarOnlineShoppig.Models.ExceptionHandling.CustomerException;
using AldyarOnlineShoppig.Models.Interfaces.Customer;
using System.Xml.Linq;

namespace AldyarOnlineShoppig.Models.Core.Customer
{
    public class Name : IName
    {
        private const int MinNameLength = 2;
        private const int MaxNameLength = 55;

        // Define allowed special characters for names
        private readonly char[] allowedSpecialChars = new[] { ' ', '-', '\'', '.', };
        private readonly string _firstName;
        private readonly string _lastName;
        private readonly string _fullName;
        public string FirstName => _firstName;
        public string LastName => _lastName;
        public string FullName => _fullName;

        public Name(string firstName, string lastName)
        {
            if (firstName == null)
                throw new CustomerNameValidationException(NameField.FirstName, NameValidationError.Null, firstName);
            if (lastName == null)
                throw new CustomerNameValidationException(NameField.LastName, NameValidationError.Null, lastName);

            _firstName = NormaliseString(firstName);
            _lastName = NormaliseString(lastName);

            ValidateCustomerName(_firstName, _lastName);
          
            _fullName = $"{_firstName} {_lastName}";
        }
        private string NormaliseString(string name)
        {
            bool capitaliseNext = true;
            string newResult = "";

            foreach (char c in name.Trim().ToLower())
            {
                if (capitaliseNext && !IsAllowedSpecialChar(c))
                {
                    newResult += char.ToUpper(c);
                    capitaliseNext = false;
                    continue;
                }
                if (IsAllowedSpecialChar(c))
                {
                    capitaliseNext = true ;
                }
                newResult += c;
            }
            return newResult;
        }
        private void ValidateCustomerName(string firstName, string lastName)
        {
            ValidateName(firstName, NameField.FirstName);
            ValidateName(lastName, NameField.LastName);
        }  
        private void ValidateName(string name, NameField field)
        {   
            
            if (string.IsNullOrWhiteSpace(name))  
                throw new CustomerNameValidationException(field, NameValidationError.Empty, name);

            if (name.Length < MinNameLength)
                throw new CustomerNameValidationException(field, NameValidationError.TooShort, name);

            if (name.Length > MaxNameLength)
                throw new CustomerNameValidationException(field, NameValidationError.TooLong, name);
            if (!IsValidNameCharacters(name))
                throw new CustomerNameValidationException(field, NameValidationError.InvalidCharacters, name);
        }
        private bool IsAllowedSpecialChar(char c)
        {
            // Check if it's one of our allowed special characters
            return allowedSpecialChars.Contains(c);
        }
        private bool IsValidNameCharacters(string name)
        {
            foreach (char c in name)
            {
                // Check if character is a letter (handles international characters too)
                bool isLetter = char.IsLetter(c);

                // If character is neither a letter nor an allowed special character
                if (!isLetter && !IsAllowedSpecialChar(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
