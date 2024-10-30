using AldyarOnlineShoppig.Models.Enums;
namespace AldyarOnlineShoppig.Models.MeatProducts.Abstract
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
