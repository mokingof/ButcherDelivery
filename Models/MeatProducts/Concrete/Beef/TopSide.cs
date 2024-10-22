using AldyarOnlineShoppig.Models.Enums;
using AldyarOnlineShoppig.Models.MeatProducts.Abstract;

namespace AldyarOnlineShoppig.Models.MeatProducts.Concrete
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
