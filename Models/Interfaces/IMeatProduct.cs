using AldyarOnlineShoppig.Models.Enums;

namespace AldyarOnlineShoppig.Models.Interfaces
{


    public interface IMeatProduct
    {
        MeatType Type { get; }
        double Weight { get; }
        decimal PricePerKg { get; }
        decimal CalculatePrice();
       
    }
}
