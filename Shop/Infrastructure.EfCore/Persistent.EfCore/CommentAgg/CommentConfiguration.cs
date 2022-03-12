using Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistent.EfCore.CommentAgg
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
	{
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments", "dbo");

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Content).HasMaxLength(1000).IsRequired();
        }
    }
}