using AldyarOnlineShoppig.Models.Interfaces.Order;

namespace AldyarOnlineShoppig.Models.Interfaces.Customer
{
    public interface ICustomer
    {
        int CustomerId { get; }
        string FirstName { get; }
        string LastName { get; }
        string Email { get; }

        string PhoneNumber { get; }
        IAddress Address { get; }
        DateTime RegisteredDate { get; }  // When they first became a customer
        ICollection<IOrder> OrderHistory { get; }  // Their past orders
        string FullName { get; }

    }
}
