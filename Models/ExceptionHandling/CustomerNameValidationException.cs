namespace AldyarOnlineShoppig.Models.ExceptionHandling
{
    public enum NameField
    {
        FirstName,
        LastName
    }

    public enum NameValidationError
    {
        Null,
        Empty,
        TooShort,
        TooLong,
        InvalidCharacters
    }
    public class CustomerNameValidationException : Exception
    {
        public NameField Field { get; }
        public NameValidationError ErrorType { get; }
        public string AttemptedValue { get; }

        public CustomerNameValidationException(NameField field, NameValidationError error, string attemptedValue)
      : base(CreateMessage(field, error, attemptedValue))
        {
            Field = field;
            ErrorType = error;
            AttemptedValue = attemptedValue;
        }

        private static string CreateMessage(NameField field, NameValidationError error, string attemptedValue)
        {
            string fieldName = field == NameField.FirstName ? "First name" : "Last name";

            switch (error)
            {
                case NameValidationError.Null:
                    return $"{fieldName} cannot be null";
                case NameValidationError.Empty:
                    return $"{fieldName} cannot be empty or just whitespace";
                case NameValidationError.InvalidCharacters:
                    return $"{fieldName} '{attemptedValue}' contains invalid characters";
                case NameValidationError.TooShort:
                    return $"{fieldName} '{attemptedValue}' is too short (minimum length is 2 characters)";
                case NameValidationError.TooLong:
                    return $"{fieldName} '{attemptedValue}' is too long (maximum length is 55 characters)";
                default:
                    throw new ArgumentException($"Unhandled error type: {error}");
            }
        }
    }
}
