using Domain.SellerAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistent.EfCore.SellerAgg
{
    public class SellerConfiguration : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.ToTable("Sellers", "seller");

            builder.HasKey(k => k.Id);

            builder.Property(p => p.ShopName).HasMaxLength(85).IsRequired();
            builder.Property(p => p.NationalCode).HasMaxLength(10).IsRequired();

            builder.OwnsMany(o => o.Inventories, config =>
           {
               config.ToTable("Inventories", "seller");
               config.HasKey(k => k.Id);
           });
        }
    }
}