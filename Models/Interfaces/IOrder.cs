using AldyarOnlineShoppig.Models.Enums;

namespace AldyarOnlineShoppig.Models.Interfaces
{
    public interface IOrder
    {
        Guid Id { get; }
        DateTime OrderDate { get; }
        string CustomerId { get; }

        void AddItem(IMeatProduct product, double quantity);
        void RemoveItem(IMeatProduct product, double quantity);
        decimal CalculateTotal();
        IEnumerable<(IMeatProduct Product, double Quantity)> GetOrderItems();
        decimal CalculateTotalForMeatType(MeatType meatType);
        decimal CalculateTotalForCut(Enum cut);
        string GetOrderSummary();


    }
}
