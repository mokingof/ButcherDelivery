using AldyarOnlineShoppig.Models.Enums;
using AldyarOnlineShoppig.Models.Interfaces.MeatProducts.Abstract;

namespace AldyarOnlineShoppig.Models.MeatProducts.Concrete.Beef
{
    public class Sirloin : Beef
    {

        public override BeefCut Cut => BeefCut.Sirloin;

        public Sirloin(double weight)
        {
            SetWeight(weight);
            SetPricePerKg(15.99m);
        }

    }
}
