using Angular7NetCoreStore.Domain.Shared;
using System;

namespace Angular7NetCoreStore.Domain
{
    public class Order : EntityBase
    {
        public Guid CustomerId { get; set; }

    }
}
