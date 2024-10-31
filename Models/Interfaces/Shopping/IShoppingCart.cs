using AldyarOnlineShoppig.Models.Interfaces.Product;

namespace AldyarOnlineShoppig.Models.Interfaces.Shopping
{
    // Used in UpdateQuantity to be able to know the differenc between incrementing or decrementing item.
    public enum QuantityOperation
    {
        Increment,
        Decrement
    }
    public interface IShoppingCart
    {


        void AddItem(IMeatProduct product);
        void RemoveItem(IMeatProduct product);
        void UpdateQuantity(IMeatProduct product, QuantityOperation operation);
        decimal GetTotalPrice(); // Calculate total cost of all items
        void Clear(); // Empty the cart completely

        int GetTotalItemQuantity(); // Total number of items (including quantities)
        IShoppingCartItem GetItem(IMeatProduct product); // Find specific item in cart
        IReadOnlyCollection<IShoppingCartItem> GetAllItems(); // Safe way to view cart contents without 
                                                              // allowing direct modification
    }
}
