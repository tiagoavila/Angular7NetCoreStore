using Angular7NetCoreStore.Domain.Commands.Inputs;
using Angular7NetCoreStore.Domain.Commands.Outputs;
using Angular7NetCoreStore.Domain.Entities;
using Angular7NetCoreStore.Domain.Interfaces;
using Angular7NetCoreStore.Domain.Shared.Commands;
using System.Collections.Generic;
using System.Linq;

namespace Angular7NetCoreStore.Domain.CommandHandlers
{
    public class OrderCommandHandler : ICommandHandler<CreateOrderCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderCommandHandler(ICustomerRepository customerRepository, IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public ICommandResult Handle(CreateOrderCommand command)
        {
            if (!command.IsValid())
            {
                return new CommandResult(command.ValidationResult);
            }

            var customer = _customerRepository.GetById(command.CustomerId);
            if (customer == null)
            {
                return new CommandResult(false, "Customer does not exist");
            }

            var errorMessages = new List<string>();
            var orderItems = new List<OrderItem>();
            foreach (var productItem in command.Products)
            {
                var product = _productRepository.GetById(productItem.Id);
                if (product.QuantityOnHand >= productItem.AmountProductToCart)
                {
                    var orderItem = new OrderItem(product, productItem.AmountProductToCart);
                    orderItems.Add(orderItem);
                }
                else
                {
                    errorMessages.Add($"{product.Title} does not have {productItem.AmountProductToCart} items on stock");
                }
            }

            if (errorMessages.Any())
            {
                return new CommandResult(false, errorMessages);
            }

            var order = new Order(command.CustomerId, customer.Address, orderItems);

            _orderRepository.Add(order);
            _orderRepository.SaveChanges();

            return new CommandResult(true, "Order successfully registered", customer);
        }
    }
}
