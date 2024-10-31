namespace AldyarOnlineShoppig.Models.Enums.ValidationErrors
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
}
