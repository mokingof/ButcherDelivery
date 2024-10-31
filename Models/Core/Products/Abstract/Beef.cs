using AldyarOnlineShoppig.Models.Enums;
using AldyarOnlineShoppig.Models.Interfaces.Product;

namespace AldyarOnlineShoppig.Models.Core.Products.Abstract
{
    public abstract class Beef : IMeatProduct
    {
        private double _weight;
        private decimal _pricePerKg;

        public double Weight => _weight;
        public decimal PricePerKg => _pricePerKg;
        public MeatType Type => MeatType.Beef;
        public abstract BeefCut Cut { get; }

        public decimal CalculatePrice() => (decimal)Weight * PricePerKg;
        protected void SetWeight(double value) => _weight = value;
        protected void SetPricePerKg(decimal value) => _pricePerKg = value;

        override public string ToString()
        {
            return $"Meat Type: {Type}\n" +
                $"Meat Cut: {Cut}\n" +
                $"Weight: {Weight}\n" +
                $"Cost Per Kilo: £{PricePerKg}\n" +
                $"Total Price: {CalculatePrice()}";
        }
    }
}
