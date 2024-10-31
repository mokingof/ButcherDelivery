using AldyarOnlineShoppig.Models.Core.Products.Abstract;
using AldyarOnlineShoppig.Models.Enums;
namespace AldyarOnlineShoppig.Model 
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
