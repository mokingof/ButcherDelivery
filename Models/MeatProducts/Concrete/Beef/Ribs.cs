using AldyarOnlineShoppig.Models.Enums;
using AldyarOnlineShoppig.Models.MeatProducts.Abstract;

namespace AldyarOnlineShoppig.Models.MeatProducts.Concrete
{
    public class Ribs : Beef
    {
        public override BeefCut Cut => BeefCut.Ribs;

        public Ribs(double wight)
        {
            Weight = wight;
            PricePerKg = 10.99;
        }
    }
}
