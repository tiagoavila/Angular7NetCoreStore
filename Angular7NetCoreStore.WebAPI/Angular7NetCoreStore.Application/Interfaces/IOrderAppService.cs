using Angular7NetCoreStore.Domain.Commands.Inputs;
using Angular7NetCoreStore.Domain.Shared.Commands;
using System;

namespace Angular7NetCoreStore.Application.Interfaces
{
    public interface IOrderAppService : IDisposable
    {
        ICommandResult AddOrder(CreateOrderCommand createOrderCommand);
    }
}
