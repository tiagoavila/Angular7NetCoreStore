using Angular7NetCoreStore.Domain.Entities;
using Angular7NetCoreStore.Domain.Interfaces;
using Angular7NetCoreStore.Infra.Data.Context;
using System.Linq;

namespace Angular7NetCoreStore.Infra.Data.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(Angular7NetCoreStoreContext context)
            : base(context)
        {

        }

        public Customer GetByEmail(string email)
        {
            return DbSet.FirstOrDefault(c => c.Email.Address == email);
        }
    }
}
