using System;

namespace UnknownStore.DAL.Interfaces
{
    public interface IBaseEntity
    {
        public Guid Id { get; set; }
    }
}