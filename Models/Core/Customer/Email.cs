using AldyarOnlineShoppig.Models.Enums.ValidationErrors;
using AldyarOnlineShoppig.Models.ExceptionHandling.CustomerException;
using AldyarOnlineShoppig.Models.Interfaces.Customer;
using EmailValidation;

namespace AldyarOnlineShoppig.Models.Core.Customer
{
    public class Email : IEmail
    {
        private const int MaxEmailLength = 254;

        private readonly string _email;
        string IEmail.Email => _email;

        public Email(string email)
        {
            if (email == null) 
                throw new EmailValidationException(EmailValidationErrorType.Null,email);
            
            if (string.IsNullOrEmpty(email))
                throw new EmailValidationException(EmailValidationErrorType.Empty, email);

            if (!EmailValidator.Validate(email))
                throw new EmailValidationException(EmailValidationErrorType.InvalidFormat, email);

            _email = email;
        }
     
    }
}
