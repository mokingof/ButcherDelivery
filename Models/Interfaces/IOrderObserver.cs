namespace AldyarOnlineShoppig.Models.Interfaces
{
    public interface IOrderObserver
    {
        void OnOrderChanged(IOrder order, OrderChangeType changeType, OrderItem item);
        void OnOrderCompleted(IOrder order);
    }

    public enum OrderChangeType
    {
        ItemAdded,
        ItemRemoved,
        QuantityIncreased,
        QuantityDecreased
    }
}
