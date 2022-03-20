using Domain.ProductAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistent.EfCore.ProductAgg
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "product");
            builder.HasIndex(b => b.Slug).IsUnique();

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Title).HasMaxLength(125).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.ImageName).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Slug).HasMaxLength(300).IsRequired();

            builder.OwnsOne(o => o.SeoDate, config =>
           {
               config.Property(b => b.MetaDescription)
              .HasMaxLength(500)
              .HasColumnName("MetaDescription");

               config.Property(b => b.MetaTitle)
                   .HasMaxLength(500)
                   .HasColumnName("MetaTitle");

               config.Property(b => b.MetaKeyWords)
                   .HasMaxLength(500)
                   .HasColumnName("MetaKeyWords");

               config.Property(b => b.IndexPage)
                   .HasColumnName("IndexPage");

               config.Property(b => b.Canonical)
                   .HasMaxLength(500)
                   .HasColumnName("Canonical");

               config.Property(b => b.Schema)
                   .HasColumnName("Schema");
           });

            builder.OwnsOne(o => o.SeoImage, config =>
           {
               config.Property(p => p.Title).HasMaxLength(75);
               config.Property(p => p.Alternative).HasMaxLength(50);
           });

            builder.OwnsMany(o => o.Images, config =>
           {
               config.ToTable("Images", "product");
               config.HasKey(k => k.Id);

               config.Property(p => p.ImageName).HasMaxLength(100).IsRequired();

               config.OwnsOne(s => s.SeoImage, option =>
              {
                  option.Property(p => p.Title).HasMaxLength(75);
                  option.Property(p => p.Alternative).HasMaxLength(50);
              });

           });

            builder.OwnsMany(o => o.Specifications, config =>
           {
               config.ToTable("Specifactions", "product");
               config.HasKey(k => k.Id);

               config.Property(p => p.Key).HasMaxLength(100).IsRequired();
               config.Property(p => p.Value).HasMaxLength(225).IsRequired();
           });
        }
    }
}