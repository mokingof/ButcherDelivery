using AldyarOnlineShoppig.Models.ExceptionHandling.CustomerException;
using AldyarOnlineShoppig.Models.Interfaces.Customer;

namespace AldyarOnlineShoppig.Models.Core.Customer
{
    public class Name : IName
    {
        private const int MinNameLength = 2;
        private const int MaxNameLength = 55;

        private readonly string _firstName;
        private readonly string _lastName;
        private readonly string _fullName;
        public string FirstName => _firstName;
        public string LastName => _lastName;
        public string FullName => $"{FirstName} {LastName}";

        public Name(string firstName, string lastName)
        {
            ValidateCustomerName(firstName, lastName);  
            _firstName = firstName;
            _lastName = lastName;
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
