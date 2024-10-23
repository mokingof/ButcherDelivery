using AldyarOnlineShoppig.Models.Interfaces;

namespace AldyarOnlineShoppig.Models
{
    public class ShoppingCartItem : IShoppingCartItem
    {


        public IMeatProduct Product {get;}
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
    }
}
