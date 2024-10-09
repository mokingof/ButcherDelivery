using AldyarOnlineShoppig.Models.Enums;
using AldyarOnlineShoppig.Models.MeatProducts.Abstract;

namespace AldyarOnlineShoppig.Models.MeatProducts
{
    public class Wings : Chicken
    {
        public override ChickenCut Cut => ChickenCut.Wings;

        public Wings(double weight)
        {
            Weight = weight;
            PricePerKg = 5.99;
        }
    }
}

