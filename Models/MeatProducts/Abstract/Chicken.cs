using AldyarOnlineShoppig.Models.Enums;
using AldyarOnlineShoppig.Models.Interfaces;

namespace AldyarOnlineShoppig.Models.MeatProducts.Abstract
{
    public abstract class Chicken : IMeatProduct
    {
        public MeatType Type => MeatType.Chicken;
        public double Weight { get; set; }
        public double PricePerKg { get; set; }
        public abstract ChickenCut Cut { get; }

        public double CalculatePrice()
        {
            return Weight * PricePerKg;
        }

    }
}
