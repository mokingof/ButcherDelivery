using AldyarOnlineShoppig.Models.Enums;
using AldyarOnlineShoppig.Models.MeatProducts.Abstract;

namespace AldyarOnlineShoppig.Models.MeatProducts.Concrete
{
    public class FilletWhole : Beef
    {
        public override BeefCut Cut => BeefCut.FilletWhole;

        public FilletWhole(double weight)
        {
                SetWeight(weight);
            SetPricePerKg(30.99m);
        }
    }
}
