using AldyarOnlineShoppig.Models.Core.Products.Abstract;
using AldyarOnlineShoppig.Models.Enums;

namespace AldyarOnlineShoppig.Models
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
