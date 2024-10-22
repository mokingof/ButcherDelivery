using AldyarOnlineShoppig.Models.Enums;
using AldyarOnlineShoppig.Models.Interfaces;

namespace AldyarOnlineShoppig.Models.MeatProducts.Abstract
{
    public abstract class Beef : IMeatProduct
    {
        public MeatType Type => MeatType.Beef;
        public double Weight { get; set; }
        public decimal PricePerKg { get; set; }
        public abstract BeefCut Cut { get; }
        
        public decimal CalculatePrice()
        {
            return (decimal)Weight * PricePerKg;
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
