using AldyarOnlineShoppig.Models.Interfaces;

namespace AldyarOnlineShoppig.Models.Factories.Abstract
{
    public abstract class MeatFactory
    {
        // Common Interface for creating concrete meat factories (likes BeefFactory, ChickenFactory, etc.)
        public abstract IMeatProduct CreateMeatProduct(Enum cut, double weight);


    }
}
