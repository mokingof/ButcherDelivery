using AldyarOnlineShoppig.Models.Enums;
using AldyarOnlineShoppig.Models.Factories.Abstract;
using AldyarOnlineShoppig.Models.Interfaces;
using AldyarOnlineShoppig.Models.MeatProducts.Concrete;

namespace AldyarOnlineShoppig.Models.Factories.Concrete
{
    public class BeefFactory : MeatFactory
    {
        /*
         * Concrete implementation of MeatFactory specifically for creating beef products.
         * It encapsulates the logic for choosing which specific beef class to instantiate based on the cut type.
         */
        public override IMeatProduct CreateMeatProduct(Enum cut, double weight)
        {
            switch ((BeefCut)cut)
            {
                case BeefCut.Sirloin:
                    return new Sirloin(weight);
                case BeefCut.Mince:
                    return new Mince(weight);
                // ... other cases
                default:
                    throw new ArgumentException("Invalid beef cut", nameof(cut));
            }
        }
    }
}
