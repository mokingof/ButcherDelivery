namespace AldyarOnlineShoppig.Models.ExceptionHandling
{
    public class InvalidMeatCutException : Exception
    {
        public InvalidMeatCutException() : base() { }

        public InvalidMeatCutException(string message) : base(message) { }

        public InvalidMeatCutException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
