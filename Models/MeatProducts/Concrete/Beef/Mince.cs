using AldyarOnlineShoppig.Models.Enums;
using AldyarOnlineShoppig.Models.MeatProducts.Abstract;

namespace AldyarOnlineShoppig.Models.MeatProducts.Concrete
{
    public class Mince : Beef
    {
        public override BeefCut Cut => BeefCut.Mince;

        public Mince(double weigt)
        {
            Weight = weigt;
            PricePerKg = 5.99m;
        }
    }
}
