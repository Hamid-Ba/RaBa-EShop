using Domain.SiteEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistent.EfCore.SiteEntities
{
    public class SliderConfiguration : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(b => b.ImageName)
                  .HasMaxLength(120).IsRequired();

            builder.Property(b => b.Title)
                    .HasMaxLength(120);

            builder.Property(b => b.Link)
                .HasMaxLength(500);

            builder.OwnsOne(o => o.SeoImage, config =>
            {
                config.Property(p => p.Title).HasMaxLength(75);
                config.Property(p => p.Alternative).HasMaxLength(50);
            });

        }
    }
}