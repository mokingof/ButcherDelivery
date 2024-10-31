namespace AldyarOnlineShoppig.Models.ExceptionHandling.CustomerException
{
    public enum AddressValidationError
    {
        Null,
        Empty,
        InvalidPostcode,
        InvalidFormat,
        TooLong,
        InvalidCharacters,
        MissingStreetNumber,
        InvalidCityName,
        InvalidStreetFormat
    }

    public class AddressValidationException : Exception
    {
        public AddressValidationError ErrorType { get; }
        public string AttemptedValue { get; }

        public AddressValidationException(AddressValidationError error, string attemptedValue)
    : base(CreateMessage(error, attemptedValue))
        {
            ErrorType = error;
            AttemptedValue = attemptedValue;
        }

        private static string CreateMessage(AddressValidationError error, string attemptedValue)
        {
            switch (error)
            {
                case AddressValidationError.Null:
                    return "Address cannot be null";
                case AddressValidationError.Empty:
                    return "Address cannot be empty";
                case AddressValidationError.InvalidPostcode:
                    return $"The postcode '{attemptedValue}' is invalid";
                case AddressValidationError.InvalidFormat:
                    return $"The address '{attemptedValue}' is not a valid format";
                case AddressValidationError.TooLong:
                    return $"The '{attemptedValue}' exceeds maximum length of {50} characters";
                case AddressValidationError.InvalidCharacters:
                    return $"'{attemptedValue}' contains invalid characters. Only letters, numbers, spaces and hyphens are allowed";
                case AddressValidationError.MissingStreetNumber:
                    return $"'{attemptedValue}' Is missing Street number";
                    case AddressValidationError.InvalidCityName:
                    return $"'{attemptedValue}' Is not a valid city";
                    case AddressValidationError.InvalidStreetFormat:
                    return $"'{attemptedValue}' Invalid format";
                default:
                    throw new ArgumentException($"Unhandled error type: {error}");
            }
        }
    }
}
