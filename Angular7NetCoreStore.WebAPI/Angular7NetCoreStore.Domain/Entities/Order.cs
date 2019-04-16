using Angular7NetCoreStore.Domain.Entities;
using Angular7NetCoreStore.Domain.Enums;
using Angular7NetCoreStore.Domain.Shared;
using System;
using System.Collections.Generic;

namespace Angular7NetCoreStore.Domain
{
    public class Order : EntityBase
    {
        public Order(Guid customerId, Address address)
        {
            CustomerId = customerId;
            Address = address;
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _orderItems = new List<OrderItem>();
        }

        protected Order()
        {
            // required by EF
        }

        public Guid CustomerId { get; private set; }
        public Customer Customer { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public Address Address { get; private set; }

        private readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

        public void AddItem(Product product, int quantity)
        {
            //TODO: Study about how to implement validation
            //if (quantity > product.QuantityOnHand)
            //    AddNotification("OrderItem", $"Produto {product.Title} não tem {quantity} itens em estoque.");

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
