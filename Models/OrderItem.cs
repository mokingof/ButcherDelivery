using AldyarOnlineShoppig.Models.Interfaces;

namespace AldyarOnlineShoppig.Models
{
    public class OrderItem : IOrderItem
    {
        public IMeatProduct Product { get; }
        public int Quantity { get; }
        public decimal PricePerKgAtTimeOfOrder { get; }
        public decimal Subtotal => Quantity * PricePerKgAtTimeOfOrder;
        public double Weight { get; }

        // Constructor that takes a shopping cart item
        public OrderItem(IShoppingCartItem cartItem)
        {
            Product = cartItem.Product;
            Quantity = cartItem.Quantity;
            PricePerKgAtTimeOfOrder = cartItem.PricePerKg;
            Weight = cartItem.Weight;
        }
    }
}
