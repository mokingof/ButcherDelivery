using AldyarOnlineShoppig.Models.Interfaces;

namespace AldyarOnlineShoppig.Models
{

    public class ShoppingCart : IShoppingCart
    {
        private Dictionary<IMeatProduct, IShoppingCartItem> _items = new();

        public int ItemCount { get; }
        public bool IsEmpty { get; }
        public IReadOnlyCollection<IShoppingCartItem> Items { get; }


        public void AddItem(IMeatProduct product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));


            if (_items.ContainsKey(product))
            {

                UpdateQuantity(product, QuantityOperation.Increment);
            }
            else
            {
                _items[product] = new ShoppingCartItem(product, 1);
            }
        }
        public void RemoveItem(IMeatProduct product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (_items.ContainsKey(product))
            {
                int quantity = _items[product].Quantity;
                if (quantity - 1 <= 0)
                {
                    _items.Remove(product);
                }
                else
                {
                    UpdateQuantity(product, QuantityOperation.Decrement);
                }
            }
        }

        public void UpdateQuantity(IMeatProduct product, QuantityOperation operation)
        {
            int quantity = _items[product].Quantity;
            int newQuantity = operation.Equals(QuantityOperation.Increment) ? quantity + 1 : quantity - 1;

            _items[product] = new ShoppingCartItem(product, newQuantity);


        }
        public IShoppingCartItem GetItem(IMeatProduct product)
        {
            throw new NotImplementedException();
        }
        public decimal GetTotalPrice()
        {
            throw new NotImplementedException();
        }
        public void Clear()
        {
            throw new NotImplementedException();
        }




    }
}
