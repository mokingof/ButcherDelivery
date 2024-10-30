using AldyarOnlineShoppig.Models.Enums;

namespace AldyarOnlineShoppig.Models.Interfaces
{
    public interface IOrder
    {
        int OrderId { get; }
        DateTime OrderDate { get; }
        OrderStatus Status { get; }
        ICollection<IOrderItem> OrderItems { get; }
        decimal TotalPrice { get; }

        
        // Essential customer info
        string CustomerName { get; }
        string DeliveryAddress { get; }
        string PhoneNumber { get; }  // For delivery coordination

        // Basic payment info
        bool IsPaid { get; }

        void UpdateStatus(OrderStatus newStatus);


    }
}
