using AldyarOnlineShoppig.Models.Enums.ValidationErrors;
using AldyarOnlineShoppig.Models.ExceptionHandling.CustomerException;
using AldyarOnlineShoppig.Models.Interfaces.Customer;

namespace AldyarOnlineShoppig.Models.Core.Customer
{
    public class Email : IEmail
    {
        private const int MaxEmailLength = 254;

        private readonly string _email;
        string IEmail.Email => _email;


        public Email(string email)
        {    
            ValidateEmailAddress(email);    
            _email = email;
        }

        private void ValidateEmailAddress(string email)
        {
            if (email == null)
                throw new EmailValidationException(EmailValidationError.Null, email);

            var trimmedEmail = email.Trim();

            if (string.IsNullOrWhiteSpace(trimmedEmail))
                throw new EmailValidationException(EmailValidationError.Empty, email);

            if (trimmedEmail.Length > MaxEmailLength)
                throw new EmailValidationException(EmailValidationError.TooLong, email);

            if (trimmedEmail.EndsWith("."))
                throw new EmailValidationException(EmailValidationError.TrailingDot, email);
            try
            {
                var addr = new System.Net.Mail.MailAddress(trimmedEmail);
                if (addr.Address != trimmedEmail)
                    throw new EmailValidationException(EmailValidationError.InvalidFormat, email);
            }
            catch (Exception)
            {
                throw new EmailValidationException(EmailValidationError.InvalidFormat, email);
            }
        }
    }
}
