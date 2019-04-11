namespace Angular7NetCoreStore.Application.Dtos
{
    public class ProductDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public decimal QuantityOnHand { get; set; }
    }
}
