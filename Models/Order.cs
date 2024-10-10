using AldyarOnlineShoppig.Models.Enums;
using AldyarOnlineShoppig.Models.Interfaces;
using Microsoft.VisualBasic;

namespace AldyarOnlineShoppig.Models
{
    public class Order : IOrder
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedDate { get; set; }

        public Guid Id => throw new NotImplementedException();

        public DateTime OrderDate => throw new NotImplementedException();

        string IOrder.CustomerId => throw new NotImplementedException();

        public void AddItem(IMeatProduct product, double quantity)
        {
            throw new NotImplementedException();
        }

        public decimal CalculateTotal()
        {
            throw new NotImplementedException();
        }

        public decimal CalculateTotalForCut(Enum cut)
        {
            throw new NotImplementedException();
        }

        public decimal CalculateTotalForMeatType(MeatType meatType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<(IMeatProduct Product, double Quantity)> GetOrderItems()
        {
            throw new NotImplementedException();
        }

        public string GetOrderSummary()
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(IMeatProduct product, double quantity)
        {
            throw new NotImplementedException();
        }
    }
}
