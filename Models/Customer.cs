using AldyarOnlineShoppig.Models.Interfaces;

namespace AldyarOnlineShoppig.Models
{
    public class Customer : ICustomer
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phoneNumber;
        private string _address;
        private readonly DateTime _registeredDate;

        // Required properties from interface
        public int CustomerId { get; private set; }
        public string FirstName => _firstName;
        public string LastName => _lastName;
        public string Email => _email;
        public string PhoneNumber => _phoneNumber;
        public string Address => _address;

        // Additional useful properties
        public string FullName => $"{FirstName} {LastName}";
        public DateTime RegisteredDate => _registeredDate;

        public ICollection<IOrder> OrderHistory => throw new NotImplementedException();

         }

        public Customer(int customerId, string firstName, string lastName, string email,
                       string phoneNumber, string address)
        {
            // What validation should we add here?
            CustomerId = customerId;
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _phoneNumber = phoneNumber;
            _address = address;
            _registeredDate = DateTime.Now;
        }
    }
}
