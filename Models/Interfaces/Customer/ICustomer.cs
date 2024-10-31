using AldyarOnlineShoppig.Models.Interfaces.Order;

namespace AldyarOnlineShoppig.Models.Interfaces.Customer
{
    public interface ICustomer
    {
        int CustomerId { get; }
        IName Name { get; }
        IEmail Email { get; }
        IPhoneNumber PhoneNumber { get; }
        IAddress Address { get; }
        DateTime RegisteredDate { get; }  // When they first became a customer
        ICollection<IOrder> OrderHistory { get; }  // Their past orders


    }
}
