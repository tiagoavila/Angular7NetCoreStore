using Angular7NetCoreStore.Domain.Shared;
using System;

namespace Angular7NetCoreStore.Domain.Entities
{
    public class Product : EntityBase
    {
        public Product(
            Guid id,
            string title,
            string description,
            string image,
            decimal price,
            decimal quantity)
        {
            Id = id;
            Title = title;
            Description = description;
            Image = image;
            Price = price;
            QuantityOnHand = quantity;
        }

        // Empty constructor for EF
        protected Product()
        {

        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }
        public decimal Price { get; private set; }
        public decimal QuantityOnHand { get; private set; }

        public void DecreaseQuantity(decimal quantity)
        {
            QuantityOnHand -= quantity;
        }

        public void UpdatePrice(decimal newPrice)
        {
            Price = newPrice;
        }

        public void UpdateDescription(string newDescription)
        {
            Description = newDescription;
        }
    }
}
