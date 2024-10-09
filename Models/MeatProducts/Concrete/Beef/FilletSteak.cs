using AldyarOnlineShoppig.Models.Enums;
using AldyarOnlineShoppig.Models.MeatProducts.Abstract;

namespace AldyarOnlineShoppig.Models.MeatProducts.Concrete
{
    public class FilletSteak : Beef
    {
        public override BeefCut Cut => BeefCut.FilletSteak;

        public FilletSteak(double weight)
        {
            Weight = weight;
            PricePerKg = 12.99m;
        }
    }
}
