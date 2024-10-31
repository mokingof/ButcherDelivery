using Rbec.Postcodes;

namespace AldyarOnlineShoppig.Models.Interfaces
{
    public interface IAddress
    {

        string Street { get; }
        string City { get; }
        Postcode Postcode { get; }   // Using the Rbec.Postcodes package type

        string GetFormattedAddress();  // Returns full address as formatted string
    }
}
