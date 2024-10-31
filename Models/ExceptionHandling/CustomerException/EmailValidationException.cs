using AldyarOnlineShoppig.Models.Enums.ValidationErrors;

namespace AldyarOnlineShoppig.Models.ExceptionHandling.CustomerException
{
  
    public class EmailValidationException : Exception
    {
        public EmailValidationError ErrorType { get; }
        public string AttemptedValue { get; }

        public EmailValidationException(EmailValidationError error, string attemptedValue)
            : base(CreateMessage(error, attemptedValue))
        {
            ErrorType = error;
            AttemptedValue = attemptedValue;
        }

        public EmailValidationException(string message, Exception innerException)
            : base(message, innerException) { }

        private static string CreateMessage(EmailValidationError error, string attemptedValue)
        {
            switch (error)
            {
                case EmailValidationError.Null:
                    return "Email address cannot be null";
                case EmailValidationError.Empty:
                    return "Email address cannot be empty or consist only of whitespace";
                case EmailValidationError.TooLong:
                    return $"Email address '{attemptedValue}' exceeds maximum length of {254} characters";
                case EmailValidationError.TrailingDot:
                    return $"Email address '{attemptedValue}' cannot end with a period";
                case EmailValidationError.InvalidFormat:
                    return $"'{attemptedValue}' is not a valid email address";
                default:
                    throw new ArgumentException($"Unhandled error type: {error}");
            }
        }
    }
}
