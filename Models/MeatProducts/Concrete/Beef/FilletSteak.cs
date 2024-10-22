using AldyarOnlineShoppig.Models.Enums;
using AldyarOnlineShoppig.Models.MeatProducts.Abstract;

namespace AldyarOnlineShoppig.Models.MeatProducts.Concrete
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
