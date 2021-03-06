﻿using Angular7NetCoreStore.Domain.Shared;
using System;

namespace Angular7NetCoreStore.Domain.Entities
{
    public class OrderItem : EntityBase
    {
        public OrderItem(Product product, decimal quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = product.Price;
            CreateDate = DateTime.Now;

            product.DecreaseQuantity(quantity);
        }

        // Empty constructor for EF
        protected OrderItem()
        {

        }

        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }
    }
}
