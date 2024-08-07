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
  public class CommentConfiguration : IEntityTypeConfiguration<Comment>
  {
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
      builder.ToTable("Comment");
      builder.HasKey(x => x.CommentId);
      builder.Property(x => x.Content).IsRequired().HasMaxLength(250);
      builder.Property(x => x.CreatedAt).IsRequired().HasDefaultValue(DateTime.UtcNow);
      builder.Property(x => x.ModifiedAt).IsRequired().HasDefaultValue(DateTime.UtcNow);

      builder.HasOne(x => x.User).WithMany(x => x.Comments).HasForeignKey(x => x.UserId).IsRequired().OnDelete(DeleteBehavior.Restrict); ;
      builder.HasOne(x => x.Post).WithMany(x => x.Comments).HasForeignKey(x => x.PostId).IsRequired().OnDelete(DeleteBehavior.Restrict); ;
    }
  }
}
