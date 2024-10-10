using AldyarOnlineShoppig.Models.Enums;
using AldyarOnlineShoppig.Models.ExceptionHandling;
using AldyarOnlineShoppig.Models.Interfaces;
using Microsoft.VisualBasic;
using System.Text;

namespace AldyarOnlineShoppig.Models
{
    public class Order : IOrder
    {
        // Stores order items with a tuple of product and cut as the key
        private readonly Dictionary<(IMeatProduct Product, Enum Cut), OrderItem> _items;
        
        // Keeps track of observers for the Observer pattern
        private readonly List<IOrderObserver> _observers;

        // Caching fields to improve performance of repeated calculations
        private decimal _cachedTotal = 0m;
        private Dictionary<MeatType, decimal> _cachedTotalsByMeatType = new Dictionary<MeatType, decimal>();
        private Dictionary<Enum, decimal> _cachedTotalsByCut = new Dictionary<Enum, decimal>();

        // Public properties
        public Guid OrderId { get; }
        public DateTime OrderDate { get; }
        public string CustomerId { get; }
        
        // Constructor
        public Order(string customerId)
        {   // Initializes a new order with a unique ID, current date, and customer ID
            OrderId = Guid.NewGuid();
            OrderDate = DateTime.Now;
            CustomerId = customerId;
            _items = new Dictionary<(IMeatProduct Product, Enum Cut), OrderItem>();
            _observers = new List<IOrderObserver>();
        }
        
        // Adds a new item to the order or updates quantity if it already exists
        public void AddItem(IMeatProduct product, Enum cut, double quantity)
        {
            ValidateItemInput(product, cut, quantity);

            var key = (product, cut);
            if (_items.TryGetValue(key, out var existingItem))
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                _items[key] = new OrderItem(product, cut, quantity);
            }
            InvalidateCaches();
            NotifyObservers(OrderChangeType.ItemAdded, _items[key]);
        }
        
        // Removes a specified quantity of an item from the order
        public void RemoveItem(IMeatProduct product, Enum cut, double quantity)
        {
            ValidateItemInput(product, cut, quantity);

            var key = (product, cut);
            if (!_items.TryGetValue(key, out var existingItem))
                throw new InvalidOperationException("Cannot remove an item that is not in the order.");

            if (existingItem.Quantity <= quantity)
            {
                _items.Remove(key);
            }
            else
            {
                existingItem.Quantity -= quantity;
            }
            InvalidateCaches();
            NotifyObservers(OrderChangeType.ItemRemoved, existingItem);
        }
        
        // Updates the quantity of an existing item in the order
        public bool UpdateItem(IMeatProduct product, Enum cut, double newQuantity)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            if (cut == null)
                throw new ArgumentNullException(nameof(cut));

            var key = (product, cut);
            if (!_items.TryGetValue(key, out var existingItem))
            {
                return false; // Item not found, update failed
            }

            if (newQuantity <= 0)
            {
                _items.Remove(key);
                NotifyObservers(OrderChangeType.ItemRemoved, existingItem);
            }
            else
            {
                if (newQuantity == existingItem.Quantity)
                {
                    return true; // No change needed
                }

                double oldQuantity = existingItem.Quantity;
                existingItem.Quantity = newQuantity;
                var changeType = newQuantity > oldQuantity ? OrderChangeType.QuantityIncreased : OrderChangeType.QuantityDecreased;
                InvalidateCaches();
                NotifyObservers(changeType, existingItem);
            }

            return true; // Update successful
        }
        
        // Calculates the total price for a specific meat type, using caching for efficiency
        public decimal CalculateTotal()
        {
            if (_cachedTotal == 0m)
            {
                _cachedTotal = _items.Values.Sum(item => item.TotalPrice);
            }
            return _cachedTotal;
        }

        // Calculates the total price for a specific meat type, using caching for efficiency
        public decimal CalculateTotalForMeatType(MeatType meatType)
        {
            if (!_cachedTotalsByMeatType.TryGetValue(meatType, out decimal total))
            {
                total = _items.Values
                    .Where(item => item.Product.Type == meatType)
                    .Sum(item => item.TotalPrice);
                _cachedTotalsByMeatType[meatType] = total;
            }
            return total;
        }

        // Calculates the total price for a specific cut, using caching for efficiency
        public decimal CalculateTotalForCut(Enum cut)
        {
            if (!_cachedTotalsByCut.TryGetValue(cut, out decimal total))
            {
                total = _items.Values
                    .Where(item => item.Cut.Equals(cut))
                    .Sum(item => item.TotalPrice);
                _cachedTotalsByCut[cut] = total;
            }
            return total;
        }
        
        // Returns all items in the order
        public IEnumerable<OrderItem> GetOrderItems()
        {
            return _items.Values;
        }
        
        // Generates a string summary of the order
        public string GetOrderSummary()
        {
            var summary = new StringBuilder();
            summary.AppendLine($"Order ID: {OrderId}");
            summary.AppendLine($"Order Date: {OrderDate}");
            summary.AppendLine($"Customer ID: {CustomerId}");
            summary.AppendLine("Items:");
            foreach (var item in _items.Values)
            {
                summary.AppendLine($"- {item.Product.Type} ({item.Cut}): {item.Quantity} kg at {item.Product.PricePerKg:C} per kg = {item.TotalPrice:C}");
            }
            summary.AppendLine($"Total: {CalculateTotal():C}");
            return summary.ToString();
        }
        
        // Invalidates all cached calculations when the order changes
        private void InvalidateCaches()
        {
            _cachedTotal = 0m;
            _cachedTotalsByMeatType.Clear();
            _cachedTotalsByCut.Clear();
        }
       
        // Adds an observer to the list of observers
        public void AddObserver(IOrderObserver observer)
        {
            _observers.Add(observer);
        }
        
        // Removes an observer from the list of observers
        public void RemoveObserver(IOrderObserver observer)
        {
            _observers.Remove(observer);
        }
       
        // Notifies all observers of a change in the order
        private void NotifyObservers(OrderChangeType changeType, OrderItem item)
        {
            foreach (var observer in _observers)
            {
                observer.OnOrderChanged(this, changeType, item);
            }
        }
       
        // Validates input for adding, removing, or updating items
        private void ValidateItemInput(IMeatProduct product, Enum cut, double quantity)
        {
            List<string> errors = new List<string>();

            if (product == null)
                errors.Add("Product cannot be null.");
            if (cut == null)
                errors.Add("Cut cannot be null.");
            if (quantity <= 0)
                errors.Add("Quantity must be positive.");

            if (errors.Any())
                throw new OrderValidationException(string.Join(" ", errors));
        }


    }
}
