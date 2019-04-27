using System;

namespace Angular7NetCoreStore.Domain.Commands.Inputs
{
    public class ProductOrderItem
    {
        public Guid Id { get; set; }
        public int AmountProductToCart { get; set; }
        public string Title { get; set; }
    }
}
