using Angular7NetCoreStore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Angular7NetCoreStore.Infra.Data.Mappings
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(c => c.Id).HasColumnName("Id");

            builder.HasOne(o => o.Customer)
                .WithMany()
                .HasForeignKey(o => o.CustomerId);

            builder.OwnsOne(x => x.Address, y =>
            {
                y.Property(c => c.Street)
                .HasMaxLength(200)
                .IsRequired();

                y.Property(c => c.Complement)
                    .HasMaxLength(100)
                    .IsRequired();

                y.Property(c => c.District)
                    .HasMaxLength(100)
                    .IsRequired();

                y.Property(c => c.City)
                    .HasMaxLength(100)
                    .IsRequired();

                y.Property(c => c.State)
                    .HasMaxLength(30)
                    .IsRequired();

                y.Property(c => c.Country)
                    .HasMaxLength(100)
                    .IsRequired();

                y.Property(c => c.ZipCode)
                    .HasMaxLength(20)
                    .IsRequired();
            });

            var navigation = builder.Metadata.FindNavigation(nameof(Order.OrderItems));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
