using AldyarOnlineShoppig.Models.Interfaces.Product;
using AldyarOnlineShoppig.Models.Interfaces.Shopping;

namespace AldyarOnlineShoppig.Models.Shopping
{
    public class ShoppingCartItem : IShoppingCartItem
    {


        public IMeatProduct Product { get; }
        public int Quantity { get; }
        public decimal Subtotal => Product.CalculatePrice() * Quantity;
        public double Weight => Product.Weight;
        public decimal PricePerKg => Product.PricePerKg;

        public ShoppingCartItem(IMeatProduct product, int quantity)
        {
            if (quantity <= 0) throw new ArgumentException("Quantity must be positive", nameof(quantity));

            Product = product;
            Quantity = quantity;

        }

        public override string ToString()
        {
            return $"Quantity: {Quantity}\n" + Product.ToString() + "\nSubTotal = " + Subtotal;
        }
    }
}
