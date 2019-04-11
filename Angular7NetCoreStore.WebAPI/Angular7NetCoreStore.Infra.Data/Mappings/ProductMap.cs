using Angular7NetCoreStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Angular7NetCoreStore.Infra.Data.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Title)
                .HasColumnType("varchar(200)")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(c => c.Description)
                .HasColumnType("varchar(2000)")
                .HasMaxLength(2000)
                .IsRequired();

            builder.Property(c => c.Image)
                .HasColumnType("varchar(200)")
                .HasMaxLength(200)
                .IsRequired();

            builder.HasData(new Product(Guid.NewGuid(), "Guitarra Ibanex GRG220", "Guitarra Ibanex GRG220 Preta", 
                "https://http2.mlstatic.com/guitarra-electrica-ibanez-gio-grg220dex-D_NQ_NP_760329-MLV27359093213_052018-F.jpg", 1200, 50));
            builder.HasData(new Product(Guid.NewGuid(), "Celular S9", "Samsung s9",
                "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRh_iIgH_ErtqFO1tiMpysB3Z5VeJUjaThLCtKkajwXA_V4GXkp", 2000, 50));
            builder.HasData(new Product(Guid.NewGuid(), "Kindle", "Kindle new generation",
                "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSHmy5pzaQxrs4nzLNXP0Ca-1zkBgzfLCwOMjxmDFDx02FGSzI6", 200, 50));
        }
    }
}
