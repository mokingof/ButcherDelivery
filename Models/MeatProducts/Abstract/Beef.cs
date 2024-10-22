using AldyarOnlineShoppig.Models.Enums;
using AldyarOnlineShoppig.Models.Interfaces;

namespace AldyarOnlineShoppig.Models.MeatProducts.Abstract
{
    public abstract class Beef : IMeatProduct
    {
        private double _weight;
        private decimal _pricePerKg;
        
        public MeatType Type => MeatType.Beef;
        public double Weight => _weight;
        public decimal PricePerKg => _pricePerKg;
        public abstract BeefCut Cut { get; }
        
        public decimal CalculatePrice()
        {
         
            return (decimal)Weight * PricePerKg;
        }
        protected void SetWeight(double value)
        {
            if (Weight < 0)
            {
                throw new ArgumentException("Weight must be positive");
            }
           _weight = value;
        }
        
        protected void SetPricePerKg(decimal value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Weight must be positive");
            }
            _pricePerKg = value;
        }
        override public string ToString()
        {
            return $"Meat Type: {Type}\n" +
                $"Meat Cut: {Cut}\n"+
                $"Weight: {Weight}\n" +
                $"Cost Per Kilo: £{PricePerKg}";
        }
    }
}
