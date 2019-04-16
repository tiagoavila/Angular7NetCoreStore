using Angular7NetCoreStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Angular7NetCoreStore.Infra.Data.Mappings
{
    public class OrderItemMap : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.Property(c => c.Id).HasColumnName("Id");

            builder.HasOne(c => c.Product);
        }
    }
}
