using AldyarOnlineShoppig.Models.Enums;
using AldyarOnlineShoppig.Models.Interfaces.MeatProducts.Abstract;

namespace AldyarOnlineShoppig.Models.MeatProducts.Concrete.Chicken
{
    public class Legs : Chicken
    {
        public override ChickenCut Cut => ChickenCut.Legs;

        public Legs(double weight)
        {
            SetWeight(weight);
            SetPricePerKg(6.99m);
        }
    }
}
