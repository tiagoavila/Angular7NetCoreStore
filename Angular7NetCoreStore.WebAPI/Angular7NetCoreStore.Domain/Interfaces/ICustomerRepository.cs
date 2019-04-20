using Angular7NetCoreStore.Domain.Entities;

namespace Angular7NetCoreStore.Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByEmail(string email);
    }
}
