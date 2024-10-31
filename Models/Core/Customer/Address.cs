using AldyarOnlineShoppig.Models.ExceptionHandling.CustomerException;
using AldyarOnlineShoppig.Models.Interfaces.Customer;
using Rbec.Postcodes;
using System.IO;
using System.Text.RegularExpressions;

namespace AldyarOnlineShoppig.Models.Core.Customer
{
    public class Address : IAddress
    {
        // Constants for validation
        private const int MAX_STREET_LENGTH = 50;  // Royal Mail line length limit
        private const string STREET_VALIDATION_PATTERN = @"^(\d+[a-zA-Z]?[\s-]+[a-zA-Z0-9\s-]+|[a-zA-Z0-9\s-]+\d+[a-zA-Z]?)$";
        private const int MAX_CITY_LENGTH = 35;
        private const string CITY_VALIDATION_PATTERN = @"^[a-zA-Z\s-]+$";

        private readonly string _street;
        private readonly string _city;
        private readonly Postcode _postcode;

        public string Street => _street;
        public string City => _city;
        public Postcode Postcode => _postcode;


        public Address(string street, string city, string postcodeString)
        {
            ValidateStreet(street);
            ValidateCity(city);

            // Try to parse postcode
            if (!Postcode.TryParse(postcodeString, out Postcode postcode))
            {
                throw new AddressValidationException(AddressValidationError.InvalidPostcode, postcodeString);
            }

            // If we get here, all validation passed, set the fields
            _street = NormalizeStreet(street);
            _city = NormalizeCity(city);
            _postcode = postcode;
        }
        private void ValidateStreet(string street)
        {
            if (string.IsNullOrWhiteSpace(street))
                throw new AddressValidationException(AddressValidationError.Empty, nameof(street));

            if (street.Length > MAX_STREET_LENGTH)
                throw new AddressValidationException(AddressValidationError.TooLong, nameof(street));

            if (!Regex.IsMatch(street, STREET_VALIDATION_PATTERN))
                throw new AddressValidationException(AddressValidationError.InvalidCharacters, street);
        }
        private void ValidateCity(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
                throw new AddressValidationException(AddressValidationError.Empty, nameof(city));

            if (city.Length > MAX_CITY_LENGTH)
                throw new AddressValidationException(AddressValidationError.TooLong, nameof(city));

            if (!Regex.IsMatch(city, CITY_VALIDATION_PATTERN))
                throw new AddressValidationException(AddressValidationError.InvalidCityName, city);

            if (city.Trim().Replace("-", "").Replace(" ", "").Length == 0)
                throw new AddressValidationException(AddressValidationError.InvalidCityName, city);

            if (city.Contains("--") || city.Contains("  "))
                throw new AddressValidationException(AddressValidationError.InvalidCityName, city);
        }
        private string NormalizeStreet(string street)
        {
            // Trim spaces and convert multiple spaces to single space
            return Regex.Replace(street.Trim(), @"\s+", " ");
        }
        private string NormalizeCity(string city)
        {
            // Trim spaces, convert multiple spaces to single space, and capitalize first letter
            string normalized = Regex.Replace(city.Trim(), @"\s+", " ");
            return char.ToUpper(normalized[0]) + normalized.Substring(1).ToLower();
        }
        public string GetFormattedAddress()
        {
            return $"{_street}\n{_city}\n{_postcode}";
        }
        public override string ToString() => GetFormattedAddress();
    }
}
