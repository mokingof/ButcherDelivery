using AldyarOnlineShoppig.Models.Enums;
using AldyarOnlineShoppig.Models.Interfaces.MeatProducts.Abstract;

namespace AldyarOnlineShoppig.Models.MeatProducts.Concrete.Chicken
{
    public class Breast : Chicken
    {
        public override ChickenCut Cut => ChickenCut.Breast;

        public Breast(double weight)
        {
            SetWeight(weight);
            SetPricePerKg(6.99m);
        }
    }
}
