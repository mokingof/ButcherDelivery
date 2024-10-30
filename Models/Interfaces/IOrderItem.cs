using AldyarOnlineShoppig.Models.Enums;

namespace AldyarOnlineShoppig.Models.Interfaces
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
