using Angular7NetCoreStore.Application.Dtos;
using Angular7NetCoreStore.Domain.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Angular7NetCoreStore.Application.Interfaces
{
    public interface ICustomerAppService : IDisposable
    {
        IEnumerable<CustomerDto> GetAll();

        Task<ICommandResult> AddCustomerAsync(AddCustomerDto addCustomerDto);
    }
}
