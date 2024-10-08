using AldyarOnlineShoppig.Models.Enums;

namespace AldyarOnlineShoppig.Models.Interfaces
{
 

    public interface IMeatProduct
    {
        MeatType Type { get; }
        double Weight { get; set; }
        decimal PricePerKg { get; set; }
        decimal CalculatePrice();
    }
}
