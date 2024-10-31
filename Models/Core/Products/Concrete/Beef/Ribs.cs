using AldyarOnlineShoppig.Models.Core.Products.Abstract;
using AldyarOnlineShoppig.Models.Enums;
namespace AldyarOnlineShoppig.Models
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
