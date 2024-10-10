using AldyarOnlineShoppig.Models.Enums;
using AldyarOnlineShoppig.Models.MeatProducts.Abstract;

namespace AldyarOnlineShoppig.Models.MeatProducts.Concrete
{
    public class FilletWhole : Beef
    {
        public override BeefCut Cut => BeefCut.FilletWhole;

        public FilletWhole(double weight)
        {
            Weight = weight;
            PricePerKg = 30.00m;
        }
    }
}
