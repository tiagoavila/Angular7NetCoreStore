using Angular7NetCoreStore.Domain.Entities;
using Angular7NetCoreStore.Domain.Interfaces;
using Angular7NetCoreStore.Infra.Data.Context;

namespace Angular7NetCoreStore.Infra.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(Angular7NetCoreStoreContext context)
            : base(context)
        {

        }
    }
}
