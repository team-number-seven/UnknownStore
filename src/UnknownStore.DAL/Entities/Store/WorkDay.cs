using System;

namespace UnknownStore.DAL.Entities.Store
{
    public class WorkDay:BaseEntity
    {
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartOfWork { get; set; }
        public TimeSpan EndOfWork { get; set; }

        public virtual DeliveryPoint DeliveryPoint { get; set; }
        public Guid DeliveryPointId { get; set; }
    }
}
