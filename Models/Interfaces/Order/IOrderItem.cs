using AldyarOnlineShoppig.Models.Enums;
using AldyarOnlineShoppig.Models.Interfaces.Product;

namespace AldyarOnlineShoppig.Models.Interfaces.Order
{

    // Represents each individual meat product ordered
    public interface IOrderItem
    {
        IMeatProduct Product { get; }
        int Quantity { get; }
        decimal PricePerKgAtTimeOfOrder { get; }
        decimal Subtotal { get; }
        double Weight { get; }
    }
}
