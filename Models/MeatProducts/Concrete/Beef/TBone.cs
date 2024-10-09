using AldyarOnlineShoppig.Models.Enums;
using AldyarOnlineShoppig.Models.MeatProducts.Abstract;

namespace AldyarOnlineShoppig.Models.MeatProducts.Concrete
{
    public class TBone : Beef
    {
        public override BeefCut Cut => BeefCut.TBone;

        public TBone(double weight)
        {
            Weight = weight;
            PricePerKg = 20.99;
        }
    }
}