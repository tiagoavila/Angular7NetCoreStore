using Angular7NetCoreStore.Application.Interfaces;
using Angular7NetCoreStore.Domain.CommandHandlers;
using Angular7NetCoreStore.Domain.Commands.Inputs;
using Angular7NetCoreStore.Domain.Shared.Commands;
using System;

namespace Angular7NetCoreStore.Application.Services
{
    public class OrderAppService : IOrderAppService
    {
        private readonly OrderCommandHandler _orderCommandHandler;

        public OrderAppService(OrderCommandHandler orderCommandHandler)
        {
            _orderCommandHandler = orderCommandHandler;
        }

        public ICommandResult AddOrder(CreateOrderCommand createOrderCommand)
        {
            return _orderCommandHandler.Handle(createOrderCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
