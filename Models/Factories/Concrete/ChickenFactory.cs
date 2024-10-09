using AldyarOnlineShoppig.Models.Enums;
using AldyarOnlineShoppig.Models.Factories.Abstract;
using AldyarOnlineShoppig.Models.Interfaces;
using AldyarOnlineShoppig.Models.MeatProducts.Concrete;

namespace AldyarOnlineShoppig.Models.Factories.Concrete
{
    public class ChickenFactory : MeatFactory
    {
        /*
       * Concrete implementation of MeatFactory specifically for creating beef products.
       * It encapsulates the logic for choosing which specific beef class to instantiate based on the cut type.
       */
        public override IMeatProduct CreateMeatProduct(Enum cut, double weight)
        {
            switch ((ChickenCut)cut)
            {
                case ChickenCut.ChickenBreast:
                    return new Sirloin(weight);
                case ChickenCut.ChickenLegs:
                    return new Mince(weight);
                // ... other cases
                default:
                    throw new ArgumentException("Invalid beef cut", nameof(cut));
            }
        }
    }
}
