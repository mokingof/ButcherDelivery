using AldyarOnlineShoppig.Models.Enums;

namespace AldyarOnlineShoppig.Models.Interfaces.Product
{


    public interface IMeatProduct
    {
        MeatType Type { get; }
        double Weight { get; }
        decimal PricePerKg { get; }
        decimal CalculatePrice();

    }
}
