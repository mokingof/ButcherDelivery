using AldyarOnlineShoppig.Models.Enums;

namespace AldyarOnlineShoppig.Models.MeatProducts.Abstract
{
    public class Thigh : Chicken
    {
        public override ChickenCut Cut => ChickenCut.Thighs;

        public Thigh(double weight)
        {
            Weight = weight;
            PricePerKg = 4.99m;
        }
    }
}
