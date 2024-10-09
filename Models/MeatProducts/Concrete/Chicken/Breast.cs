using AldyarOnlineShoppig.Models.Enums;

namespace AldyarOnlineShoppig.Models.MeatProducts.Abstract
{
    public class Breast : Chicken
    {
        public override ChickenCut Cut => ChickenCut.Breast;

        public Breast(double weight)
        {
            Weight = weight;
            PricePerKg = 6.99m;
        }
    }
}
