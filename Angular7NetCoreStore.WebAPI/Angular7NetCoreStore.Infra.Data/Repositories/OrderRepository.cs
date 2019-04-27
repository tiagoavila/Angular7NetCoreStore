using Angular7NetCoreStore.Domain;
using Angular7NetCoreStore.Domain.Interfaces;
using Angular7NetCoreStore.Infra.Data.Context;

namespace Angular7NetCoreStore.Infra.Data.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(Angular7NetCoreStoreContext context)
           : base(context)
        {

        }
    }
}
