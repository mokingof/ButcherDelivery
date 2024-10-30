using AldyarOnlineShoppig.Models.Enums;
using AldyarOnlineShoppig.Models.Interfaces.MeatProducts.Abstract;

namespace AldyarOnlineShoppig.Models.MeatProducts.Concrete.Beef
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
