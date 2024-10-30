using AldyarOnlineShoppig.Models.Enums;
namespace AldyarOnlineShoppig.Models.MeatProducts.Abstract
{
    public class Wings : Chicken
    {
        public override ChickenCut Cut => ChickenCut.Wings;

        public Wings(double weight)
        {
            SetWeight(weight);
            SetPricePerKg(5.99m);
        }
    }
}

