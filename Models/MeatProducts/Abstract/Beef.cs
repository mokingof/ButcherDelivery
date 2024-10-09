using AldyarOnlineShoppig.Models.Enums;
using AldyarOnlineShoppig.Models.Interfaces;

namespace AldyarOnlineShoppig.Models.MeatProducts.Abstract
{
    public abstract class Beef : IMeatProduct
    {
        public MeatType Type => MeatType.Beef;
        public double Weight { get; set; }
        public double PricePerKg { get; set; }
        public abstract BeefCut Cut { get; }
        
        public double CalculatePrice()
        {
            return Weight * PricePerKg;
        }


    }
}
