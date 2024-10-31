using AldyarOnlineShoppig.Models.Interfaces.Product;

namespace AldyarOnlineShoppig.Models
{
    public abstract class MeatFactory
    {
        /* This is an abstract base class that defines the interface for creating meat products.
         * Common Interface for creating concrete meat factories (likes BeefFactory, ChickenFactory, etc.)
         */

        public abstract IMeatProduct CreateMeatProduct(Enum cut, double weight);


    }
}
