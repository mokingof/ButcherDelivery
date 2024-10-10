using System;
using System.Collections.Generic;
using AldyarOnlineShoppig.Models.Enums;
using AldyarOnlineShoppig.Models.Interfaces;

namespace AldyarOnlineShoppig.Models.Interfaces
{
    public interface IOrder
    {
        Guid OrderId { get; }
        DateTime OrderDate { get; }
        string CustomerId { get; }


        void AddItem(IMeatProduct product, Enum cut, double quantity);
        void RemoveItem(IMeatProduct product, Enum cut, double quantity);
        bool UpdateItem(IMeatProduct product, Enum cut, double quantity);
        IEnumerable<OrderItem> GetOrderItems();
        decimal CalculateTotalForMeatType(MeatType meatType);
        decimal CalculateTotalForCut(Enum cut);
        decimal CalculateTotal();
        string GetOrderSummary();
    }
}