using AldyarOnlineShoppig.Models.Enums;
using AldyarOnlineShoppig.Models.ExceptionHandling;
using AldyarOnlineShoppig.Models.Factories.Abstract;
using AldyarOnlineShoppig.Models.Interfaces;
using AldyarOnlineShoppig.Models.MeatProducts;
using AldyarOnlineShoppig.Models.MeatProducts.Abstract;
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
            if (!Enum.IsDefined(typeof(ChickenCut), cut))
            {
                throw new InvalidMeatCutException($"Invalid beef cut: {cut}");
            }

            switch ((ChickenCut)cut)
            {
                case ChickenCut.Breast:
                    return new Breast(weight);
                case ChickenCut.Legs:
                    return new Legs(weight);
                case ChickenCut.Thighs:
                    return new Thigh(weight);
                case ChickenCut.Wings:
                    return new Wings(weight);
                // ... other cases
                default:
                    throw new InvalidMeatCutException($"Unsupported beef cut: {cut}");
            }
        }
    }
}
