using AldyarOnlineShoppig.Models.Enums;
using AldyarOnlineShoppig.Models.Interfaces.MeatProducts.Abstract;

namespace AldyarOnlineShoppig.Models.MeatProducts.Concrete.Beef
{
    public class Mince : Beef
    {
        public override BeefCut Cut => BeefCut.Mince;

        public Mince(double weight)
        {
            SetWeight(weight);
            SetPricePerKg(5.99m);
        }
    }
}
