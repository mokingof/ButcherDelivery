using AldyarOnlineShoppig.Models.Enums.ValidationErrors;

namespace AldyarOnlineShoppig.Models.ExceptionHandling.CustomerException
{
  
    public class EmailValidationException : Exception
    {
        public EmailValidationErrorType ErrorType { get; }
        public string AttemptedValue { get; }

        public EmailValidationException(EmailValidationErrorType error, string attemptedValue)
            : base(CreateMessage(error, attemptedValue))
        {
            ErrorType = error;
            AttemptedValue = attemptedValue;
        }

        public EmailValidationException(string message, Exception innerException)
            : base(message, innerException) { }

        private static string CreateMessage(EmailValidationErrorType error, string attemptedValue)
        {
            switch (error)
            {
                case EmailValidationErrorType.Null:
                    return "Email address cannot be null";
                case EmailValidationErrorType.Empty:
                    return "Email address cannot be empty or consist only of whitespace";
                case EmailValidationErrorType.TooLong:
                    return $"Email address '{attemptedValue}' exceeds maximum length of {254} characters";
                case EmailValidationErrorType.TrailingDot:
                    return $"Email address '{attemptedValue}' cannot end with a period";
                case EmailValidationErrorType.InvalidFormat:
                    return $"'{attemptedValue}' is not a valid email address";
                default:
                    throw new ArgumentException($"Unhandled error type: {error}");
            }
        }
    }
}
