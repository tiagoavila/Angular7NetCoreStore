using Angular7NetCoreStore.Domain.Interfaces;
using Angular7NetCoreStore.Infra.Data.Context;

namespace Angular7NetCoreStore.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Angular7NetCoreStoreContext _context;

        public UnitOfWork(Angular7NetCoreStoreContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
