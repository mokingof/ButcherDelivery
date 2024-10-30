using AldyarOnlineShoppig.Models.Enums;
namespace AldyarOnlineShoppig.Models.MeatProducts.Abstract
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
