using AldyarOnlineShoppig.Models.Core.Products.Abstract;
using AldyarOnlineShoppig.Models.Enums;
namespace AldyarOnlineShoppig.Models
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
