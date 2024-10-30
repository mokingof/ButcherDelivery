using AldyarOnlineShoppig.Models.Enums;
using AldyarOnlineShoppig.Models.Interfaces.MeatProducts.Abstract;

namespace AldyarOnlineShoppig.Models.MeatProducts.Concrete.Beef
{
    public class TBone : Beef
    {
        public override BeefCut Cut => BeefCut.TBone;

        public TBone(double weight)
        {
            SetWeight(weight);
            SetPricePerKg(20.99m);
        }
    }
}