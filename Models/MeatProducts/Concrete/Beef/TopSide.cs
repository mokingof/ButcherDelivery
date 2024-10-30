using AldyarOnlineShoppig.Models.Enums;
using AldyarOnlineShoppig.Models.Interfaces.MeatProducts.Abstract;

namespace AldyarOnlineShoppig.Models.MeatProducts.Concrete.Beef
{
    public class TopSide : Beef
    {
        public override BeefCut Cut => BeefCut.TopSide;

        public TopSide(double weight)
        {
            SetWeight(weight);
            SetPricePerKg(59.00m);

        }
    }
}
