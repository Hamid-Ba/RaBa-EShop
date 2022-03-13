using Domain.OrderAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistent.EfCore.OrderAgg
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
	{
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders", "order");
            builder.HasKey(k => k.Id);

            builder.OwnsOne(o => o.Method, config =>
           {
               config.Property(p => p.Title).HasMaxLength(100);
           });

            builder.OwnsOne(o => o.Address, config =>
           {
               config.ToTable("Addresses", "order");
               config.HasKey(k => k.Id);

               config.Property(p => p.FullName).HasMaxLength(125).IsRequired();
               config.Property(p => p.PhoneNumber).HasMaxLength(11).IsRequired();
               config.Property(p => p.Province).HasMaxLength(75).IsRequired();
               config.Property(p => p.City).HasMaxLength(75).IsRequired();
               config.Property(p => p.Address).HasMaxLength(225).IsRequired();
               config.Property(p => p.PostalCode).HasMaxLength(11).IsRequired();
               config.Property(p => p.NationalCode).HasMaxLength(10).IsRequired();
           });

            builder.OwnsMany(o => o.Items, config =>
           {
               config.ToTable("Items", "order");
               config.HasKey(k => k.Id);

               config.OwnsOne(d => d.Discount);
           });
        }
    }
}