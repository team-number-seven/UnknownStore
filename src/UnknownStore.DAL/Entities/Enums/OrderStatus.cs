namespace UnknownStore.DAL.Entities.Enums
{
    public enum OrderStatus
    {
        PendingConfirmation,
        InStorage,
        SentToDeliveryAddress,
        ArrivedAtDeliveryPoint,
        Delivered,
        Cancelled,
    }
}
