using Angular7NetCoreStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Angular7NetCoreStore.Infra.Data.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.OwnsOne(x => x.FullName, y =>
            {
                y.Property(x => x.Name).IsRequired().HasMaxLength(100);
                y.Property(x => x.Surname).IsRequired().HasMaxLength(200);
            });

            builder.OwnsOne(x => x.Email, y =>
            {
                y.Property(x => x.Address).IsRequired().HasMaxLength(200);
            });

            builder.OwnsOne(x => x.PhoneNumber, y =>
            {
                y.Property(x => x.AreaCode).IsRequired().HasMaxLength(2);
                y.Property(x => x.Number).IsRequired().HasMaxLength(20);
            });

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
        }
    }
}
