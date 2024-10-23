namespace AldyarOnlineShoppig.Models.Interfaces
{
    public enum QuantityOperation
    {
        Increment,
        Decrement
    }
    public interface IShoppingCart
    {
        // Properties
        int ItemCount { get; } // Total number of items (including quantities)
        bool IsEmpty { get; } // Quick check if cart has any items

        IReadOnlyCollection<IShoppingCartItem> Items { get; } // Safe way to view cart contents without 
                                                              // allowing direct modifications

        // Methods
        void AddItem(IMeatProduct product);
        void RemoveItem(IMeatProduct product);
        void UpdateQuantity(IMeatProduct product, QuantityOperation operation);
   
        decimal GetTotalPrice(); // Calculate total cost of all items
        void Clear(); // Empty the cart completely
        IShoppingCartItem GetItem(IMeatProduct product); // Find specific item in cart
    }
}
