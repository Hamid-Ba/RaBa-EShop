using Domain.CategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistent.EfCore.CategoryAgg
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories", "dbo");

            builder.HasKey(k => k.Id);
            builder.HasIndex(i => i.Slug).IsUnique();

            builder.Property(p => p.Title).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Slug).HasMaxLength(100).IsRequired();

            builder.HasMany(c => c.Children)
                .WithOne()
                .HasForeignKey(f => f.ParentId);

            builder.OwnsOne(o => o.SeoData, config =>
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
        }
    }
}