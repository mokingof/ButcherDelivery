namespace AldyarOnlineShoppig.Models.ExceptionHandling
{
    public class OrderValidationException : Exception
    {
        public OrderValidationException(string message) : base(message) { }
    }
}
