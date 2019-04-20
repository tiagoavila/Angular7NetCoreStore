using System;

namespace Angular7NetCoreStore.Domain.Shared
{
    public abstract class EntityBase
    {
        public Guid Id { get; protected set; }
        public DateTime CreateDate { get; protected set; }
        public DateTime UpdateDate { get; protected set; }
    }
}
