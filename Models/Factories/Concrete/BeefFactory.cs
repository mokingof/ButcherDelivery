using AldyarOnlineShoppig.Model;
using AldyarOnlineShoppig.Models.Enums;
using AldyarOnlineShoppig.Models.ExceptionHandling;
using AldyarOnlineShoppig.Models.Interfaces.Product;

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
            // Validates the cut type
            if (!Enum.IsDefined(typeof(BeefCut), cut))
            {
                throw new InvalidMeatCutException($"Invalid beef cut: {cut}");
            }
            // Creates specific beef product
            switch ((BeefCut)cut)
            {
                case BeefCut.Sirloin:
                    return new Sirloin(weight);
                case BeefCut.Mince:
                    return new Mince(weight);
                case BeefCut.FilletSteak:
                    return new FilletSteak(weight);
                case BeefCut.FilletWhole:
                    return new FilletWhole(weight);
                case BeefCut.Ribs:
                    return new Ribs(weight);
                case BeefCut.TBone:
                    return new TBone(weight);
                case BeefCut.TopSide:
                    return new TopSide(weight);
                default:
                    throw new ArgumentException($"Unsupported beef cut: {cut}");
            }
        }
    }
}
