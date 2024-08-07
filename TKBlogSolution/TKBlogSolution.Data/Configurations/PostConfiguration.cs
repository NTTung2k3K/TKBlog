using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKBlogSolution.Data.Entities;

namespace TKBlogSolution.Data.Configurations
{
  public class PostConfiguration : IEntityTypeConfiguration<Post>
  {
    public void Configure(EntityTypeBuilder<Post> builder)
    {
      builder.ToTable("Post");
      builder.HasKey(x => x.PostId);
      builder.Property(x => x.PostTitle).IsRequired().HasMaxLength(250);
      builder.Property(x => x.PostBody).HasMaxLength(int.MaxValue).IsRequired();
      builder.Property(x => x.PostSummary).HasMaxLength(int.MaxValue).IsRequired(false);
      builder.Property(x => x.ViewCount).IsRequired().HasDefaultValue(0);
      builder.Property(x => x.CreatedAt).IsRequired().HasDefaultValue(DateTime.UtcNow);
      builder.Property(x => x.ModifiedAt).IsRequired().HasDefaultValue(DateTime.UtcNow);

      builder.HasMany(x => x.PostTags).WithOne(x => x.Post).HasForeignKey(x => x.PostId).IsRequired();
      builder.HasOne(x => x.Category).WithMany(x => x.Posts).HasForeignKey(x => x.PostId).IsRequired();
      builder.HasMany(x => x.Comments).WithOne(x => x.Post).HasForeignKey(x => x.CommentId).IsRequired();
      builder.HasOne(x => x.User)
            .WithMany(x => x.Posts)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
  }
}
