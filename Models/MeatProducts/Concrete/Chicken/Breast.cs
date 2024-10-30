using AldyarOnlineShoppig.Models.Enums;
namespace AldyarOnlineShoppig.Models.MeatProducts.Abstract
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
