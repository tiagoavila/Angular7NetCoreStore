using Angular7NetCoreStore.Domain.Entities;
using Angular7NetCoreStore.Domain.Enums;
using Angular7NetCoreStore.Domain.Shared;
using Angular7NetCoreStore.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Angular7NetCoreStore.Domain
{
    public class Order : EntityBase
    {
        public Order(Guid customerId, Address address, IEnumerable<OrderItem> orderItems)
        {
            CustomerId = customerId;
            Address = address;
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _orderItems = orderItems.ToList();
        }

        protected Order()
        {
            // required by EF
        }

        public Guid CustomerId { get; private set; }
        public Customer Customer { get; private set; }
        public EOrderStatus Status { get; private set; }
        public Address Address { get; private set; }

        private readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

        public void AddItem(Product product, int quantity)
        {
            var orderItem = new OrderItem(product, quantity);
            _orderItems.Add(orderItem);
        }

        public decimal Total()
        {
            var total = 0m;
            foreach (var item in _orderItems)
            {
                total += item.Price * item.Quantity;
            }
            return total;
        }

        public void Pay()
        {
            Status = EOrderStatus.Paid;
        }

        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
        }

        public void Ship()
        {
            Status = EOrderStatus.Shipping;
        }
    }
}
