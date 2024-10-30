using AldyarOnlineShoppig.Models.Enums;
using AldyarOnlineShoppig.Models.Interfaces.MeatProducts.Abstract;

namespace AldyarOnlineShoppig.Models.MeatProducts.Concrete.Beef
{
    public class FilletSteak : Beef
    {
        public override BeefCut Cut => BeefCut.FilletSteak;

        public FilletSteak(double weight)
        {
            // Sets product-specific properties
            SetWeight(weight);
            SetPricePerKg(12.99m);
        }
    }
}
