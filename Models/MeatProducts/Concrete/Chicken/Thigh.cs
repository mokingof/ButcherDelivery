using AldyarOnlineShoppig.Models.Enums;
using AldyarOnlineShoppig.Models.Interfaces.MeatProducts.Abstract;

namespace AldyarOnlineShoppig.Models.MeatProducts.Concrete.Chicken
{
    public class Thigh : Chicken
    {
        public override ChickenCut Cut => ChickenCut.Thighs;

        public Thigh(double weight)
        {
            SetWeight(weight);
            SetPricePerKg(4.99m);
        }
    }
}
