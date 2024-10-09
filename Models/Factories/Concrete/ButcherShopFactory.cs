using AldyarOnlineShoppig.Models.Enums;
using AldyarOnlineShoppig.Models.Factories.Abstract;
using AldyarOnlineShoppig.Models.Interfaces;

namespace AldyarOnlineShoppig.Models.Factories.Concrete
{
    public class ButcherShopFactory
    {
        /* The main purpose of this class is to act as a "superfactory" or "abstract factory" that manages 
           and coordinates the creation of different types of meat products across various meat categories 
           regardless of the specific meat type .
        */
        public IMeatProduct CreateMeatProduct(MeatType type, Enum cut, double weight)
        {
            MeatFactory factory = GetFactory(type);
            return factory.CreateMeatProduct(cut, weight);
        }
        private MeatFactory GetFactory(MeatType type)
        {
            switch (type)
            {
                case MeatType.Beef:
                    return new BeefFactory();
                case MeatType.Chicken:
                    return new ChickenFactory();
                // Add other meat type factories here
                default:
                    throw new ArgumentException("Invalid meat type", nameof(type));
            }
        }
    }
}
