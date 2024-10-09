using AldyarOnlineShoppig.Models.Interfaces;

namespace AldyarOnlineShoppig.Models.Factories.Abstract
{
    public abstract class MeatFactory
    {
        /* This is an abstract base class that defines the interface for creating meat products.
         * Common Interface for creating concrete meat factories (likes BeefFactory, ChickenFactory, etc.)
         */

        public abstract IMeatProduct CreateMeatProduct(Enum cut, double weight);


    }
}
