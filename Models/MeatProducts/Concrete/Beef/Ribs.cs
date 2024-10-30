using AldyarOnlineShoppig.Models.Enums;
using AldyarOnlineShoppig.Models.Interfaces.MeatProducts.Abstract;

namespace AldyarOnlineShoppig.Models.MeatProducts.Concrete.Beef
{
    public class Ribs : Beef
    {
        public override BeefCut Cut => BeefCut.Ribs;

        public Ribs(double weight)
        {
            SetWeight(weight);
            SetPricePerKg(10.99m);
        }
    }
}
