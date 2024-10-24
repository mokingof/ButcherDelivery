using AldyarOnlineShoppig.Models.Interfaces;

namespace AldyarOnlineShoppig.Models
{

    public class ShoppingCart : IShoppingCart
    {
        private Dictionary<IMeatProduct, IShoppingCartItem> _items = new();
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
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }    

            if (_items.ContainsKey(product))
            {
                return _items[product];
            }
             
            return null;
        }
        public decimal GetTotalPrice()
        {
            return _items.Values.Sum(item => item.Subtotal);
        }
        public void Clear()
        {
            _items.Clear();
        }

        public int GetItemCount()
        {
            return _items.Values.Sum(item => item.Quantity);
        }

        public IReadOnlyCollection<IShoppingCartItem> GetAllItems()
        {
            return _items.Values.ToList();  
        }
    }
}
