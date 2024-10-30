namespace AldyarOnlineShoppig.Models.Enums
{
    public enum OrderStatus
    {
        PendingPayment,
        ProcessingPayment,
        PaymentFailed,
        PaymentSuccessful,
        Shipped,
        Delivered,
    }
}

/* PendingPayment → ProcessingPayment → PaymentSuccessful → Shipped → Delivered
                                  → PaymentFailed */