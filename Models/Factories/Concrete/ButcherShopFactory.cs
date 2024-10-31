using AldyarOnlineShoppig.Models.Enums;
using AldyarOnlineShoppig.Models.ExceptionHandling;
using AldyarOnlineShoppig.Models.Interfaces.Product;

namespace AldyarOnlineShoppig.Models.Factories.Concrete
{
    public class ButcherShopFactory
    {
        /* The main purpose of this class is to act as a "superfactory" or "abstract factory" that manages 
           and coordinates the creation of different types of meat products across various meat categories 
           regardless of the specific meat type .
        */
        public IMeatProduct CreateMeatProduct(MeatType meatType, Enum meatCut, double meatWeight)
        {
            try
            {
                // Determines which factory to use based on meat type
                MeatFactory factory = GetFactory(meatType);
                // Delegates creation to specific factory
                return factory.CreateMeatProduct(meatCut, meatWeight);
            }
           catch (InvalidMeatCutException ex)
            {
                Console.WriteLine($"Error creating meat product: {ex.Message}");
                throw;
            }
        }
        private MeatFactory GetFactory(MeatType type)
        {
            if (!Enum.IsDefined(typeof(MeatType), type))
            {
                throw new InvalidMeatCutException($"Invalid meat type: {type}");
            }
            switch (type)
            {
                case MeatType.Beef:
                    return new BeefFactory();
                case MeatType.Chicken:
                    return new ChickenFactory();
                default:
                    throw new InvalidMeatCutException($"Unsupported meat type: {type}");
            }
        }
    }
}
