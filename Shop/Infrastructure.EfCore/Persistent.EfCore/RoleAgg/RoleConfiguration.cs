using Domain.RoleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistent.EfCore.RoleAgg
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles", "role");

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Title).HasMaxLength(85).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(225);

            builder.OwnsMany(o => o.Permissions, config =>
           {
               config.ToTable("Permissions", "role");
           });
        }
    }
}