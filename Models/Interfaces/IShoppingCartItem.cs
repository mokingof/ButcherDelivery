namespace AldyarOnlineShoppig.Models.Interfaces
{
    public interface IShoppingCartItem
    {
        // This interface represents a single unique product and its details in the cart:
        IMeatProduct Product { get; }
        int Quantity { get; }
        decimal Subtotal { get; }
        double Weight { get; }
        decimal PricePerKg{ get; }

    }
}
