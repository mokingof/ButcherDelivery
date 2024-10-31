using AldyarOnlineShoppig.Models.Core.Products.Abstract;
using AldyarOnlineShoppig.Models.Enums;
namespace AldyarOnlineShoppig.Models
{
    public class FilletWhole : Beef
    {
        public override BeefCut Cut => BeefCut.FilletWhole;

        public FilletWhole(double weight)
        {
            SetWeight(weight);
            SetPricePerKg(30.99m);
        }
    }
}
