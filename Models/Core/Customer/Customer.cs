using AldyarOnlineShoppig.Models.ExceptionHandling.CustomerException;
using System.Text.RegularExpressions;
using Rbec.Postcodes;
using AldyarOnlineShoppig.Models.Interfaces.Customer;
using AldyarOnlineShoppig.Models.Interfaces.Order;

namespace AldyarOnlineShoppig.Models.Core.Customer
{
    public class Customer : ICustomer
    {
        private IName _name;
        private IEmail _email;
        private IPhoneNumber _phoneNumber;
        private IAddress _address;
        private readonly DateTime _registeredDate;

        // Required properties from interface
        public int CustomerId { get; private set; }
        public IName Name => _name;
        public IEmail Email => _email;
        public IPhoneNumber PhoneNumber => _phoneNumber;

        public DateTime RegisteredDate => _registeredDate;
        public ICollection<IOrder> OrderHistory => throw new NotImplementedException();
        public IAddress Address => _address;

        public Customer(int customerId, string firstName, string lastName, string email,
                       string phoneNumber, string street, string city, string postcode)
        {
            if (customerId <= 0)
                throw new ArgumentException("Customer ID must be positive", nameof(customerId));
            
            CustomerId = customerId;
            _name = new Name(firstName, lastName);
            _email = new Email(email);
            _address = new Address(street, city, postcode);
            _phoneNumber = new UserPhoneNumber(phoneNumber);
            _registeredDate = DateTime.Now;
        }
       
    }
}
