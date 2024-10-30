using AldyarOnlineShoppig.Models.Enums;

namespace AldyarOnlineShoppig.Models.Interfaces
{
    public interface IOrder
    {
        int OrderId { get; }
        DateTime OrderDate { get; }
        OrderStatus Status { get; } 
        IShoppingCart shoppingCart { get; }
    }
}
