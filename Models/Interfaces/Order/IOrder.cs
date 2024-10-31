using AldyarOnlineShoppig.Models.Enums;
using AldyarOnlineShoppig.Models.Interfaces.Customer;

namespace AldyarOnlineShoppig.Models.Interfaces.Order
{
    public interface IOrder
    {
        int OrderId { get; }
        DateTime OrderDate { get; }
        OrderStatus Status { get; }
        ICollection<IOrderItem> OrderItems { get; }
        decimal TotalPrice { get; }

        ICustomer Customer { get; }
        // Basic payment info
        bool IsPaid { get; }

        void UpdateStatus(OrderStatus newStatus);


    }
}
