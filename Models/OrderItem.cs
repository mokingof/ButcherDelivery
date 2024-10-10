using AldyarOnlineShoppig.Models.Interfaces;

namespace AldyarOnlineShoppig.Models
{
    public class OrderItem
    {
        public IMeatProduct Product { get; }
        public Enum Cut { get; }
        public double Quantity { get; set; }

        public OrderItem(IMeatProduct product, Enum cut, double quantity)
        {
            Product = product ?? throw new ArgumentNullException(nameof(product));
            Cut = cut ?? throw new ArgumentNullException(nameof(cut));
            Quantity = quantity > 0 ? quantity : throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));
        }

        public decimal TotalPrice => (decimal)Quantity * Product.PricePerKg;
    }
}
