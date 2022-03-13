using Domain.UserAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistent.EfCore.UserAgg
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "user");
            builder.HasKey(k => k.Id);

            builder.Property(p => p.FirstName).HasMaxLength(72);
            builder.Property(p => p.LastName).HasMaxLength(100);
            builder.Property(p => p.Avatar).HasMaxLength(100);
            builder.Property(p => p.PhoneNumber).HasMaxLength(11).IsRequired();
            builder.Property(p => p.Password).IsRequired();

            builder.OwnsMany(o => o.Roles, config =>
           {
               config.ToTable("Roles", "user");
           });

            builder.OwnsMany(o => o.Wallets, config =>
           {
               config.ToTable("Wallets", "user");
               config.HasKey(k => k.Id);

               config.Property(p => p.RefId).HasMaxLength(11);
           });

            builder.OwnsMany(o => o.Addresses, config =>
           {
               config.ToTable("Addresses", "user");
               config.HasKey(k => k.Id);

               config.Property(p => p.FullName).HasMaxLength(150).IsRequired();
               config.Property(p => p.PhoneNumber).HasMaxLength(11).IsRequired();
               config.Property(p => p.Province).HasMaxLength(150).IsRequired();
               config.Property(p => p.City).HasMaxLength(150).IsRequired();
               config.Property(p => p.Address).HasMaxLength(500).IsRequired();
               config.Property(p => p.PostalCode).HasMaxLength(10).IsRequired();
               config.Property(p => p.NationalCode).HasMaxLength(10).IsRequired();
           });
        }
    }
}