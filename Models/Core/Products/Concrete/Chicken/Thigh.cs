using AldyarOnlineShoppig.Models.Core.Products.Abstract;
using AldyarOnlineShoppig.Models.Enums;

namespace AldyarOnlineShoppig.Models
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
