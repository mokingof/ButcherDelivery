namespace AldyarOnlineShoppig.Models.ExceptionHandling.CustomerException
{
    public enum PhoneValidationError
    {
        Null,
        Empty,
        InvalidFormat
    }
    public class PhoneValidationException : Exception
    {
        public PhoneValidationError ErrorType { get; }
        public string AttemptedValue { get; }

        public PhoneValidationException(PhoneValidationError error, string attemptedValue)
            : base(CreateMessage(error, attemptedValue))
        {
            ErrorType = error;
            AttemptedValue = attemptedValue;
        }

        private static string CreateMessage(PhoneValidationError error, string attemptedValue)
        {
            switch (error)
            {
                case PhoneValidationError.Null:
                    return "Phone number cannot be null";
                case PhoneValidationError.Empty:
                    return "Phone number cannot be empty or consist only of whitespace";
                case PhoneValidationError.InvalidFormat:
                    return $"The phone number '{attemptedValue}' is invalid. ";
                default:
                    throw new ArgumentException($"Unhandled error type: {error}");
            }
        }
    }
}
